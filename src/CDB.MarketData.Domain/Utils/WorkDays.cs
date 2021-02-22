using BrazilHolidays.Net;
using System;

namespace CDB.MarketData.Domain.Utils
{
    public static class WorkDays
    {
        public static int GetWorkDays(DateTime initialDate, DateTime finalDate)
        {
            var days = 0;
            var daysCount = 0;
            days = initialDate.Subtract(finalDate).Days;

            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                initialDate = initialDate.AddDays(1);

                if (initialDate.DayOfWeek != DayOfWeek.Sunday &&
                    initialDate.DayOfWeek != DayOfWeek.Saturday &&
                    !initialDate.IsHoliday())
                    daysCount++;
            }

            return daysCount;
        }

        public static bool DateIsValid(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday
                && date.DayOfWeek == DayOfWeek.Saturday
                && date.IsHoliday())
                return false;

            return true;
        }
    }
}
