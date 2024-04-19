using Microsoft.Maui.Controls;

namespace MAUITestAPP;

public partial class ExplorePage : ContentPage, IQueryAttributable
{
    private string? place_name;
    private string? place_location;
    private float? lat;
    private float? lon;
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
        string address1 = "Howrah, West Bengal";

        //map_location_source.Text = address1;
        //map_location_destination.Text = $"{query["place_name"]} , {query["place_location"]}, West Bengal";
        
        place_name = $"{query["place_name"]}";
        place_location = $"{query["place_location"]}";

        lat = (float)query["lat"];
        lon = (float)query["lon"];

        myWebView.Navigated += delegate
        {
            string fun = $"loadMapScenario('{address1}','{query["place_location"] + ", West Bengal"}')";
            myWebView.EvaluateJavaScriptAsync(fun);
        };
    }

    public void OpenInMap(object sender , EventArgs e)
    {
        var options = new MapLaunchOptions { Name = place_name + ',' + place_location };
        Map.Default.OpenAsync(new Location((double)lat, (double)lon), options);
    }
}