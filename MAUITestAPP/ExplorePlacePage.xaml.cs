using System.Xml.Linq;

namespace MAUITestAPP;

public partial class ExplorePlacePage : ContentPage , IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        TopImage.Source = $"{query["image_src"]}";
        GoBtn.Clicked += delegate
        {
            Shell.Current.GoToAsync(nameof(ExplorePage), new Dictionary<string, object> { { "place", $"{query["place_name"]}" } });
        };

    }

    public ExplorePlacePage()
	{
		InitializeComponent();
	}


}