using Microsoft.Maui.Controls.Shapes;

namespace MAUITestAPP;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();
    }

	private void gotoMainPage(object sender , EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MainPage));
	}

    private IView GetPanel()
    {
        //first border
        var border = new Border();
        border.Stroke = Brush.Transparent;
        var rect = new RoundRectangle();
        rect.CornerRadius = 25;
        border.StrokeShape = rect;
        border.HeightRequest = 200;
        border.BackgroundColor = Color.FromHex("#e1ebfa");

        //horizontalstacklayout1
        var layout = new HorizontalStackLayout();
        layout.Padding = 10;
        layout.Spacing = 5;

        //second border
        var border2 = new Border();
        border2.WidthRequest = 150;
        border2.Stroke = Brush.Transparent;
        var rect1 = new RoundRectangle();
        rect1.CornerRadius = 20;
        border2.StrokeShape = rect1;
        var img = new Image();
        img.Source = "birla.jpg";
        img.Aspect = Aspect.AspectFill;
        border2.Content = img;

        //verticalstacklayout1
        var layout2 = new VerticalStackLayout();
        layout2.Padding = 10;
   
        var label = new Label();
        label.FontSize = 22;
        label.WidthRequest = 180;
        label.FontFamily = "Monospace";
        label.Text = "Hello World";
        label.LineBreakMode = LineBreakMode.TailTruncation;
        layout.Add(label);

        //horizontalstacklayout2
        var layout3 = new HorizontalStackLayout();
        var img1 = new Image();
        img1.Source = "location.png";
        var label1 = new Label();
        label1.FontSize = 15;
        label1.Text = "Birlaaaaaaaaaa";
        label1.FontFamily = "Monospace";
        label1.VerticalOptions = LayoutOptions.Center;
        layout3.Add(label1);
        layout3.Add(img1);

        //starting scroll view
        var view = new ScrollView();
        view.Margin = 5;
        view.WidthRequest = 150;
        view.Orientation = ScrollOrientation.Horizontal;
        view.HorizontalScrollBarVisibility = ScrollBarVisibility.Never;

        //horizontalStackLayout in scroll view
        var layout4 = new HorizontalStackLayout();
        layout4.Spacing = 5;
        var border3 = new Border();
        border3.Stroke = Brush.Transparent;
        border3.WidthRequest = 100;
        border3.HeightRequest = 70;
        var rect2 = new RoundRectangle();
        rect2.CornerRadius = 15;
        border3.StrokeShape = rect2;

        var img2 = new Image();
        img2.Source = "birla.jpg";
        img2.Aspect = Aspect.AspectFill;
        border3.Content = img2;

        var border4 = new Border();
        border4.Stroke = Brush.Transparent;
        border4.WidthRequest = 100;
        border4.HeightRequest = 70;
        var rect3 = new RoundRectangle();
        rect3.CornerRadius = 15;
        border4.StrokeShape = rect3;

        var img3 = new Image();
        img3.Source = "birla.jpg";
        img3.Aspect = Aspect.AspectFill;
        border4.Content = img3;
        layout4.Add(border3);
        layout4.Add(border4);

        //border after scroll view
        var border5 = new Border();
        border5.Stroke = Brush.Transparent;
        border5.HeightRequest = 25;
        var rect4 = new RoundRectangle();
        rect4.CornerRadius = 25;
        border5.StrokeShape = rect4;
        border5.BackgroundColor = Color.FromHex("#2b282e");
        var label2 = new Label();
        label2.FontAttributes = FontAttributes.Bold;
        label2.VerticalOptions = LayoutOptions.Center;
        label2.HorizontalOptions = LayoutOptions.Center;
        label2.TextColor = Color.Parse("AliceBlue");
        label2.Text = "Science Exhibition";
        border5.Content = label2;

        layout2.Add(view);
        layout2.Add(border5);

        border.Content = layout;
        border.Content = layout2;

        return border;
    }

}