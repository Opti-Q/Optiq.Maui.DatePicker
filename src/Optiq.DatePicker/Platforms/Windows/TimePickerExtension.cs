using Microsoft.Maui.Platform;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;
using WBrush = Microsoft.UI.Xaml.Media.Brush;


namespace Optiq.DatePicker.Platforms;
public static class TimePickerExtension
{
    public static void UpdateTime(this Microsoft.UI.Xaml.Controls.TimePicker nativeTimePicker, ITimePicker timePicker)
    {
        // TODO:
        if (timePicker.Time != null)
        {
            nativeTimePicker.Time = (TimeSpan)timePicker.Time;
        }

        if (timePicker.Format?.Contains('H', StringComparison.Ordinal) == true)
        {
            nativeTimePicker.ClockIdentifier = "24HourClock";
        }
        else
        {
            nativeTimePicker.ClockIdentifier = "12HourClock";
        }
    }

    public static void UpdateCharacterSpacing(this Microsoft.UI.Xaml.Controls.TimePicker platformTimePicker, ITimePicker timePicker)
    {
        platformTimePicker.CharacterSpacing = timePicker.CharacterSpacing.ToEm();
    }

    public static void UpdateFont(this Microsoft.UI.Xaml.Controls.TimePicker platformTimePicker, ITimePicker timePicker, IFontManager fontManager) =>
        platformTimePicker.UpdateFont(timePicker.Font, fontManager);

    public static void UpdateTextColor(this Microsoft.UI.Xaml.Controls.TimePicker platformTimePicker, ITimePicker timePicker)
    {
        Color textColor = timePicker.TextColor;

        WBrush? platformBrush = textColor?.ToPlatform();

        if (platformBrush == null)
        {
            platformTimePicker.Resources.RemoveKeys(TextColorResourceKeys);
            platformTimePicker.ClearValue(Microsoft.UI.Xaml.Controls.TimePicker.ForegroundProperty);
        }
        else
        {
            platformTimePicker.Resources.SetValueForAllKey(TextColorResourceKeys, platformBrush);
            platformTimePicker.Foreground = platformBrush;
        }

        platformTimePicker.RefreshThemeResources();
    }

    // ResourceKeys controlling the foreground color of the TimePicker.
    // https://docs.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.controls.timepicker?view=windows-app-sdk-1.1
    static readonly string[] TextColorResourceKeys =
    {
            "TimePickerButtonForeground",
            "TimePickerButtonForegroundPointerOver",
            "TimePickerButtonForegroundPressed",
            "TimePickerButtonForegroundDisabled"
        };

    // TODO NET8 add to public API
    internal static void UpdateBackground(this Microsoft.UI.Xaml.Controls.TimePicker platformTimePicker, ITimePicker timePicker)
    {
        var brush = timePicker?.Background?.ToPlatform();

        if (brush is null)
        {
            platformTimePicker.Resources.RemoveKeys(BackgroundColorResourceKeys);
            platformTimePicker.ClearValue(Microsoft.UI.Xaml.Controls.TimePicker.BackgroundProperty);
        }
        else
        {
            platformTimePicker.Resources.SetValueForAllKey(BackgroundColorResourceKeys, brush);
            platformTimePicker.Background = brush;
        }

        platformTimePicker.RefreshThemeResources();
    }

    static readonly string[] BackgroundColorResourceKeys =
    {
            "TimePickerButtonBackground",
            "TimePickerButtonBackgroundPointerOver",
            "TimePickerButtonBackgroundPressed",
            "TimePickerButtonBackgroundDisabled",
            "TimePickerButtonBackgroundFocused",
        };

}
