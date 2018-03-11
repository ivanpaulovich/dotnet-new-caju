namespace Hexagonal_FullProject.Infrastructure.Mappings
{
    using Hexagonal_FullProject.Application;
    using AutoMapper;

    public class ResultConverter : IResultConverter
    {
        private readonly IMapper mapper;

        public ResultConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountsProfile>();
                cfg.AddProfile<CustomersProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
