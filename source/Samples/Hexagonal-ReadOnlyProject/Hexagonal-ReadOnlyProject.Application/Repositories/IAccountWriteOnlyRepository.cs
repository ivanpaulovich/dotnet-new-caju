namespace Hexagonal_ReadOnlyProject.Application.Repositories
{
    using Hexagonal_ReadOnlyProject.Domain.Accounts;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);
    }
}
