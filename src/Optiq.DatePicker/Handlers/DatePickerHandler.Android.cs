using Android.App;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Optiq.DatePicker.Platforms;
using IDatePicker = Optiq.DatePicker.Core.IDatePicker;

namespace Optiq.DatePicker.Handlers;

public partial class DatePickerHandler : ViewHandler<IDatePicker, MauiDatePicker>
{
    DatePickerDialog? _dialog;

    protected override MauiDatePicker CreatePlatformView()
    {
        var datePicker = new MauiDatePicker(Context)
        {
            ShowPicker = ShowPickerDialog,
            HidePicker = HidePickerDialog
        };

        var date = VirtualView?.Date;

        if (date != null)
            _dialog = CreateDatePickerDialog(date.Value.Year, date.Value.Month, date.Value.Day);

        return datePicker;
    }

    internal DatePickerDialog? DatePickerDialog
    {
        get { return _dialog; }
    }

    protected override void ConnectHandler(MauiDatePicker platformView)
    {
        base.ConnectHandler(platformView);
        platformView.ViewAttachedToWindow += OnViewAttachedToWindow;
        platformView.ViewDetachedFromWindow += OnViewDetachedFromWindow;

        if (platformView.IsAttachedToWindow)
            OnViewAttachedToWindow();
    }

    void OnViewDetachedFromWindow(object? sender = null, Android.Views.View.ViewDetachedFromWindowEventArgs? e = null)
    {
        // I tested and this is called when an activity is destroyed
        DeviceDisplay.MainDisplayInfoChanged -= OnMainDisplayInfoChanged;
    }

    void OnViewAttachedToWindow(object? sender = null, Android.Views.View.ViewAttachedToWindowEventArgs? e = null)
    {
        DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
    }

    protected override void DisconnectHandler(MauiDatePicker platformView)
    {
        if (_dialog != null)
        {
            _dialog.Hide();
            _dialog.Dispose();
            _dialog = null;
        }

        platformView.ViewAttachedToWindow -= OnViewAttachedToWindow;
        platformView.ViewDetachedFromWindow -= OnViewDetachedFromWindow;
        OnViewDetachedFromWindow();

        base.DisconnectHandler(platformView);
    }

    protected virtual DatePickerDialog CreateDatePickerDialog(int year, int month, int day)
    {
        var dialog = new DatePickerDialog(Context!, (o, e) =>
        {
            if (VirtualView != null)
            {
                VirtualView.Date = e.Date;
            }
        }, year, month, day);

        return dialog;
    }

    public static partial void MapBackground(IDatePickerHandler handler, IDatePicker datePicker)
    {
        handler.PlatformView?.UpdateBackground(datePicker);
    }

    public static partial void MapFormat(IDatePickerHandler handler, IDatePicker datePicker)
    {
        handler.PlatformView.UpdateFormat(datePicker);
    }

    public static partial void MapDate(IDatePickerHandler handler, IDatePicker datePicker)
    {
        handler.PlatformView?.UpdateFormat(datePicker);
    }

    public static partial void MapMinimumDate(IDatePickerHandler handler, IDatePicker datePicker)
    {
        if (handler is DatePickerHandler platformHandler)
            DatePickerExtenstion.UpdateMinimumDate(handler.PlatformView, datePicker, platformHandler._dialog);
    }

    public static partial void MapMaximumDate(IDatePickerHandler handler, IDatePicker datePicker)
    {
        if (handler is DatePickerHandler platformHandler)
            DatePickerExtenstion.UpdateMaximumDate(handler.PlatformView, datePicker, platformHandler._dialog);
    }

    public static partial void MapCharacterSpacing(IDatePickerHandler handler, IDatePicker datePicker)
    {
        handler.PlatformView?.UpdateCharacterSpacing(datePicker);
    }

    public static partial void MapFont(IDatePickerHandler handler, IDatePicker datePicker)
    {
        var fontManager = handler.GetRequiredService<IFontManager>();

        handler.PlatformView?.UpdateFont(datePicker, fontManager);
    }

    public static partial void MapTextColor(IDatePickerHandler handler, IDatePicker datePicker)
    {
        //if (handler is DatePickerHandler platformHandler)
        //    handler.PlatformView?.UpdateTextColor(datePicker);
    }

    void ShowPickerDialog()
    {
        if (VirtualView == null)
            return;

        if (_dialog != null && _dialog.IsShowing)
            return;

        var date = VirtualView.Date;
        if (date != null)
            ShowPickerDialog(date.Value.Year, date.Value.Month, date.Value.Day);
        else
            ShowPickerDialog(0, 0, 0);
    }

    void ShowPickerDialog(int year, int month, int day)
    {
        if (_dialog == null)
            _dialog = CreateDatePickerDialog(year, month, day);
        else
        {
            EventHandler? setDateLater = null;
            setDateLater = (sender, e) =>
            {
                _dialog!.UpdateDate(year, month, day);
                _dialog.ShowEvent -= setDateLater;
            };
            _dialog.ShowEvent += setDateLater;
        }

        _dialog.Show();
    }

    void HidePickerDialog()
    {
        _dialog?.Hide();
    }

    void OnMainDisplayInfoChanged(object? sender, DisplayInfoChangedEventArgs e)
    {
        DatePickerDialog? currentDialog = _dialog;

        if (currentDialog != null && currentDialog.IsShowing)
        {
            currentDialog.Dismiss();

            ShowPickerDialog(currentDialog.DatePicker.Year, currentDialog.DatePicker.Month,
                currentDialog.DatePicker.DayOfMonth);
        }
    }
}
