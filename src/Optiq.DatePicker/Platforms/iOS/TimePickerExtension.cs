using Foundation;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;


namespace Optiq.DatePicker.Platforms;
public static class TimePickerExtension
{
    public static void UpdateFormat(this MauiTimePicker mauiTimePicker, ITimePicker timePicker)
    {
        mauiTimePicker.UpdateTime(timePicker, null);
    }

    public static void UpdateFormat(this UIDatePicker picker, ITimePicker timePicker)
    {
        picker.UpdateTime(timePicker);
    }

    public static void UpdateFormat(this MauiTimePicker mauiTimePicker, ITimePicker timePicker, UIDatePicker? picker)
    {
        mauiTimePicker.UpdateTime(timePicker, picker);
    }

    public static void UpdateTime(this MauiTimePicker mauiTimePicker, ITimePicker timePicker)
    {
        mauiTimePicker.UpdateTime(timePicker, null);
    }

    public static void UpdateTime(this UIDatePicker picker, ITimePicker timePicker)
    {
        if (picker != null && timePicker.Time != null)
            picker.Date = new DateTime(1, 1, 1).Add((TimeSpan)timePicker.Time).ToNSDate();
    }

    public static void UpdateTime(this MauiTimePicker mauiTimePicker, ITimePicker timePicker, UIDatePicker? picker)
    {
        picker?.UpdateTime(timePicker);

        var cultureInfo = Culture.CurrentCulture;

        if (string.IsNullOrEmpty(timePicker.Format))
        {
            NSLocale locale = new NSLocale(cultureInfo.TwoLetterISOLanguageName);

            if (picker != null)
                picker.Locale = locale;
        }

        var time = timePicker.Time;
        var format = timePicker.Format;

        mauiTimePicker.Text = time?.ToFormattedString(format, cultureInfo);

        if (format != null)
        {
            if (format.IndexOf("H", StringComparison.Ordinal) != -1)
            {
                var ci = new CultureInfo("de-DE");
                NSLocale locale = new NSLocale(ci.TwoLetterISOLanguageName);

                if (picker != null)
                    picker.Locale = locale;
            }
            else if (format.IndexOf("h", StringComparison.Ordinal) != -1)
            {
                var ci = new CultureInfo("en-US");
                NSLocale locale = new NSLocale(ci.TwoLetterISOLanguageName);

                if (picker != null)
                    picker.Locale = locale;
            }
        }

        mauiTimePicker.UpdateCharacterSpacing(timePicker);
    }

    public static void UpdateTextAlignment(this MauiTimePicker textField, ITimePicker timePicker)
    {
        // TODO: Update TextAlignment based on the EffectiveFlowDirection property.
    }
}
