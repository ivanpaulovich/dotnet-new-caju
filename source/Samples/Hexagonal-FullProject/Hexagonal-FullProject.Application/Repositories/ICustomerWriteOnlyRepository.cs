namespace Hexagonal_FullProject.Application.Repositories
{
    using Hexagonal_FullProject.Domain.Customers;
    using System.Threading.Tasks;

    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
