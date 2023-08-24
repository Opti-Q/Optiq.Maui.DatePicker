using Microsoft.Maui.Controls;
using Optiq.DatePicker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;

namespace Optiq.DatePicker
{
    public class TimePicker : View, IElementConfiguration<TimePicker>, ITimePicker
    {
        /// <summary>Bindable property for <see cref="Format"/>.</summary>
        public static readonly BindableProperty FormatProperty = BindableProperty.Create(nameof(Format), typeof(string), typeof(TimePicker), "t");

        public static readonly BindableProperty FontProperty = BindableProperty.Create(nameof(Font), typeof(Microsoft.Maui.Font), typeof(TimePicker), Microsoft.Maui.Font.Default);


        public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(double),
            typeof(TimePicker),
            0.0d);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color),
            typeof(TimePicker),
            Color.FromArgb("#000000"));

        /// <summary>Bindable property for <see cref="Time"/>.</summary>
        public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), typeof(TimeSpan?), typeof(TimePicker), null, BindingMode.TwoWay,
            validateValue: (bindable, value) =>
            {
                if (value != null)
                {
                    var time = (TimeSpan)value;
                    return time.TotalHours < 24 && time.TotalMilliseconds >= 0;
                }
                return true;
            });

        readonly Lazy<PlatformConfigurationRegistry<TimePicker>> _platformConfigurationRegistry;

        public TimePicker()
        {
            _platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<TimePicker>>(() => new PlatformConfigurationRegistry<TimePicker>(this));
        }
        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        public TimeSpan? Time
        {
            get { return (TimeSpan?)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public Microsoft.Maui.Font Font
        {
            get { return (Microsoft.Maui.Font)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }

        public double CharacterSpacing
        {
            get { return (double)GetValue(CharacterSpacingProperty); }
            set { SetValue(CharacterSpacingProperty, value); }
        }
        public IPlatformElementConfiguration<T, TimePicker> On<T>() where T : IConfigPlatform
        {
            return _platformConfigurationRegistry.Value.On<T>();
        }
    }
}
