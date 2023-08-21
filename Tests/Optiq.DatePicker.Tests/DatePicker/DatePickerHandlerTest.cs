﻿using System.ComponentModel;
using Optiq.DatePicker.Handlers;
using Xunit;

namespace Optiq.DatePicker.Tests.DatePicker;

public partial class DatePickerHandlerTest 
{
    [Fact(DisplayName = "Date Initializes Correctly")]
    public async Task DateInitializesCorrectly()
    {
        var datePicker = new DatePickerStub();

        datePicker.Date = DateTime.Today;

        await ValidatePropertyInitValue(datePicker, () => datePicker.Date, GetNativeDate, datePicker.Date);
    }

    [Fact(DisplayName = "TextColor Initializes Correctly")]
    public async Task TextColorInitializesCorrectly()
    {
        var datePicker = new DatePickerStub()
        {
            Date = DateTime.Today,
            TextColor = Colors.Yellow
        };

        await ValidatePropertyInitValue(datePicker, () => datePicker.TextColor, GetNativeTextColor,
            datePicker.TextColor);
    }

    [Fact(DisplayName = "Null Text Color Doesn't Crash")]
    public async Task NullTextColorDoesntCrash()
    {
        var datePicker = new DatePickerStub()
        {
            Date = DateTime.Today,
            TextColor = null
        };

        await CreateHandlerAsync(datePicker);
    }

}
