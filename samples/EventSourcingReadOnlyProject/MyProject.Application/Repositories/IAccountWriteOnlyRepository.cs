namespace EventSourcingReadOnlyProject.Application.Repositories
{
    using EventSourcingReadOnlyProject.Domain.Accounts;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);
    }
}
