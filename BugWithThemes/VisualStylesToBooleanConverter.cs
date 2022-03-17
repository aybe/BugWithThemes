using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Syncfusion.SfSkinManager;

namespace BugWithThemes;

[ValueConversion(typeof(VisualStyles), typeof(bool))]
internal sealed class VisualStylesToBooleanConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var unsetValue = DependencyProperty.UnsetValue;

        if (values.Length < 2)
            return unsetValue;

        if (values[0] is not ApplicationTheme theme)
            return unsetValue;

        if (values[1] is not DependencyObject dependencyObject)
            return unsetValue;

        var style = SfSkinManager.GetVisualStyle(dependencyObject);

        var equals = Equals(theme.Styles, style);

        return equals;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}