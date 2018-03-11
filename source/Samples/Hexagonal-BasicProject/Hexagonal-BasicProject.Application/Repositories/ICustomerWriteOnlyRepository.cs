namespace Hexagonal_BasicProject.Application.Repositories
{
    using Hexagonal_BasicProject.Domain.Customers;
    using System.Threading.Tasks;

    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
