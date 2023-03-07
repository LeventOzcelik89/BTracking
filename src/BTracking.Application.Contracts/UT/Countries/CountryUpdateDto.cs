using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTracking.UT.Countries
{
    public class CountryUpdateDto
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string CountryName { get; set; }
        public Geometry CountryShape { get; set; }
    }
}
