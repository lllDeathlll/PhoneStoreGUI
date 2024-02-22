using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace PhoneStoreGUI.Converters;

public class ReleaseDateConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not DateOnly dateOnly) return null;
        Console.WriteLine(dateOnly);
        return new DateTimeOffset(dateOnly.Year, dateOnly.Month, dateOnly.Day, 0, 0, 0, TimeSpan.Zero);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not DateTimeOffset dateTimeOffset) return null;
        Console.WriteLine(dateTimeOffset);
        return new DateOnly(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day);
    }
}