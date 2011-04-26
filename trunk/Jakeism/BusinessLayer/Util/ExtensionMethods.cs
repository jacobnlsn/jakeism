using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Util
{
    public static class TimeSpanExtensions
    {
        public static int GetYears(this TimeSpan timespan)
        {
            return (int)((double)timespan.Days / Constants.YEAR_IN_DAYS);
        }

        public static int GetMonths(this TimeSpan timespan, int years)
        {
            var days = timespan.Days - (years * Constants.YEAR_IN_DAYS);
            return (int)((double)days / Constants.MONTH_IN_DAYS);
        }
    }
}
