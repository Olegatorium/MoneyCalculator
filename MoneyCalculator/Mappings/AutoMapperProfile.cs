using AutoMapper;
using MoneyCalculator.Entities;
using MoneyCalculator.Entities.DTO;

namespace MoneyCalculator.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MoneyData, MoneyResponse>().ReverseMap();
            CreateMap<MoneyData, MoneyAddRequest>().ReverseMap();
            CreateMap<MoneyData, MoneyUpdateRequest>().ReverseMap();
            CreateMap<MoneyResponse, MoneyUpdateRequest>().ReverseMap();
        }
    }
}
