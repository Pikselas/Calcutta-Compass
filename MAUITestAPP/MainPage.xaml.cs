using Microsoft.Maui.Controls.Shapes;
using System.Text.Json;

namespace MAUITestAPP
{

    public partial class MainPage : ContentPage
    {
        private class PlaceDataType
        {
            public string place_id { get; set; }
            public string place_name { get; set; }
            public string image_src { get; set; }
            public string place_description { get; set; }
            public string rating { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();

            /*places_portion.Add(CreatePlacePanel("Howrah Bridge", "The Connection of Joy", "howrah_bridge.jpg", () => { GotoPlace("Howrah bridge , Howrah", "howrah_bridge_back.jpg"); }));
            places_portion.Add(CreatePlacePanel("Birla Planetarium", "Starlight Show", "birla.jpg", () => { GotoPlace("Birla planetarium , Kolkata", "birla_back.jpg"); }));
            places_portion.Add(CreatePlacePanel("Nataional Library", "The Stack of Joy", "national_library.jpg", () => { GotoPlace("The National Library of India , Kolkata", "national_library_in.jpg"); }));
            places_portion.Add(CreatePlacePanel("Prinsep Ghat", "The Joy On the Boat", "prinsep_ghat.jpg", () => { GotoPlace("James Prinsep Monument, Kolkata", "prinsep.jpg"); }));
            */
            //populateWithPlaces("");
        }

        private void GotoPlace(string place_id)
        {
            var navigationParameter = new Dictionary<string, object> { { "place_id", place_id } };
            Shell.Current.GoToAsync(nameof(ExplorePlacePage), navigationParameter);
        }

        private async void populateWithPlaces(string place_term)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://musical-goldfish-75444r96g7qhrrwg-3000.app.github.dev/");
            if (response.IsSuccessStatusCode)
            {
                var res_content = await response.Content.ReadAsStringAsync();
                var place_data = JsonSerializer.Deserialize<List<PlaceDataType>>(res_content);

                if (place_data != null)
                {
                    foreach (PlaceDataType place in place_data)
                    {
                        places_portion.Add(CreatePlacePanel(place.place_name , "" , place.image_src , () => 
                        {
                            GotoPlace(place.place_id);
                        }));
                    }
                }
            }
        }
        private Border CreatePlacePanel(string Name, string Desc, string ImgSrc, Action go_to_page)
        {
            Border border = new();

            var round_rect = new RoundRectangle();
            round_rect.CornerRadius = 25;
            border.StrokeShape = round_rect;
            border.Stroke = Brush.Transparent;

            Shadow shadow = new Shadow();
            shadow.Brush = Brush.Black;
            shadow.Radius = 25;

            border.Shadow = shadow;

            border.HeightRequest = 250;
            border.WidthRequest = 350;
            border.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Grid grid = new();

            Image image = new() { Source = ImgSrc };
            image.Aspect = Aspect.AspectFill;
            grid.Add(image);

            var layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.End;

            var gradient = new LinearGradientBrush();
            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 0);

            var stop1 = new GradientStop();
            stop1.Color = Color.FromHex("#055AFF");
            stop1.Offset = 0;

            var stop2 = new GradientStop();
            stop2.Color = Color.FromHex("#A854FF");
            stop2.Offset = 1;

            gradient.GradientStops.Add(stop1);
            gradient.GradientStops.Add(stop2);

            layout.Background = gradient;

            Label title = new();
            title.Text = Name;

            Thickness margin = new Thickness();
            margin.Top = 0;
            margin.Left = 5;
            margin.Right = 0;
            margin.Bottom = -15;

            title.Margin = margin;

            Thickness padding = new Thickness();
            padding.Top = 5;
            padding.Left = 5;
            padding.Right = 5;
            padding.Bottom = 5;

            title.Padding = padding;

            title.FontSize = 20;
            title.FontAttributes = FontAttributes.Bold;
            title.FontFamily = "Monospace";
            title.TextColor = Color.Parse("GhostWhite");


            Label desc = new();
            desc.Text = Desc;
            desc.Padding = padding;

            margin = new Thickness();
            margin.Top = 0;
            margin.Left = 15;
            margin.Right = 0;
            margin.Bottom = 15;

            desc.Margin = margin;

            desc.FontSize = 16;
            desc.FontAttributes = FontAttributes.Italic;
            desc.FontFamily = "Monospace";
            desc.TextColor = Color.Parse("AliceBlue");

            layout.Add(title);
            layout.Add(desc);

            var go_btn = new ImageButton();
            go_btn.Source = "go.png";
            go_btn.HorizontalOptions = LayoutOptions.End;
            go_btn.WidthRequest = 100;
            go_btn.Aspect = Aspect.Center;

            gradient = new LinearGradientBrush();
            stop1 = new GradientStop();
            stop2 = new GradientStop();

            stop1.Color = Color.FromRgba(0, 0, 0, 0);
            stop2.Color = Color.FromRgba(0, 0, 0, 255);

            stop1.Offset = 0;
            stop2.Offset = 1;

            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 0);

            gradient.GradientStops.Add(stop1);
            gradient.GradientStops.Add(stop2);

            go_btn.Background = gradient;

            go_btn.Clicked += delegate { go_to_page(); };

            grid.Add(layout);
            grid.Add(go_btn);
            border.Content = grid;

            return border;
        }
    }
}