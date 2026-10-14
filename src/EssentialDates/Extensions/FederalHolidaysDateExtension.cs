using static System.DayOfWeek;
using static EssentialDates.Enums.Month;
using static EssentialDates.Constants.Common;

namespace EssentialDates.Extensions;

public static class FederalHolidaysDateExtension
{
    /// <summary>
    /// Determines if the date is an observed U.S. federal holiday or not. An observed federal holiday
    /// is the date in which federal institutions are closed such as banks. If the holiday falls on
    /// a Saturday it will be observed the preceding Friday and if it falls on a Sunday it will be observed
    /// on the following Monday.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if date is a federal holiday and false if the date is not a federal holiday</returns>
    public static bool IsObservedFederalHoliday(this DateTime date)
    {
        // There are no holidays in March, April or August. 
        if (date.Month is (int)March or (int)April or (int)August) { return false; }

        if (date.IsObservedNewYearsDay()) { return true; }
        if (date.IsObservedMlkDay()) { return true; }
        if (date.IsObservedPresidentDay()) { return true; }
        if (date.IsObservedMemorialDay()) { return true; }
        if (date.IsObservedJuneteenth()) { return true; }
        if (date.IsObservedIndependenceDay()) { return true; }
        if (date.IsObservedLaborDay()) { return true; }
        if (date.IsObservedColumbusDay()) { return true; }
        if (date.IsObservedVeteranDay()) { return true; }
        if (date.IsObservedThanksgivingDay()) { return true; }
        if (date.IsObservedChristmasDay()) { return true; }

        return false;
    }

    /// <summary>
    /// Determines if the date is observed New Years Day. This is determined by the date being
    /// January 1st, or the preceding Friday or following Monday if the 1st is a weekend.
    /// If the 1st is a Saturday the observed date will fall on the 31st of the prior year. 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for New Years Day. False if not.</returns>
    public static bool IsObservedNewYearsDay(this DateTime date) =>
        date is { Month: (int)December, Day: 31, DayOfWeek: Friday } or
        { Month: (int)January, Day: 1, DayOfWeek: not (Saturday or Sunday) } or
        { Month: (int)January, Day: 2, DayOfWeek: Monday };

    /// <summary>
    /// Determines if the date is observed Martin Luther King Jr. Day.
    /// This is determined by the date being the third Monday in January.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Martin Luther King Jr and False if not.</returns>
    public static bool IsObservedMlkDay(this DateTime date) =>
        date is { Month: (int)January, DayOfWeek: Monday } && date.WeekDayOccurrence() == 3;

    /// <summary>
    /// Determines if the date is observed Presidents Day.
    /// This is determined by the date being the third Monday in February.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Presidents Day and False if not.</returns>
    public static bool IsObservedPresidentDay(this DateTime date) =>
        date is { Month: (int)February, DayOfWeek: Monday } && date.WeekDayOccurrence() == 3;

    /// <summary>
    /// Determines if the date is observed Memorial Day.
    /// This is determined by the date being the last Monday in May.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Memorial Day and False if not.</returns>
    public static bool IsObservedMemorialDay(this DateTime date) =>
        date is { Month: (int)May, DayOfWeek: Monday } && date.AddDays(7).Month == 6;

    /// <summary>
    /// Determines if the date is observed Juneteenth.
    /// This is determined by the date being June 19th, or the preceding Friday or following Monday if the 19th is a weekend.
    /// Juneteenth was declared an official Federal Holiday in 2021 so it may not be accurate to use this prior to 2021. 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Juneteenth and False if not</returns>
    public static bool IsObservedJuneteenth(this DateTime date) =>
        date is { Month: (int)June, Day: 18, DayOfWeek: Friday } or
        { Month: (int)June, Day: 19, DayOfWeek: not (Saturday or Sunday) } or
        { Month: (int)June, Day: 20, DayOfWeek: Monday };

    /// <summary>
    /// Determines if the date is observed Independence Day.
    /// This is determined by the date being July 4th, or the preceding Friday or following Monday if the 4th is a weekend.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Independence Day and False if not</returns>
    public static bool IsObservedIndependenceDay(this DateTime date) =>
        date is { Month: (int)July, Day: 3, DayOfWeek: Friday } or
        { Month: (int)July, Day: 4, DayOfWeek: not (Saturday or Sunday) } or
        { Month: (int)July, Day: 5, DayOfWeek: Monday };

    /// <summary>
    /// Determines if the date is observed Labor Day.
    /// This is determined by the date being the first Monday in September.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Labor Day and False if not.</returns>
    public static bool IsObservedLaborDay(this DateTime date) =>
        date is { Month: (int)September, DayOfWeek: Monday } && date.WeekDayOccurrence() == 1;

    /// <summary>
    /// Determines if the date is observed Columbus Day also known as Indigenous People Day.
    /// This is determined by the date being the second Monday in October.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Columbus Day and False if not.</returns>
    public static bool IsObservedColumbusDay(this DateTime date) =>
        date is { Month: (int)October, DayOfWeek: Monday } && date.WeekDayOccurrence() == 2;

    /// <summary>
    /// Determines if the date is observed Veteran’s Day.
    /// This is determined by the date being November 11th, or the preceding Friday or following Monday if the 11th is a weekend.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Veteran’s Day and False if not.</returns>
    public static bool IsObservedVeteranDay(this DateTime date) =>
        date is { Month: (int)November, Day: 10, DayOfWeek: Friday } or
        { Month: (int)November, Day: 11, DayOfWeek: not (Saturday or Sunday) } or
        { Month: (int)November, Day: 12, DayOfWeek: Monday };

    /// <summary>
    /// Determines if the date is observed Thanksgiving Day.
    /// This is determined by the date being the fourth Thursday in November.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Thanksgiving Day and False if not</returns>
    public static bool IsObservedThanksgivingDay(this DateTime date) =>
        date is { Month: (int)November, DayOfWeek: Thursday } && date.WeekDayOccurrence() == 4;

    /// <summary>
    /// Determines if the date is observed Christmas Day.
    /// This is determined by the date being December 25th, or the preceding Friday or following Monday if the 25th is a weekend.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>True if the date is the observed date for Christmas Day and False if not</returns>
    public static bool IsObservedChristmasDay(this DateTime date) =>
        date is { Month: (int)December, Day: 24, DayOfWeek: Friday } or
        { Month: (int)December, Day: 25, DayOfWeek: not (Saturday or Sunday) } or
        { Month: (int)December, Day: 26, DayOfWeek: Monday };

    /// <summary>
    /// Represents which week of the month a given date is. 
    /// For example if its the fourth Monday of the month the response will be four. 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>Integer value for which week that day falls in.</returns>
    private static int WeekDayOccurrence(this DateTime date) =>
        (int)Math.Ceiling(date.Day / (double)DaysInWeek);
}