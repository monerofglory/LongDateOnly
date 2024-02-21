# LongDateOnly
LongDateOnly is a .NET library that extends beyond the 9999-year limit of the native DateOnly object. If you’ve ever encountered the limitations of the built-in DateOnly type when dealing with dates beyond the year 9999, this package is here to help. With LongDateOnly, you can work seamlessly with dates spanning centuries without any hiccups.

## Features
1. Extended Range: Unlike the standard DateOnly type, which is limited to dates up to the year 9999, LongDateOnly allows you to represent dates from ancient history to the distant future.
2. Precision: LongDateOnly maintains precision down to the day level, making it suitable for scenarios where you need to work with dates without considering time components.
3. DateOnly compatibility: LongDateOnly allows for comparisons and conversions to DateOnly and has extensive testing to ensure 1:1 results for all built-in methods.

## Installation
You can install LongDateOnly via NuGet Package Manager or .NET CLI:

`dotnet add package LongDateOnly`

## Usage
### Creating a Long Date
C#

```
using System;
using LongDateOnlyLib

// Create a LongDateOnly instance
LongDateOnly myLongDate = new LongDateOnly(12, 1500, 1, 1);

// Access individual components
int decamillenium = myLongDate.Decamillenium; // 12
int year = myLongDate.Year; // 1500
int month = myLongDate.Month; // 1
int day = myLongDate.Day; // 1

// Perform arithmetic
myLongDate = myLongDate.AddDecamillenium(55);

// Output
Console.WriteLine(myLongDate.ToString());
```

## Feedback
Your feedback is valuable! If you encounter any issues or have suggestions for improvement, please feel free to open an issue on the GitHub repository.

## License
This project is licensed under the MIT License.
