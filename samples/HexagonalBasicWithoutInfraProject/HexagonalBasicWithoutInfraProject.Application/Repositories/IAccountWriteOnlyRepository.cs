namespace HexagonalBasicWithoutInfraProject.Application.Repositories
{
    using HexagonalBasicWithoutInfraProject.Domain.Accounts;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);
    }
}
