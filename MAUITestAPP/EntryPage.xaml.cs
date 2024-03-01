namespace MAUITestAPP;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();

        Shell.Current.GoToAsync(nameof(MainPage));


    }

	private void gotoMainPage(object sender , EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MainPage));
	}
}