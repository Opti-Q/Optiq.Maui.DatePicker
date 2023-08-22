namespace Optiq.DatePicker.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            dp1.Date = DateVal;
            dp2.Date = DateVal2;
        } 


        public DateTime? DateVal => DateTime.UtcNow;
        public DateTime? DateVal2 => new DateTime(2003, 2, 20);

    }
}