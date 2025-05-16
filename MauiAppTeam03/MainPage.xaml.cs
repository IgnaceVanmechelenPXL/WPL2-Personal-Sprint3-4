namespace MauiAppTeam03
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoadRoutes(object sender, EventArgs e)
        {
            var routes = await RestService.GetBoulderRoutesAsync();
            boulderRoutesListView.ItemsSource = routes;
            loadRoutesButton.IsVisible = false;
        }
    }
}
