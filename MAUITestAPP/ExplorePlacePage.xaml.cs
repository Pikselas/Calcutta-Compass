namespace MAUITestAPP;

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
            var place_data =  (PlaceRequestHandler.PlaceDataType)query["place_data"];
            if (place_data != null)
            {
                Dispatcher.Dispatch(() =>
                {
                    place_image_main.Source = place_data.photos.FirstOrDefault();
                    place_title.Text = place_data.name;
                    rating.Text = place_data.rating.ToString();
                    location.Text = place_data.address;
                    description.Text = String.Join('.' , place_data.description);

                    place_location = place_data.address;
                    place_name = place_data.name;

                    lat = place_data.lat;
                    lon = place_data.ln;

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