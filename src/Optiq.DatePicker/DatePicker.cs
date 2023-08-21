using System;
using Microsoft.Maui.Controls.Internals;
using Font = Microsoft.Maui.Font;
using IDatePicker = Optiq.DatePicker.Core.IDatePicker;

#if IOS
using CurrentPlatform = Microsoft.Maui.Controls.PlatformConfiguration.iOS;
#elif ANDROID
using CurrentPlatform = Microsoft.Maui.Controls.PlatformConfiguration.Android;
#elif WINDOWS
using CurrentPlatform = Microsoft.Maui.Controls.PlatformConfiguration.Windows;
#endif

namespace Optiq.DatePicker;

public class DatePicker : View, IElementConfiguration<DatePicker>, IDatePicker
{

    /// <summary>Bindable property for <see cref="Format"/>.</summary>
    public static readonly BindableProperty FormatProperty =
        BindableProperty.Create(nameof(Format), typeof(string), typeof(DatePicker), "d");

    /// <summary>Bindable property for <see cref="Date"/>.</summary>
    public static readonly BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime?),
        typeof(DatePicker), default(DateTime), BindingMode.TwoWay,
        coerceValue: CoerceDate,
        propertyChanged: DatePropertyChanged,
        defaultValueCreator: (bindable) => null);

    /// <summary>Bindable property for <see cref="MinimumDate"/>.</summary>
    public static readonly BindableProperty MinimumDateProperty = BindableProperty.Create(nameof(MinimumDate),
        typeof(DateTime), typeof(DatePicker), new DateTime(1900, 1, 1),
        validateValue: ValidateMinimumDate, coerceValue: CoerceMinimumDate);

    /// <summary>Bindable property for <see cref="MaximumDate"/>.</summary>
    public static readonly BindableProperty MaximumDateProperty = BindableProperty.Create(nameof(MaximumDate),
        typeof(DateTime), typeof(DatePicker), new DateTime(2100, 12, 31),
        validateValue: ValidateMaximumDate, coerceValue: CoerceMaximumDate);

    readonly Lazy<PlatformConfigurationRegistry<DatePicker>> _platformConfigurationRegistry;

    public DatePicker()
    {
        _platformConfigurationRegistry =
            new Lazy<PlatformConfigurationRegistry<DatePicker>>(() =>
                new PlatformConfigurationRegistry<DatePicker>(this));
    }

    public DateTime? Date
    {
        get { return (DateTime?)GetValue(DateProperty); }
        set { SetValue(DateProperty, value); }
    }

    public string Format
    {
        get { return (string)GetValue(FormatProperty); }
        set { SetValue(FormatProperty, value); }
    }


    public DateTime MaximumDate
    {
        get { return (DateTime)GetValue(MaximumDateProperty); }
        set { SetValue(MaximumDateProperty, value); }
    }

    public DateTime MinimumDate
    {
        get { return (DateTime)GetValue(MinimumDateProperty); }
        set { SetValue(MinimumDateProperty, value); }
    }

    public virtual string UpdateFormsText(string source, TextTransform textTransform)
        => TextTransformUtilites.GetTransformedText(source, textTransform);

    public event EventHandler<DateChangedEventArgs> DateSelected;

    static object CoerceDate(BindableObject bindable, object value)
    {
        if (value == null)
            return value;

        var picker = (DatePicker)bindable;
        DateTime dateValue = ((DateTime)value).Date;

        if (dateValue > picker.MaximumDate)
            dateValue = picker.MaximumDate;

        if (dateValue < picker.MinimumDate)
            dateValue = picker.MinimumDate;

        return dateValue;
    }

    static object CoerceMaximumDate(BindableObject bindable, object value)
    {
        DateTime dateValue = ((DateTime)value).Date;
        var picker = (DatePicker)bindable;
        if (picker.Date > dateValue)
            picker.Date = dateValue;

        return dateValue;
    }

    static object CoerceMinimumDate(BindableObject bindable, object value)
    {
        DateTime dateValue = ((DateTime)value).Date;
        var picker = (DatePicker)bindable;
        if (picker.Date < dateValue)
            picker.Date = dateValue;

        return dateValue;
    }

    static void DatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var datePicker = (DatePicker)bindable;
        EventHandler<DateChangedEventArgs> selected = datePicker.DateSelected;

        if (selected != null)
            selected(datePicker, new DateChangedEventArgs((DateTime)oldValue, (DateTime)newValue));
    }

    static bool ValidateMaximumDate(BindableObject bindable, object value)
    {
        return ((DateTime)value).Date >= ((DatePicker)bindable).MinimumDate.Date;
    }

    static bool ValidateMinimumDate(BindableObject bindable, object value)
    {
        return ((DateTime)value).Date <= ((DatePicker)bindable).MaximumDate.Date;
    }

    /// <inheritdoc/>
    public IPlatformElementConfiguration<T, DatePicker> On<T>() where T : IConfigPlatform
    {
        return _platformConfigurationRegistry.Value.On<T>();
    }

    public Color TextColor => Color.FromArgb("#98fc03");
    public Font Font => Font.Default;
    public double CharacterSpacing => Double.Epsilon;

}

public class DateChangedEventArgs : EventArgs
{
    public DateChangedEventArgs(DateTime? oldDate, DateTime? newDate)
    {
        OldDate = oldDate;
        NewDate = newDate;
    }

    public DateTime? NewDate { get; private set; }

    public DateTime? OldDate { get; private set; }
}