namespace CleanBasicWithoutInfraProject.Infrastructure.Mappings
{
    using AutoMapper;
    using CleanBasicWithoutInfraProject.Application.Results;
    using CleanBasicWithoutInfraProject.Domain.Customers;

    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerResult>()
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Personnummer, opt => opt.MapFrom(src => src.PIN.Text))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Text))
                    .ForMember(dest => dest.Accounts, opt => opt.Ignore());
        }
    }
}
