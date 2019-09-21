namespace MyFull.Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using MyFull.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private MyFullContext context;

        public UnitOfWork(MyFullContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}