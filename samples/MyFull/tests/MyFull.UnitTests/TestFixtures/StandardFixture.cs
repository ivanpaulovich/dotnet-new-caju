namespace MyFull.UnitTests.TestFixtures
{
    using MyFull.Infrastructure.InMemoryDataAccess.Repositories;
    using MyFull.Infrastructure.InMemoryDataAccess;

    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public Presenter Presenter { get; }
        public MyFullContext Context { get; }
        public AccountRepository AccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            Presenter = new Presenter();
            Context = new MyFullContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}