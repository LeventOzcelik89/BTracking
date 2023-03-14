using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTracking.UT.Cities
{
    public class CityCreateDto
    {
        [Required]
        public Guid CountryId { get; set; }
        [Required]
        public string CityName { get; set; }
        public Geometry CityShape { get; set; }
    }
}
