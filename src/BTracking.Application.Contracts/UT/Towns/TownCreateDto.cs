using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTracking.UT.Towns
{
    public class TownCreateDto
    {
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public string TownName { get; set; }
        public Geometry TownShape { get; set; }
    }
}
