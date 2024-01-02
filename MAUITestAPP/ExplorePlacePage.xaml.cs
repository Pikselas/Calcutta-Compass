using Microsoft.Maui.Controls.Shapes;
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

        VerticalStackLayout content = new VerticalStackLayout();
        content.BackgroundColor = Colors.Black;
        Thickness padding = new Thickness(15);

        content.Padding = padding;

        Label about = new Label();
        about.Text = "About";
        about.TextColor = Colors.Azure;
        about.FontSize = 20;
        BoxView hline = new BoxView();
        hline.BackgroundColor = Colors.Azure;
        hline.HeightRequest = 2;

        padding = new Thickness(10);
        content.Padding = padding;

        Label desc = new Label();
        desc.Text = "It is a single-storeyed circular structure designed in the typical Indian style, whose architecture is loosely styled on the Buddhist Stupa at Sanchi";
        desc.TextColor = Colors.AntiqueWhite;
        desc.FontSize = 15;
        desc.FontAttributes = FontAttributes.Italic;
        desc.VerticalOptions = LayoutOptions.Center;

        content.Add(about);
        content.Add(hline);
        content.Add(desc);

        Image img = new Image();
        img.Source = "howrah_bridge.jpg";
        img.Aspect = Aspect.AspectFill;

        Descriptions.Add(CreatePanel(Color.FromHex("#7e04cf") , content));
        Descriptions.Add(CreatePanel(Color.FromHex("#6be8cf") , img));

    }

    private Border CreatePanel(Color color , View? content)
    {

        Border border = new Border();
        var round_rect = new RoundRectangle();
        round_rect.CornerRadius = 25;
        border.StrokeShape = round_rect;
        border.Stroke = Brush.Transparent;
        border.WidthRequest = 250;

        var gradient = new LinearGradientBrush();
        gradient.StartPoint = new Point(1.25, 0);
        gradient.EndPoint = new Point(1, 0.9);

        var stop1 = new GradientStop();
        stop1.Color = Color.FromHex("#150c36");
        stop1.Offset = 0.6f;

        var stop2 = new GradientStop();
        stop2.Color = color;
        stop2.Offset = 1;

        gradient.GradientStops.Add(stop1);
        gradient.GradientStops.Add(stop2);

        border.Background = gradient;

        Border border2 = new Border();
        
        Thickness margin = new Thickness();
        margin.Bottom = 15;
        margin.Left = 15;
        margin.Right = 15;
        margin.Top = 15;

        border2.Margin = margin;
        border2.StrokeShape = round_rect;
        border2.Stroke = Brush.Transparent;

        border2.Content = content;
        border.Content = border2;

        return border;

    }

    public ExplorePlacePage()
	{
		InitializeComponent();
	}


}