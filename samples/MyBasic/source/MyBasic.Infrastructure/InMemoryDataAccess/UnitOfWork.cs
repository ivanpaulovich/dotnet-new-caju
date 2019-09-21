namespace MyBasic.Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using MyBasic.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private MyBasicContext context;

        public UnitOfWork(MyBasicContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}