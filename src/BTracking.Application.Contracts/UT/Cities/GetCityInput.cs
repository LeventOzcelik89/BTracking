using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Cities
{
    public class GetCityInput : PagedAndSortedResultRequestDto
    {
        public Guid CountryId { get; set; }

        public string FilterText { get; set; }

        public GetCityInput()
        {

        }
    }

}
