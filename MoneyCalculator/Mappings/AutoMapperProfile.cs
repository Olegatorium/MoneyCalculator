using AutoMapper;
using MoneyCalculator.Entities;
using MoneyCalculator.Entities.DTO;

namespace MoneyCalculator.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Region:
            CreateMap<MoneyData, MoneyResponse>().ReverseMap();
            CreateMap<MoneyData, MoneyAddRequest>().ReverseMap();
        }
    }
}
