using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using Optiq.DatePicker.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;


namespace Optiq.DatePicker.Handlers.TimePicker;
public partial class TimePickerHandler : ViewHandler<ITimePicker, Microsoft.UI.Xaml.Controls.TimePicker>
{
    protected override Microsoft.UI.Xaml.Controls.TimePicker CreatePlatformView() => new Microsoft.UI.Xaml.Controls.TimePicker();

    protected override void ConnectHandler(Microsoft.UI.Xaml.Controls.TimePicker platformView)
    {
        platformView.TimeChanged += OnControlTimeChanged;
    }

    protected override void DisconnectHandler(Microsoft.UI.Xaml.Controls.TimePicker platformView)
    {
        platformView.TimeChanged -= OnControlTimeChanged;
    }

    public static void MapFormat(ITimePickerHandler handler, ITimePicker timePicker)
    {
        handler.PlatformView.UpdateTime(timePicker);
    }

    public static void MapTime(ITimePickerHandler handler, ITimePicker timePicker)
    {
        handler.PlatformView.UpdateTime(timePicker);
    }

    public static void MapCharacterSpacing(ITimePickerHandler handler, ITimePicker timePicker)
    {
        handler.PlatformView.UpdateCharacterSpacing(timePicker);
    }

    public static void MapFont(ITimePickerHandler handler, ITimePicker timePicker)
    {
        var fontManager = handler.GetRequiredService<IFontManager>();

        handler.PlatformView.UpdateFont(timePicker, fontManager);
    }

    public static void MapTextColor(ITimePickerHandler handler, ITimePicker timePicker)
    {
        handler.PlatformView.UpdateTextColor(timePicker);
    }

    // TODO NET8 make public
    internal static void MapBackground(ITimePickerHandler handler, ITimePicker timePicker)
    {
        handler.PlatformView?.UpdateBackground(timePicker);
    }

    void OnControlTimeChanged(object? sender, TimePickerValueChangedEventArgs e)
    {
        if (VirtualView != null)
        {
            VirtualView.Time = e.NewTime;
            VirtualView.InvalidateMeasure();
        }
    }
}
