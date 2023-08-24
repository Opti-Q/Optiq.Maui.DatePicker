using Android.App;
using Microsoft.Maui.Platform;
using IDatePicker = Optiq.DatePicker.Core.Interfaces.IDatePicker;

namespace Optiq.DatePicker.Platforms;

public static class DatePickerExtenstion
{
    public static void UpdateFormat(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        platformDatePicker.SetText(datePicker);
    }

    public static void UpdateDate(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        platformDatePicker.SetText(datePicker);
    }

    public static void UpdateTextColor(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        var textColor = datePicker.TextColor;

        if (textColor != null)
        {
                platformDatePicker.SetTextColor(textColor.ToPlatform());
        }

    }

    public static void UpdateMinimumDate(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        platformDatePicker.UpdateMinimumDate(datePicker, null);
    }

    public static void UpdateMinimumDate(this AndroidDatePicker platformDatePicker, IDatePicker datePicker, DatePickerDialog? datePickerDialog)
    {
        if (datePickerDialog != null)
        {
            datePickerDialog.DatePicker.MinDate = (long)datePicker.MinimumDate.ToUniversalTime().Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
        }
    }

    public static void UpdateMaximumDate(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        platformDatePicker.UpdateMinimumDate(datePicker, null);
    }

    public static void UpdateMaximumDate(this AndroidDatePicker platformDatePicker, IDatePicker datePicker, DatePickerDialog? datePickerDialog)
    {
        if (datePickerDialog != null)
        {
            datePickerDialog.DatePicker.MaxDate = (long)datePicker.MaximumDate.ToUniversalTime().Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
        }
    }
    internal static void SetText(this AndroidDatePicker platformDatePicker, IDatePicker datePicker)
    {
        platformDatePicker.Text = datePicker.Date?.ToString(datePicker.Format);
    }
}