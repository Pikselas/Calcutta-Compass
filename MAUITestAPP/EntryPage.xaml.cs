using Microsoft.Maui.Controls.Shapes;

namespace MAUITestAPP;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();

		var tap_gesture = new TapGestureRecognizer();
        tap_gesture.Tapped += (s, e) =>
        {
            Shell.Current.GoToAsync(nameof(SubSearchPage));
        };

        Foods_Panel.GestureRecognizers.Add(tap_gesture);
    }

	private void gotoMainPage(object sender , EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MainPage));
	}
	private void gotoTranslatePage(object sender , EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(TranslatorPage));
    }
    private void gotoFeedbackPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FeedBackPage));
    }
}