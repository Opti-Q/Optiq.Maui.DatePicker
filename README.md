# Optiq.Maui.DatePicker

## How to use

Add "UserMauiOptiqDataPicker" in the MauiProgramm


    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiOptiqDatePicker()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }

Now add the element.

    <datePicker:DatePicker Date="{x:Null}"></datePicker:DatePicker>
