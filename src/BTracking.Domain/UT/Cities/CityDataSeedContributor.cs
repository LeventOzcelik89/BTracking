using BTracking.UT.Countries;
using NetTopologySuite;
using NetTopologySuite.IO;
using Polly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BTracking.UT.Cities
{
    public class CityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private string _sourceDir =>
            System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
            "/BTracking.Domain/SourceFiles/Locations/City.json";

        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        public CityDataSeedContributor(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            var cityList = (await _cityRepository.GetQueryableAsync()).ToList();
            var country = await _countryRepository.GetAsync(a => a.Code == CountryConsts.DBTurkeyCode);
            var source = System.IO.File.ReadAllText(_sourceDir);

            var jsonReader = new GeoJsonReader();
            var features = jsonReader.Read<NetTopologySuite.Features.FeatureCollection>(source);
            if (features == null)
            {
                throw new System.Exception("features is null");
            }

            foreach (var feature in features)
            {

                if (!cityList.Any(a => a.Name == feature.Attributes["NAME_1"].ToString()))
                {
                    var rs = await _cityRepository.InsertAsync(new City
                    {
                        Name = feature.Attributes["NAME_1"].ToString(),
                        Shape = feature.Geometry,
                        CountryId  = country.Id
                    }, autoSave: true);
                }

            }

        }
    }
}
