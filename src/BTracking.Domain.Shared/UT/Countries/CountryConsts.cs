using System;
using System.Collections.Generic;
using System.Text;

namespace BTracking.UT.Countries
{

    public static class CountryConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Location." : string.Empty);
        }

        public const int PropertyCodeMinLength = 0;
        public const int PropertyCodeMaxLength = 5;

        public const int PropertyNameMinLength = 0;
        public const int PropertyNameMaxLength = 255;

        public const string DBTurkeyCode = "tr-TR";

    }

}
