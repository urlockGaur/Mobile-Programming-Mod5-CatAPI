namespace Module5LabA
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetCatFactClicked(object sender, EventArgs e)
        {
            try
            {
                // Fetch a random cat fact using the CatFactService
                var catFact = await CatFactService.GetRandomCatFactAsync();
                FactLabel.Text = catFact.Fact;
            }
            catch (Exception ex)
            {
                FactLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}