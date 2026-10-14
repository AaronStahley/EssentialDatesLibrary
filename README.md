# EssentialDates

[![Build](https://github.com/AaronStahley/EssentialDatesLibrary/actions/workflows/ci.yml/badge.svg)](https://github.com/AaronStahley/EssentialDatesLibrary/actions/workflows/ci.yml)

`DateTime` extension methods for U.S. federal holidays and business day calculations. Targets .NET 8.

## Usage

```csharp
using EssentialDates.Extensions;

var date = new DateTime(2024, 7, 4);

date.IsObservedFederalHoliday();  // true
date.IsBusinessDay();             // false
date.NextBusinessDay();           // 2024-07-05

new DateTime(2024, 11, 28).IsObservedThanksgivingDay(); // true
```

## Business days

- `IsBusinessDay()`: `true` when the date is not a weekend and not an observed federal holiday.
- `NextBusinessDay()`: returns the next business day after the date.

## Federal holidays

`IsObservedFederalHoliday()` checks every holiday below. Each holiday also has its own method.

| Holiday | Method | Rule |
|---|---|---|
| New Year's Day | `IsObservedNewYearsDay()` | January 1 |
| Martin Luther King Jr. Day | `IsObservedMlkDay()` | Third Monday in January |
| Presidents Day | `IsObservedPresidentDay()` | Third Monday in February |
| Memorial Day | `IsObservedMemorialDay()` | Last Monday in May |
| Juneteenth | `IsObservedJuneteenth()` | June 19 |
| Independence Day | `IsObservedIndependenceDay()` | July 4 |
| Labor Day | `IsObservedLaborDay()` | First Monday in September |
| Columbus Day | `IsObservedColumbusDay()` | Second Monday in October |
| Veterans Day | `IsObservedVeteranDay()` | November 11 |
| Thanksgiving Day | `IsObservedThanksgivingDay()` | Fourth Thursday in November |
| Christmas Day | `IsObservedChristmasDay()` | December 25 |

### Observed dates

Fixed-date holidays follow the federal observance rule: a holiday on a **Saturday** is observed the preceding **Friday**, and a holiday on a **Sunday** is observed the following **Monday**. For example, when January 1 is a Saturday, New Year's Day is observed on December 31 of the previous year.

### Limitations

- Juneteenth became a federal holiday in 2021. The method does not check the year, so it also returns `true` for June 19 in earlier years.
- One-off closures (such as Inauguration Day or holidays declared by executive order) are not included.

## Building and testing

```bash
cd src
dotnet build
dotnet test
```

## License

[MIT](LICENSE)
