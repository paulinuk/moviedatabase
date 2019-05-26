using System;

namespace MovieDatabase.Common.Helpers
{
    public static class MathHelper
    {
        public static decimal RoundToNearestHalf(this decimal value)
        {
            var result = Math.Round(value * 2) / 2;
            return result;
        }
    }
}
