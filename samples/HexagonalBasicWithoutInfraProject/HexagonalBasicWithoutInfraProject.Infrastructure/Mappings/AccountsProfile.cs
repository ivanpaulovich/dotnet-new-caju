namespace HexagonalBasicWithoutInfraProject.Infrastructure.Mappings
{
    using HexagonalBasicWithoutInfraProject.Application.Outputs;
    using AutoMapper;
    using HexagonalBasicWithoutInfraProject.Domain.Accounts;

    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountOutput>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.GetCurrentBalance().Value))
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions.Items));

            CreateMap<Debit, TransactionOutput>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));

            CreateMap<Credit, TransactionOutput>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));
        }
    }
}
