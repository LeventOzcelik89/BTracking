using System;
using System.Collections.Generic;
using System.Text;

namespace BTracking.UT.Towns
{
    public static class TownConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Town." : string.Empty);
        }

        public const int PropertyNameMinLength = 0;
        public const int PropertyNameMaxLength = 255;

    }
}
