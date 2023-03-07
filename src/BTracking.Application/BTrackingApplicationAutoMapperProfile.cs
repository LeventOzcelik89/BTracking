using AutoMapper;
using BTracking.UT.Countries;
using Volo.Abp.AutoMapper;

namespace BTracking;

public class BTrackingApplicationAutoMapperProfile : Profile
{
    public BTrackingApplicationAutoMapperProfile()
    {


        CreateMap<CountryCreateDto, Country>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
        CreateMap<CountryUpdateDto, Country>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
        CreateMap<Country, CountryDto>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);

        
    }
}
