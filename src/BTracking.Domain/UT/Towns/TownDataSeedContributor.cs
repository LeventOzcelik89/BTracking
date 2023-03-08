using BTracking.UT.Cities;
using BTracking.UT.Countries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BTracking.UT.Towns
{

    public class TownDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private string _sourceDir =>
            System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
            "/BTracking.Domain/SourceFiles/Locations/Town.json";

        private readonly ICityRepository _cityRepository;
        private readonly ITownRepository _townRepository;
        public TownDataSeedContributor(ITownRepository townRepository, ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _townRepository = townRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            var cityList = (await _cityRepository.GetQueryableAsync()).ToList();
            var townList = (await _townRepository.GetQueryableAsync()).ToList();

            var source = System.IO.File.ReadAllText(_sourceDir);

            var jsonReader = new GeoJsonReader();
            var features = jsonReader.Read<NetTopologySuite.Features.FeatureCollection>(source);
            if (features == null)
            {
                throw new System.Exception("features is null");
            }

            foreach (var feature in features)
            {

                var city = cityList.Where(a => a.Name == feature.Attributes["NAME_1"].ToString()).FirstOrDefault();
                if (city == null)
                {
                    continue;
                }

                if (!townList.Any(a => a.Name == feature.Attributes["NAME_2"].ToString() && a.CityId == city.Id))
                {
                    var rs = await _townRepository.InsertAsync(new Town
                    {
                        Name = feature.Attributes["NAME_2"].ToString(),
                        Shape = feature.Geometry,
                        CityId = city.Id
                    }, autoSave: true);
                }

            }

        }
    }

}
