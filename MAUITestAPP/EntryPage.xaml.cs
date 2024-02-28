namespace MAUITestAPP;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();

        Shell.Current.GoToAsync(nameof(ExplorePlacePage));

    }

	private void gotoMainPage(object sender , EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MainPage));
	}
}