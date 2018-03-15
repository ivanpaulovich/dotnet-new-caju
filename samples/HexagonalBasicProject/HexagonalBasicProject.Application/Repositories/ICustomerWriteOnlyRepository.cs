namespace HexagonalBasicProject.Application.Repositories
{
    using HexagonalBasicProject.Domain.Customers;
    using System.Threading.Tasks;

    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
