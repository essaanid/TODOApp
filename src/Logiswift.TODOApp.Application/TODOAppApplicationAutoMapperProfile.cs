using AutoMapper;
using Logiswift.TODOApp.Items;
namespace Logiswift.TODOApp;

public class TODOAppApplicationAutoMapperProfile : Profile
{
    public TODOAppApplicationAutoMapperProfile()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<CreateItemDto, Item>();
        CreateMap<UpdateItemDto, Item>();
        /* CreateMap<City, CityDto>().ForMember(
           m => m.CountryName, opt =>
                   opt.MapFrom(m => m.Country.Name)
           );*/
    }
}
