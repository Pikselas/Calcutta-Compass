namespace MAUITestAPP;

using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.ApplicationModel;

public partial class ExplorePlacePage : ContentPage, IQueryAttributable
{

    private string? place_location;
    private string? place_name;

    private float? lat;
    private float? lon;

    public ExplorePlacePage()
    {
        InitializeComponent();
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Task.Run(() => 
        {
            var place_data = PlaceRequestHandler.GetPlaceDetails($"{query["place_id"]}");
            if (place_data != null)
            {
                Dispatcher.Dispatch(() =>
                {
                    place_image_main.Source = place_data.image_src;
                    place_title.Text = place_data.place_name;
                    rating.Text = place_data.rating.ToString();
                    location.Text = place_data.location;
                    description.Text = place_data.description;

                    place_location = place_data.location;
                    place_name = place_data.place_name;

                    lat = place_data.lat;
                    lon = place_data.lon;

                });
            }
        });
    }

    private async void GotoMap(object sender, EventArgs e)
    {
         var navigationParameter = new Dictionary<string, object> { { "place_name", place_name }, { "place_location" , place_location } , { "lat" , lat } , {"lon" , lon } };
         Shell.Current.GoToAsync(nameof(ExplorePage) , navigationParameter);

    }
}