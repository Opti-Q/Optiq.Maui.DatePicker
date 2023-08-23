using Font = Microsoft.Maui.Font;

namespace Optiq.DatePicker.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            dp1.Date = DateTime.UtcNow;
            dp1.Font = Font.OfSize("Bahnschrift", 40);

            dp2.Date = new DateTime(2003, 2, 20);
            dp2.Font = Font.OfSize("Microsoft Sans Serif", 20);

            tp1.Font = Font.OfSize("Bahnschrift", 40);
            tp1.Time = TimeSpan.FromSeconds(2340);
            tp1.CharacterSpacing = 15;

        } 
    }
}