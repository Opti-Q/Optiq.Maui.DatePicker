using Microsoft.Maui.Platform;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;


namespace Optiq.DatePicker.Platforms;
public static class TimePickerExtension
{
    public static void UpdateFormat(this MauiTimePicker mauiTimePicker, ITimePicker timePicker)
    {
        mauiTimePicker.SetTime(timePicker);
    }

    public static void UpdateTime(this MauiTimePicker mauiTimePicker, ITimePicker timePicker)
    {
        mauiTimePicker.SetTime(timePicker);
    }

    internal static void SetTime(this MauiTimePicker mauiTimePicker, ITimePicker timePicker)
    {
        var time = timePicker.Time;
        var format = timePicker.Format;

        mauiTimePicker.Text = time?.ToFormattedString(format);
    }
}
