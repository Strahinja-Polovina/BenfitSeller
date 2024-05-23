using ApiLibrary.Helpers;
using ApiLibrary.Models;
using AutoMapper;
using BaseLibrary.DTO;
using BaseLibrary.Responses;


namespace ApiLibrary.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Company, OCompanyDTO>().ReverseMap();

            CreateMap<Company, AddCompanyDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Constants.CompanyRole));

            CreateMap<IUpdateCompanyDTO, OCompanyDTO>().ReverseMap();

            CreateMap<Benefit, IBenefitDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Category, ICategoryDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Merchant, IUpdateMerchantDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Merchant, ICreateMerchantDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Benefit, opet => opet.Ignore());

            CreateMap<Employee, IEmployeeDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Employee, OEmployeeDTO>().ReverseMap();

            CreateMap<Merchant, OMerchantDTO>().ReverseMap();

            CreateMap<CompanyBenefits, ICompanyBenefitDTO>().ReverseMap();

            CreateMap<CompanyMerchantsDiscounts, ICompanyMerchantDTO>().ReverseMap();

            CreateMap<Card, ICardDTO>().ReverseMap();

            CreateMap<PaymentResponse, Transactions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
