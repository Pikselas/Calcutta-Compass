using Microsoft.Maui.Controls.Shapes;

namespace MAUITestAPP;

public partial class SubSearchPage : ContentPage
{
	public SubSearchPage()
	{
		InitializeComponent();

        Dispatcher.Dispatch(() =>
        {
			var res = PlaceRequestHandler.GeSubSearchItems("Kolkata Dishes");
            foreach (var item in res)
            {
                search_result.Add(GetPanel(new panel_Data { img = "foods.jpg", background = "#2f2b36", description_color = "AliceBlue" , title = item.title , 
				description = item.description
				}));
            }
        });

	}

	struct panel_Data
	{
		public string img;
		public string background;
		public string description_color;
		public string title;
		public string description;
	}

	IView GetPanel(panel_Data data)
	{
		var border_view = new Border();
		border_view.HeightRequest = 250;
		border_view.BackgroundColor = Color.FromHex(data.background);
		border_view.Stroke = Color.Parse("Transparent");
		border_view.StrokeShape = new RoundRectangle{CornerRadius = 25};

		var h_layout = new HorizontalStackLayout();

		var img_border = new Border();
		img_border.WidthRequest = 150;
		img_border.Stroke = Color.Parse("Transparent");
		img_border.Content = new Image { Source = data.img , Aspect = Aspect.AspectFill };

		var v_layout = new VerticalStackLayout();
		v_layout.Padding = new Thickness(20);

		v_layout.Add(new Label { Text = data.title , MaximumWidthRequest = 200 , FontSize = 25 , TextColor = Color.Parse("AliceBlue") , LineBreakMode = LineBreakMode.TailTruncation });
		v_layout.Add(new Label { Text = data.description , MaximumWidthRequest = 200, MaximumHeightRequest = 250 , FontSize = 15 , TextColor = Color.Parse(data.description_color)});


		h_layout.Add(img_border);
		h_layout.Add(v_layout);
		border_view.Content = h_layout;
		return border_view;
	}
}