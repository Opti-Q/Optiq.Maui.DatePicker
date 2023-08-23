using Foundation;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Optiq.DatePicker.Platforms;
public class IOSTimePicker : MauiTimePicker
{
    public IOSTimePicker(Action dateSelected) : base(dateSelected)
    {
    }

    public void UpdateTime(TimeSpan? time)
    {
        if (time != null)
        {
            Picker.Date = new DateTime(1, 1, 1, time.Value.Hours, time.Value.Minutes, time.Value.Seconds).ToNSDate();
        }
        else
        {
            Picker.Date = new DateTime(1, 1, 1, 0, 0, 0).ToNSDate();
        }
    }
}


