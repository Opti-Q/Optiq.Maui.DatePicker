﻿#if IOS && !MACCATALYST
using PlatformView = Optiq.DatePicker.Platforms.IOSDatePicker;
#elif ANDROID
using PlatformView = Optiq.DatePicker.Platforms.AndroidDatePicker;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.CalendarDatePicker;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
using IDatePicker = Optiq.DatePicker.Core.Interfaces.IDatePicker;

namespace Optiq.DatePicker.Handlers.DatePicker;

public partial interface IDatePickerHandler : IViewHandler
{
    new IDatePicker VirtualView { get; }
    new PlatformView PlatformView { get; }
}