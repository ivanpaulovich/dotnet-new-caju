namespace MyReadOnly.Application.Services
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}