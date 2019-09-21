namespace MyReadOnly.UnitTests.TestFixtures
{
    using MyReadOnly.Infrastructure.InMemoryDataAccess.Repositories;
    using MyReadOnly.Infrastructure.InMemoryDataAccess;

    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public Presenter Presenter { get; }
        public MyReadOnlyContext Context { get; }
        public AccountRepository AccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            Presenter = new Presenter();
            Context = new MyReadOnlyContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}