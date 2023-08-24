#if IOS
using PlatformView = Optiq.DatePicker.Platforms.IOSTimePicker;
#elif ANDROID
using PlatformView = Microsoft.Maui.Platform.MauiTimePicker;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TimePicker;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;

namespace Optiq.DatePicker.Handlers.TimePicker;
public partial interface ITimePickerHandler : IViewHandler
{
    new ITimePicker VirtualView { get; }
    new PlatformView PlatformView { get; }
}
