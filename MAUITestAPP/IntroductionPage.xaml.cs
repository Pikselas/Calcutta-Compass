namespace MAUITestAPP;

public partial class IntroductionPage : ContentPage
{
	public IntroductionPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(EntryPage));
    }
}