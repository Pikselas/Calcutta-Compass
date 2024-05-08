using Microsoft.Maui.Controls.Shapes;

namespace MAUITestAPP;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();
    }

	private void gotoMainPage(object sender , EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MainPage));
	}
}