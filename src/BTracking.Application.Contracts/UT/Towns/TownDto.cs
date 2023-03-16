using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Towns
{
    public class TownDto : FullAuditedEntityDto<Guid>
    {
        public Guid CityId { get; set; }
        public string TownName { get; set; }
        public Geometry TownShape { get; set; }
    }
}
