using EssentialDates.Extensions;
using FluentAssertions;
using Xunit;

namespace EssentialDates.Tests.Extensions;

public class BusinessDateExtensionTests
{
    [Theory]
    [InlineData("2024-04-01", "2024-04-02")] //Monday next business day is Tuesday
    [InlineData("2024-04-02", "2024-04-03")] //Tuesday next business day is Wednesday
    [InlineData("2024-04-03", "2024-04-04")] //Wednesday next business day is Thursday
    [InlineData("2024-04-04", "2024-04-05")] //Thursday next business day is Friday
    [InlineData("2024-04-05", "2024-04-08")] //Friday next business day is Monday 
    [InlineData("2024-04-06", "2024-04-08")] //Saturday next business day is Monday 
    [InlineData("2024-04-07", "2024-04-08")] //Sunday next business day is Monday

    [InlineData("2024-01-01", "2024-01-02")] //Observed New Years Day on Monday next business day is Tuesday
    [InlineData("2023-12-31", "2024-01-02")] //Day before observed New Years Day on Monday next business day is Tuesday
    [InlineData("2021-12-31", "2022-01-03")] //Observed New Years Day falls on Saturday so observed date is Friday 12-31. Next business day is Monday. 
    [InlineData("2021-12-30", "2022-01-03")] //Day before observed New Years Day falls on Saturday so observed date is Friday 12-31. Next business day is Monday. 

    [InlineData("2024-01-15", "2024-01-16")] //Observed Mlk Day on Monday next business day is Tuesday
    [InlineData("2024-01-14", "2024-01-16")] //Day before observed Mlk Day on Monday next business day is Tuesday
    [InlineData("2024-01-13", "2024-01-16")] //Two days before observed Mlk Day on Monday next business day is Tuesday

    [InlineData("2024-02-19", "2024-02-20")] //Observed President Day on Monday next business day is Tuesday
    [InlineData("2024-02-18", "2024-02-20")] //Day before observed President Day on Monday next business day is Tuesday
    [InlineData("2024-02-17", "2024-02-20")] //Two Days before observed President Day on Monday next business day is Tuesday

    [InlineData("2024-05-27", "2024-05-28")] //Observed Memorial Day on Monday next business day is Tuesday
    [InlineData("2024-05-26", "2024-05-28")] //Day before observed Memorial Day on Monday next business day is Tuesday
    [InlineData("2024-05-25", "2024-05-28")] //Two days before observed Memorial Day on Monday next business day is Tuesday

    [InlineData("2024-06-19", "2024-06-20")] //Observed Juneteenth on Wednesday next business day is Thursday
    [InlineData("2024-06-18", "2024-06-20")] //Day before observed Juneteenth on Wednesday next business day is Thursday

    [InlineData("2024-07-04", "2024-07-05")] //Observed Independence Day on Thursday next business day is Friday
    [InlineData("2024-07-03", "2024-07-05")] //Day before observed Independence Day on Thursday next business day is Friday

    [InlineData("2024-10-14", "2024-10-15")] //Observed Columbus Day on Monday next business day is Tuesday
    [InlineData("2024-10-13", "2024-10-15")] //Day before observed Columbus Day on Monday next business day is Tuesday

    [InlineData("2024-11-11", "2024-11-12")] //Observed Veteran Day on Monday next business day is Tuesday
    [InlineData("2024-11-10", "2024-11-12")] //Day before observed Veteran Day on Monday next business day is Tuesday

    [InlineData("2024-11-28", "2024-11-29")] //Observed Thanksgiving Day on Thursday next business day is Friday
    [InlineData("2024-11-27", "2024-11-29")] //Day before observed Thanksgiving Day on Thursday next business day is Friday

    [InlineData("2024-12-25", "2024-12-26")] //Observed Christmas Day on Wednesday next business day is Thursday
    [InlineData("2024-12-24", "2024-12-26")] //Day before observed Christmas Day on Wednesday next business day is Thursday
    public void NextBusinessDay_GiveValidDates_ShouldReturnNextValidBusinessDate(DateTime testDate, DateTime expectedNextBusinessDate)
    {
        var result = testDate.NextBusinessDay();
        result.Should().Be(expectedNextBusinessDate);
    }

    [Theory]
    [InlineData("2024-04-01")] //Monday
    [InlineData("2024-04-02")] //Tuesday
    [InlineData("2024-04-03")] //Wednesday
    [InlineData("2024-04-04")] //Thursday 
    [InlineData("2024-04-05")] //Friday 
    public void IsBusinessDay_GiveValidBusinessDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsBusinessDay();
        result.Should().Be(true);
    }

    [Theory]
    [InlineData("2024-04-06")] //Saturday
    [InlineData("2024-04-07")] //Sunday
    [InlineData("2024-01-01")] //Observed New Years Day
    [InlineData("2024-01-15")] //Observed Mlk Day 
    [InlineData("2024-02-19")] //Observed President Day
    [InlineData("2024-05-27")] //Observed Memorial Day
    [InlineData("2024-06-19")] //Observed Juneteenth 
    [InlineData("2024-07-04")] //Observed Independence Day
    [InlineData("2024-09-02")] //Observed Labor Day
    [InlineData("2024-10-14")] //Observed Columbus Day
    [InlineData("2024-11-11")] //Observed Veteran Day 
    [InlineData("2024-11-28")] //Observed Thanksgiving Day
    [InlineData("2024-12-25")] //Observed Christmas Day
    public void IsBusinessDay_GiveInValidBusinessDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsBusinessDay();
        result.Should().Be(false);
    }
}