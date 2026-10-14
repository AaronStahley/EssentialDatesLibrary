using EssentialDates.Extensions;
using FluentAssertions;
using Xunit;

namespace EssentialDates.Tests.Extensions;

public class FederalHolidaysDateExtensionTests
{
    [Theory]
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
    public void IsObservedFederalHoliday_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedFederalHoliday();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2019-01-05")] //Non Holiday in January 
    [InlineData("2019-02-12")] //Non Holiday in February
    [InlineData("2019-03-01")] //Non Holiday in March 
    [InlineData("2019-04-01")] //Non Holiday in April
    [InlineData("2019-05-01")] //Non Holiday in May
    [InlineData("2019-06-01")] //Non Holiday in June
    [InlineData("2019-07-01")] //Non Holiday in July 
    [InlineData("2019-08-01")] //Non Holiday in August 
    [InlineData("2019-09-01")] //Non Holiday in September 
    [InlineData("2019-10-01")] //Non Holiday in October
    [InlineData("2019-11-01")] //Non Holiday in November 
    [InlineData("2019-12-01")] //Non Holiday in December  
    public void IsObservedFederalHoliday_GivenInvalidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedFederalHoliday();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-01-01")] //Holiday falls on Tuesday
    [InlineData("2020-01-01")] //Holiday falls on Wednesday
    [InlineData("2021-01-01")] //Holiday falls on Friday
    [InlineData("2021-12-31")] //Holiday falls on Saturday so observed date is Friday 12-31
    [InlineData("2023-01-02")] //Holiday falls on Sunday so observed date is Monday 1-2
    [InlineData("2024-01-01")] //Holiday falls on Monday
    [InlineData("2025-01-01")] //Holiday falls on Wednesday
    [InlineData("2026-01-01")] //Holiday falls on Thursday
    [InlineData("2027-01-01")] //Holiday falls on Friday
    [InlineData("2027-12-31")] //Holiday falls on Saturday so observed date is Friday 12-31
    [InlineData("2029-01-01")] //Holiday falls on Monday 
    [InlineData("2030-01-01")] //Holiday falls on Tuesday
    public void IsObservedNewYearsDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedNewYearsDay(); 
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2024-12-31")] // Month = 12 Day = 31 DayOfWeek != Friday
    [InlineData("2024-05-31")] // Month != 12 Day = 31 Day of Week = Friday
    [InlineData("2024-12-27")] // Month = 12 Day != 31 Day of Week = Friday
    [InlineData("2024-11-28")] // Month != 12 Day != 31 Day of Week != Friday
    [InlineData("2022-01-01")] // Month = 1 Day = 1 DayOfWeek = Saturday
    [InlineData("2023-01-01")] // Month = 1 Day = 1 DayOfWeek = Sunday
    [InlineData("2024-06-01")] // Month != 1 Day = 1 DayOfWeek = Saturday
    [InlineData("2024-09-01")] // Month != 1 Day = 1 DayOfWeek = Sunday
    [InlineData("2024-01-06")] // Month = 1 Day != 1 DayOfWeek = Saturday
    [InlineData("2024-01-07")] // Month = 1 Day != 1 DayOfWeek = Sunday
    [InlineData("2024-02-03")] // Month != 1 Day != 1 DayOfWeek = Saturday
    [InlineData("2024-02-04")] // Month != 1 Day != 1 DayOfWeek = Sunday
    [InlineData("2024-01-02")] // Month = 1 Day = 2 DayOfWeek != Monday
    [InlineData("2024-09-02")] // Month != 1 Day = 2 Day of Week = Monday
    [InlineData("2024-01-08")] // Month = 1 Day != 2 Day of Week = Monday
    [InlineData("2024-02-13")] // Month != 1 Day != 2 Day of Week != Monday
    public void IsObservedNewYearsDay_GivenInvalidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedNewYearsDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-01-21")]
    [InlineData("2020-01-20")] 
    [InlineData("2021-01-18")] 
    [InlineData("2022-01-17")] 
    [InlineData("2023-01-16")] 
    [InlineData("2024-01-15")]
    [InlineData("2025-01-20")] 
    [InlineData("2026-01-19")]
    [InlineData("2027-01-18")] 
    [InlineData("2028-01-17")] 
    [InlineData("2029-01-15")] 
    [InlineData("2030-01-21")] 
    public void IsObservedMlkDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedMlkDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-01-2")] //First Monday
    [InlineData("2023-01-9")] //Second Monday
    [InlineData("2023-01-23")] //Fourth Monday
    [InlineData("2023-01-30")] //Fifth Monday
    [InlineData("2023-02-20")] //Third Monday in different month
    public void IsObservedMlkDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedMlkDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-02-18")]
    [InlineData("2020-02-17")]
    [InlineData("2021-02-15")]
    [InlineData("2022-02-21")]
    [InlineData("2023-02-20")]
    [InlineData("2024-02-19")]
    [InlineData("2025-02-17")]
    [InlineData("2026-02-16")]
    [InlineData("2027-02-15")]
    [InlineData("2028-02-21")]
    [InlineData("2029-02-19")]
    [InlineData("2030-02-18")]
    public void IsObservedPresidentDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedPresidentDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-02-06")] //First Monday
    [InlineData("2023-02-13")] //Second Monday
    [InlineData("2023-02-27")] //Fourth Monday
    [InlineData("2023-03-20")] //Third Monday in different month
    public void IsObservedPresidentDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedPresidentDay();
        result.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("2019-05-27")]
    [InlineData("2020-05-25")]
    [InlineData("2021-05-31")]
    [InlineData("2022-05-30")]
    [InlineData("2023-05-29")]
    [InlineData("2024-05-27")]
    [InlineData("2025-05-26")]
    [InlineData("2026-05-25")]
    [InlineData("2027-05-31")]
    [InlineData("2028-05-29")]
    [InlineData("2029-05-28")]
    [InlineData("2030-05-27")]
    public void IsObservedMemorialDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedMemorialDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-05-01")] //First Monday
    [InlineData("2023-05-08")] //Second Monday
    [InlineData("2023-05-15")] //Third Monday
    [InlineData("2023-05-22")] //Fourth Monday
    [InlineData("2023-06-26")] //Last monday in a different month
    public void IsObservedMemorialDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedMemorialDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2021-6-18")] //Juneteenth officially became a federal holiday in 2021. Falls on Saturday so observed date is Friday 6-18
    [InlineData("2022-6-20")] // Falls on Sunday so observed date is Monday 6-20
    [InlineData("2023-6-19")] //Holiday falls on Monday
    [InlineData("2024-6-19")] //Holiday falls on Wednesday 
    [InlineData("2025-6-19")] //Holiday falls on Thursday
    [InlineData("2026-6-19")] //Holiday falls on Friday
    [InlineData("2027-6-18")] //Falls on Saturday so observed date is Friday 6-18
    [InlineData("2028-6-19")] //Holiday falls on Monday
    [InlineData("2029-6-19")] //Holiday falls on Tuesday
    [InlineData("2030-6-19")] //Holiday falls on Wednesday
    public void IsObservedJuneteenth_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedJuneteenth();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2024-06-18")] // Month = 06 Day = 18 DayOfWeek != Friday
    [InlineData("2024-10-18")] // Month != 06 Day = 18 Day of Week = Friday
    [InlineData("2024-06-07")] // Month = 06 Day != 18 Day of Week = Friday
    [InlineData("2024-07-17")] // Month != 06 Day != 18 Day of Week != Friday
    [InlineData("2021-06-19")] // Month = 06 Day = 19 DayOfWeek = Saturday
    [InlineData("2022-06-19")] // Month = 06 Day = 19 DayOfWeek = Sunday
    [InlineData("2024-10-19")] // Month != 06 Day = 19 DayOfWeek = Saturday
    [InlineData("2024-05-19")] // Month != 06 Day = 19 DayOfWeek = Sunday
    [InlineData("2024-06-08")] // Month = 06 Day != 19 DayOfWeek = Saturday
    [InlineData("2024-06-09")] // Month = 06 Day != 19 DayOfWeek = Sunday
    [InlineData("2024-01-06")] // Month != 06 Day != 19 DayOfWeek = Saturday
    [InlineData("2024-01-07")] // Month != 06 Day != 19 DayOfWeek = Sunday
    [InlineData("2024-06-20")] // Month = 06 Day = 20 DayOfWeek != Monday
    [InlineData("2024-05-20")] // Month != 06 Day = 20 Day of Week = Monday
    [InlineData("2024-06-17")] // Month = 06 Day != 20 Day of Week = Monday
    [InlineData("2024-02-21")] // Month != 06 Day != 20 Day of Week != Monday
    public void IsObservedJuneteenth_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedJuneteenth();
        result.Should().BeFalse();
    }

    
    [Theory]
    [InlineData("2019-07-04")] //Holiday falls on Thursday
    [InlineData("2020-07-03")] // Falls on Saturday so observed date is Friday 7-3
    [InlineData("2021-07-05")] // Falls on Sunday so observed date is Monday 7-5
    [InlineData("2022-07-04")] //Holiday falls on Monday
    [InlineData("2023-07-04")] //Holiday falls on Tuesday
    [InlineData("2024-07-04")] //Holiday falls on Thursday
    [InlineData("2025-07-04")] //Holiday falls on Friday
    [InlineData("2026-07-03")] // Falls on Saturday so observed date is Friday 7-3
    [InlineData("2027-07-05")] // Falls on Sunday so observed date is Monday 7-5
    [InlineData("2028-07-04")] //Holiday falls on Tuesday
    [InlineData("2029-07-04")] //Holiday falls on Wednesday
    [InlineData("2030-07-04")] //Holiday falls on Thursday
    public void IsObservedIndependenceDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedIndependenceDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2024-07-03")] // Month = 07 Day = 03 DayOfWeek != Friday
    [InlineData("2024-05-03")] // Month != 07 Day = 03 Day of Week = Friday
    [InlineData("2024-07-12")] // Month = 07 Day != 03 Day of Week = Friday
    [InlineData("2024-08-20")] // Month != 07 Day != 03 Day of Week != Friday
    [InlineData("2020-07-04")] // Month = 07 Day = 04 DayOfWeek = Saturday
    [InlineData("2021-07-04")] // Month = 07 Day = 04 DayOfWeek = Sunday
    [InlineData("2024-05-04")] // Month != 07 Day = 04 DayOfWeek = Saturday
    [InlineData("2024-08-04")] // Month != 07 Day = 04 DayOfWeek = Sunday
    [InlineData("2024-07-06")] // Month = 07 Day != 04 DayOfWeek = Saturday
    [InlineData("2024-07-07")] // Month = 07 Day != 04 DayOfWeek = Sunday
    [InlineData("2024-01-06")] // Month != 07 Day != 04 DayOfWeek = Saturday
    [InlineData("2024-01-07")] // Month != 07 Day != 04 DayOfWeek = Sunday
    [InlineData("2024-07-05")] // Month = 07 Day = 05 DayOfWeek != Monday
    [InlineData("2024-08-05")] // Month != 07 Day = 05 Day of Week = Monday
    [InlineData("2024-07-08")] // Month = 07 Day != 05 Day of Week = Monday
    [InlineData("2024-01-10")] // Month != 07 Day != 05 Day of Week != Monday
    public void IsObservedIndependenceDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedIndependenceDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-09-02")]
    [InlineData("2020-09-07")]
    [InlineData("2021-09-06")]
    [InlineData("2022-09-05")]
    [InlineData("2023-09-04")]
    [InlineData("2024-09-02")]
    [InlineData("2025-09-01")]
    [InlineData("2026-09-07")]
    [InlineData("2027-09-06")]
    [InlineData("2028-09-04")]
    [InlineData("2029-09-03")]
    [InlineData("2030-09-02")]
    public void IsObservedLaborDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedLaborDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-09-11")] //Second Monday
    [InlineData("2023-09-18")] //Third Monday
    [InlineData("2023-09-25")] //Fourth Monday
    [InlineData("2023-10-02")] //First monday in a different month
    public void IsObservedLaborDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedLaborDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-10-14")]
    [InlineData("2020-10-12")]
    [InlineData("2021-10-11")]
    [InlineData("2022-10-10")]
    [InlineData("2023-10-09")]
    [InlineData("2024-10-14")]
    [InlineData("2025-10-13")]
    [InlineData("2026-10-12")]
    [InlineData("2027-10-11")]
    [InlineData("2028-10-09")]
    [InlineData("2029-10-08")]
    [InlineData("2030-10-14")]
    public void IsObservedColumbusDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedColumbusDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-10-02")] //First Monday
    [InlineData("2023-10-16")] //Third Monday
    [InlineData("2023-10-23")] //Fourth Monday
    [InlineData("2023-10-30")] //Fifth Monday
    [InlineData("2023-11-13")] //Second monday in a different month
    public void IsObservedColumbusDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedColumbusDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-11-11")] //Holiday falls on Monday
    [InlineData("2020-11-11")] //Holiday falls on Wednesday
    [InlineData("2021-11-11")] //Holiday falls on Thursday
    [InlineData("2022-11-11")] //Holiday falls on Friday
    [InlineData("2023-11-10")] //Falls on Saturday so observed date is Friday on 11-10
    [InlineData("2024-11-11")] //Holiday falls on Monday
    [InlineData("2025-11-11")] //Holiday falls on Tuesday
    [InlineData("2026-11-11")] //Holiday falls on Wednesday
    [InlineData("2027-11-11")] //Holiday falls on Thursday
    [InlineData("2028-11-10")] //Falls on Saturday so observed date is Friday on 11-10
    [InlineData("2029-11-12")] //Falls on Sunday so observed date is Monday on 11-12
    [InlineData("2030-11-11")] //Holiday falls on Monday
    public void IsObservedVeteranDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedVeteranDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2022-11-10")] // Month = 11 Day = 10 DayOfWeek != Friday
    [InlineData("2024-05-10")] // Month != 11 Day = 10 Day of Week = Friday
    [InlineData("2024-11-08")] // Month = 11 Day != 10 Day of Week = Friday
    [InlineData("2024-01-01")] // Month != 11 Day != 10 Day of Week != Friday
    [InlineData("2023-11-11")] // Month = 11 Day = 11 DayOfWeek = Saturday
    [InlineData("2029-11-11")] // Month = 11 Day = 11 DayOfWeek = Sunday
    [InlineData("2024-05-11")] // Month != 11 Day = 11 DayOfWeek = Saturday
    [InlineData("2024-08-11")] // Month != 11 Day = 11 DayOfWeek = Sunday
    [InlineData("2024-11-09")] // Month = 11 Day != 11 DayOfWeek = Saturday
    [InlineData("2024-11-17")] // Month = 11 Day != 11 DayOfWeek = Sunday
    [InlineData("2024-01-13")] // Month != 11 Day != 11 DayOfWeek = Saturday
    [InlineData("2024-01-14")] // Month != 11 Day != 11 DayOfWeek = Sunday
    [InlineData("2024-11-12")] // Month = 11 Day = 12 DayOfWeek != Monday
    [InlineData("2024-08-12")] // Month != 11 Day = 12 Day of Week = Monday
    [InlineData("2024-11-04")] // Month = 11 Day != 12 Day of Week = Monday
    [InlineData("2024-01-09")] // Month != 11 Day != 12 Day of Week != Monday
    public void IsObservedVeteranDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedVeteranDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-11-28")]
    [InlineData("2020-11-26")]
    [InlineData("2021-11-25")]
    [InlineData("2022-11-24")]
    [InlineData("2023-11-23")]
    [InlineData("2024-11-28")]
    [InlineData("2025-11-27")]
    [InlineData("2026-11-26")]
    [InlineData("2027-11-25")]
    [InlineData("2028-11-23")]
    [InlineData("2029-11-22")]
    [InlineData("2030-11-28")]
    public void IsObservedThanksgivingDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedThanksgivingDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023-11-02")] //First Thursday
    [InlineData("2023-11-09")] //Second Thursday
    [InlineData("2023-11-16")] //Third Thursday
    [InlineData("2023-11-30")] //Fifth Thursday
    [InlineData("2023-12-28")] //Fourth Thursday in a different month
    public void IsObservedThanksgivingDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedThanksgivingDay();
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("2019-12-25")] //Holiday falls on Wednesday
    [InlineData("2020-12-25")] //Holiday falls on Friday
    [InlineData("2021-12-24")] //Falls on Saturday so observed date is Friday on 12-24
    [InlineData("2022-12-26")] //Falls on Sunday so observed date is Monday on 12-26
    [InlineData("2023-12-25")] //Holiday falls on Monday
    [InlineData("2024-12-25")] //Holiday falls on Wednesday
    [InlineData("2025-12-25")] //Holiday falls on Thursday
    [InlineData("2026-12-25")] //Holiday falls on Friday
    [InlineData("2027-12-24")] //Falls on Saturday so observed date is Friday on 12-24
    [InlineData("2028-12-25")] //Holiday falls on Monday
    [InlineData("2029-12-25")] //Holiday falls on Tuesday
    [InlineData("2030-12-25")] //Holiday falls on Wednesday
    public void IsObservedChristmasDay_GivenValidDates_ShouldReturnTrue(DateTime testDate)
    {
        var result = testDate.IsObservedChristmasDay();
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2024-12-24")] // Month = 12 Day = 24 DayOfWeek != Friday
    [InlineData("2024-05-24")] // Month != 12 Day = 24 Day of Week = Friday
    [InlineData("2024-12-20")] // Month = 12 Day != 24 Day of Week = Friday
    [InlineData("2024-01-16")] // Month != 12 Day != 24 Day of Week != Friday
    [InlineData("2021-12-25")] // Month = 12 Day = 25 DayOfWeek = Saturday
    [InlineData("2022-12-25")] // Month = 12 Day = 25 DayOfWeek = Sunday
    [InlineData("2024-05-25")] // Month != 12 Day = 25 DayOfWeek = Saturday
    [InlineData("2024-08-25")] // Month != 12 Day = 25 DayOfWeek = Sunday
    [InlineData("2024-12-21")] // Month = 12 Day != 25 DayOfWeek = Saturday
    [InlineData("2024-12-22")] // Month = 12 Day != 25 DayOfWeek = Sunday
    [InlineData("2024-01-13")] // Month != 12 Day != 25 DayOfWeek = Saturday
    [InlineData("2024-01-14")] // Month != 12 Day != 25 DayOfWeek = Sunday
    [InlineData("2024-12-26")] // Month = 12 Day = 26 DayOfWeek != Monday
    [InlineData("2024-02-26")] // Month != 12 Day = 26 Day of Week = Monday
    [InlineData("2024-12-23")] // Month = 12 Day != 26 Day of Week = Monday
    [InlineData("2024-01-09")] // Month != 12 Day != 26 Day of Week != Monday
    public void IsObservedChristmasDay_GivenInValidDates_ShouldReturnFalse(DateTime testDate)
    {
        var result = testDate.IsObservedChristmasDay();
        result.Should().BeFalse();
    }
}