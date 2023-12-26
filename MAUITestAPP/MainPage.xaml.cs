using Microsoft.Maui.Controls.Shapes;
using System.Collections;

namespace MAUITestAPP
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            places_portion.Add(CreatePlacePanel("Howrah" , "The Peneteration of Joy" , "howrah_bridge.jpg"));

        }

        private Border CreatePlacePanel(string Name ,  string Desc , string ImgSrc)
        {
            Border border = new();

            var round_rect = new RoundRectangle();
            round_rect.CornerRadius = 25;
            border.StrokeShape = round_rect;

            border.HeightRequest = 250;
            border.WidthRequest = 350;
            border.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Grid grid = new();

            Image image = new(){ Source = ImgSrc };
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
            margin.Top = 5;
            margin.Left = 0;
            margin.Right = 0;
            margin.Bottom = -10;
            
            title.Margin = margin;

            Thickness padding = new Thickness();
            padding.Top = 5;
            padding.Left = 5;
            padding.Right = 5;
            padding.Bottom = 5;

            title.Padding = padding;

            title.FontSize = 18;
            title.FontAttributes = FontAttributes.Bold;
            title.FontFamily = "Monospace";
            title.TextColor = Color.Parse("GhostWhite");


            Label desc = new();
            desc.Text = Desc;

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

            stop1.Color = Color.FromRgba(0,0,0,0);
            stop2.Color = Color.FromRgba(0,0,0,255);

            stop1.Offset = 0;
            stop2.Offset = 1;

            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 0);

            gradient.GradientStops.Add(stop1);
            gradient.GradientStops.Add(stop2);

            go_btn.Background = gradient;

            grid.Add(layout);
            grid.Add(go_btn);
            border.Content = grid;

            return border;
        }

        private async void GotoExplorePage(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object> { { "place_name", "howrah_bridge" } };
            await Shell.Current.GoToAsync(nameof(ExplorePlacePage), navigationParameter);
            Console.WriteLine("COMPLETED");
        }
    }

}
