#if WINDOWS || ANDROID || IOS
using Optiq.DatePicker.Core.Interfaces;
using Optiq.DatePicker.Handlers.DatePicker;
using Optiq.DatePicker.Handlers.TimePicker;
#endif
using IDatePicker = Optiq.DatePicker.Core.Interfaces.IDatePicker;
using ITimePicker = Optiq.DatePicker.Core.Interfaces.ITimePicker;

namespace Optiq.DatePicker;

public static class AppBuilderExtension
{
    public static MauiAppBuilder UseMauiOptiqDateAndTimePicker(this MauiAppBuilder builder, Action<AppleSignInAuthenticator.Options>? options = default)
    {

        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
                    handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
                    handlers.AddHandler(typeof(ITimePicker), typeof(TimePickerHandler));
#elif IOS
                    handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
                    handlers.AddHandler(typeof(ITimePicker), typeof(TimePickerHandler));

#elif WINDOWS
                    handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
                    handlers.AddHandler(typeof(ITimePicker), typeof(TimePickerHandler));
#endif
        }); ;


        return builder;
    }
}