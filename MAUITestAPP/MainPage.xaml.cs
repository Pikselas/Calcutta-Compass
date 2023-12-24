using System.Collections;

namespace MAUITestAPP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GotoExplorePage(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object> { { "place_name", "howrah_bridge" } };
            await Shell.Current.GoToAsync(nameof(ExplorePlacePage), navigationParameter);
            Console.WriteLine("COMPLETED");
        }
    }

}
