# Optiq.Maui.Tools

## How to use

Add "UserMauiOptiqDateAndTimePicker" in the MauiProgramm


    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiOptiqDateAndTimePicker()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }
    }

Now add the element.

 xmlns:name="clr-namespace:Optiq.DatePicker;assembly=Optiq.DatePicker"

    <name:DatePicker></name:DatePicker>
    <name:TimePicker></name:TimePicker>

