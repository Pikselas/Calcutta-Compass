using System.Xml.Linq;

namespace MAUITestAPP;

public partial class ExplorePlacePage : ContentPage , IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        TopImage.Source = $"{query["place_name"]}.jpg";
    }

    public ExplorePlacePage()
	{
		InitializeComponent();
	}


}