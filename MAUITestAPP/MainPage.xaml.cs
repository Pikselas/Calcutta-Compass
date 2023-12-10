namespace MAUITestAPP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void GotoExplorePage(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ExplorePage));
        }
    }

}
