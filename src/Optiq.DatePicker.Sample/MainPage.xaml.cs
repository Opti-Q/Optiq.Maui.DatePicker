using Font = Microsoft.Maui.Font;

namespace Optiq.DatePicker.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            dp1.Date = DateVal;
            dp1.Font = Font.OfSize("Bahnschrift", 40);

            dp2.Date = DateVal2;
            dp2.Font = Font.OfSize("Microsoft Sans Serif", 20);
        } 


        public DateTime? DateVal => DateTime.UtcNow;
        public DateTime? DateVal2 => new DateTime(2003, 2, 20);

    }
}