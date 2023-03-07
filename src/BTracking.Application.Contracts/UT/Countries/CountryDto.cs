using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Countries
{
    public class CountryDto : FullAuditedEntityDto<Guid>
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public Geometry CountryShape { get; set; }
        
    }

}
