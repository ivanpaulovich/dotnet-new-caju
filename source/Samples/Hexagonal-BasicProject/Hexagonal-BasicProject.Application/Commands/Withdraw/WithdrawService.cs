namespace Hexagonal_BasicProject.Application.Commands.Withdraw
{
    using System.Threading.Tasks;
    using Hexagonal_BasicProject.Application.Results;
    using Hexagonal_BasicProject.Domain.ValueObjects;
    using Hexagonal_BasicProject.Application.Repositories;
    using Hexagonal_BasicProject.Domain.Accounts;

    public class WithdrawService : IWithdrawService
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public WithdrawService(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<WithdrawResult> Process(WithdrawCommand command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(command.Amount));
            account.Withdraw(debit);

            await accountWriteOnlyRepository.Update(account);

            TransactionResult transactionResult = resultConverter.Map<TransactionResult>(debit);
            WithdrawResult result = new WithdrawResult(
                transactionResult,
                account.GetCurrentBalance().Value
            );

            return result;
        }
    }
}
