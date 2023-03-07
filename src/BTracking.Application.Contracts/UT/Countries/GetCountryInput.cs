using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Countries
{

    public class GetCountryInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string CountryCode { get; set; }
        public string CountryLabel { get; set; }
        
        public GetCountryInput()
        {

        }
    }

}
