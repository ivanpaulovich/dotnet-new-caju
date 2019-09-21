namespace MyReadOnly.Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using MyReadOnly.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private MyReadOnlyContext context;

        public UnitOfWork(MyReadOnlyContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}