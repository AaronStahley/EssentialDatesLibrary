using static System.DayOfWeek;

namespace EssentialDates.Extensions;

public static class BusinessDateExtension
{
    /// <summary>
    /// Determines the next business date. Increments the date by 1 day
    /// and checks to see if that day is a federal holiday or weekend. If either
    /// of those are true it continues to increment by 1 day until it finds a business day. 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>Next Business Date</returns>
    public static DateTime NextBusinessDay(this DateTime date)
    {
        do
        {
            date = date.AddDays(1);
        }
        while (date.IsObservedFederalHoliday() || date is { DayOfWeek: Saturday or Sunday });

        return date;
    }

    /// <summary>
    /// Determines if the date is a business day or not. 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if a business day. False if not</returns>
    public static bool IsBusinessDay(this DateTime date) =>
        !date.IsObservedFederalHoliday() && date is not { DayOfWeek: Saturday or Sunday };
}