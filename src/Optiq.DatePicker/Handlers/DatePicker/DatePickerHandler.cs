﻿#if IOS && !MACCATALYST
using PlatformView = Optiq.DatePicker.Platforms.IOSDatePicker;
#elif ANDROID
using PlatformView = Optiq.DatePicker.Platforms.AndroidDatePicker;
#elif WINDOWS
using IPropertyMapper = Microsoft.Maui.IPropertyMapper;
using PlatformView = Microsoft.UI.Xaml.Controls.CalendarDatePicker;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
using IDatePicker = Optiq.DatePicker.Core.Interfaces.IDatePicker;
using Microsoft.Maui.Handlers;
using Optiq.DatePicker.Handlers.DatePicker;

namespace Optiq.DatePicker.Handlers.DatePicker;

public partial class DatePickerHandler : IDatePickerHandler
{
    public static IPropertyMapper<IDatePicker, IDatePickerHandler> Mapper =
        new PropertyMapper<IDatePicker, IDatePickerHandler>(ViewHandler.ViewMapper)
        {
#if ANDROID || WINDOWS
            [nameof(IDatePicker.Background)] = MapBackground,
#elif IOS
			[nameof(IDatePicker.FlowDirection)] = MapFlowDirection,
#endif
            [nameof(IDatePicker.CharacterSpacing)] = MapCharacterSpacing,
            [nameof(IDatePicker.Date)] = MapDate,
            [nameof(IDatePicker.Font)] = MapFont,
            [nameof(IDatePicker.Format)] = MapFormat,
            [nameof(IDatePicker.MaximumDate)] = MapMaximumDate,
            [nameof(IDatePicker.MinimumDate)] = MapMinimumDate,
            [nameof(IDatePicker.TextColor)] = MapTextColor,
        };

    public static CommandMapper<IPicker, IDatePickerHandler> CommandMapper = new(ViewCommandMapper)
    {
    };

    public DatePickerHandler() : base(Mapper, CommandMapper)
    {
    }

    public DatePickerHandler(IPropertyMapper? mapper)
        : base(mapper ?? Mapper, CommandMapper)
    {
    }

    public DatePickerHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
        : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
    {
    }

    IDatePicker IDatePickerHandler.VirtualView => VirtualView;

    PlatformView IDatePickerHandler.PlatformView => PlatformView;

#if ANDROID || WINDOWS
    /// <summary>
    /// Maps the abstract <see cref="IView.Background"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapBackground(IDatePickerHandler handler, IDatePicker datePicker);
#endif

#if IOS || MACCATALYST
		/// <summary>
		/// Maps the abstract <see cref="IView.FlowDirection"/> property to the platform-specific implementations.
		/// </summary>
		/// <param name="handler">The associated handler.</param>
		/// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
		public static partial void MapFlowDirection(DatePickerHandler handler, IDatePicker datePicker);
#endif

    /// <summary>
    /// Maps the abstract <see cref="IDatePicker.Format"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapFormat(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="IDatePicker.Date"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapDate(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="IDatePicker.MinimumDate"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapMinimumDate(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="IDatePicker.MaximumDate"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapMaximumDate(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="ITextStyle.CharacterSpacing"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapCharacterSpacing(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="ITextStyle.Font"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapFont(IDatePickerHandler handler, IDatePicker datePicker);

    /// <summary>
    /// Maps the abstract <see cref="ITextStyle.TextColor"/> property to the platform-specific implementations.
    /// </summary>
    /// <param name="handler">The associated handler.</param>
    /// <param name="datePicker">The associated <see cref="IDatePicker"/> instance.</param>
    public static partial void MapTextColor(IDatePickerHandler handler, IDatePicker datePicker);
}