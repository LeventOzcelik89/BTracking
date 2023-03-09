using NetTopologySuite.Features;
using NetTopologySuite.IO;
using Polly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BTracking.UT.Countries
{
    //  IDataSeedContributor kaldırıldı. Sıralı bir işlem gerektiğinden sebep DataSeederConfig içerisine taşındı.
    //  public class CountryDataSeedContributor : IDataSeedContributor, ITransientDependency
    public class CountryDataSeedContributor : ITransientDependency
    {
        private string _sourceDir =>
            System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
            "/BTracking.Domain/SourceFiles/Locations/Country.json";

        private readonly ICountryRepository _countryRepository;
        public CountryDataSeedContributor(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }



        public async Task SeedAsync(DataSeedContext context)
        {

            var countryList = (await _countryRepository.GetQueryableAsync()).ToList();
            var source = System.IO.File.ReadAllText(_sourceDir);

            var jsonReader = new GeoJsonReader();
            var features = jsonReader.Read<NetTopologySuite.Features.FeatureCollection>(source);
            if (features == null)
            {
                throw new System.Exception("features is null");
            }

            //  Tek bir feature mevcut. O da Türkiye.
            if (!countryList.Any(a => a.Code == CountryConsts.DBTurkeyCode))
            {
                var rs = await _countryRepository.InsertAsync(new Country
                {
                    Name = features.FirstOrDefault().Attributes["NAME_0"].ToString(),
                    Shape = features.FirstOrDefault().Geometry,
                    Code = CountryConsts.DBTurkeyCode
                }, autoSave: true);
            }

        }
    }
}
