namespace CleanReadOnlyProject.Application.Repositories
{
    using CleanReadOnlyProject.Domain.Accounts;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);
    }
}
