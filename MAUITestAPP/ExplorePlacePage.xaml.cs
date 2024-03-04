namespace MAUITestAPP;

public partial class ExplorePlacePage : ContentPage, IQueryAttributable
{
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
                });
            }
        });
    }
}