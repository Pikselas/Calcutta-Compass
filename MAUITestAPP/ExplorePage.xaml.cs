using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Devices;

namespace MAUITestAPP;

public partial class ExplorePage : ContentPage, IQueryAttributable
{
    public ExplorePage()
	{
		InitializeComponent();
        var wview = new WebView();
        if (wview == null)
        {
            // WebView is not supported
            var fun = async () => 
            {
                await DisplayAlert("Feature Not available", "Sorry! Map feature is currently not available for this devic", "Ok");
                await Shell.Current.GoToAsync(nameof(MainPage));
            };
            fun();
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        string address1 = "Howrah, West Bengal, India";

        myWebView.Navigated += delegate
        {
            string fun = $"loadMapScenario('{address1}','{query["place"]}')";
            myWebView.EvaluateJavaScriptAsync(fun);
        };
    }

}