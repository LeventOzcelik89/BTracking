using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Cities
{
    public class CityDto : FullAuditedEntityDto<Guid>
    {
        public Guid CountryId { get; set; }
        public string CityName { get; set; }
        public Geometry CityShape { get; set; }
    }
}
