namespace MyBasic.UnitTests.TestFixtures
{
    using MyBasic.Infrastructure.InMemoryDataAccess.Repositories;
    using MyBasic.Infrastructure.InMemoryDataAccess;

    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public Presenter Presenter { get; }
        public MyBasicContext Context { get; }
        public AccountRepository AccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            Presenter = new Presenter();
            Context = new MyBasicContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}