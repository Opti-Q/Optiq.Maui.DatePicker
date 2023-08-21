#if WINDOWS || ANDROID || IOS
using Optiq.DatePicker.Handlers;
#endif
using IDatePicker = Optiq.DatePicker.Core.IDatePicker;

namespace Optiq.DatePicker;

public static class AppBuilderExtension
{
    public static MauiAppBuilder UseMauiOptiqDatePicker(this MauiAppBuilder builder, Action<AppleSignInAuthenticator.Options>? options = default)
    {

        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
                    handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
#elif IOS
                    handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
#elif WINDOWS
            handlers.AddHandler(typeof(IDatePicker), typeof(DatePickerHandler));
#endif
        }); ;


        return builder;
    }
}