namespace MAUITestAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExplorePage) , typeof(ExplorePage));
            Routing.RegisterRoute(nameof(ExplorePlacePage), typeof(ExplorePlacePage));
        }
    }
}
