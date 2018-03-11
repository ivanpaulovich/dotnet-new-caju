namespace Hexagonal_FullProject.Application.Commands.Close
{
    using System.Threading.Tasks;
    using Hexagonal_FullProject.Application.Repositories;
    using Hexagonal_FullProject.Domain.Accounts;

    public class CloseService : ICloseService
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public CloseService(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<CloseResult> Process(CloseCommand command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            account.Close();

            await accountWriteOnlyRepository.Delete(account);

            CloseResult result = resultConverter.Map<CloseResult>(account);

            return result;
        }
    }
}
