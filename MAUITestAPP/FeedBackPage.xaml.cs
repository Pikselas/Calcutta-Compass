namespace MAUITestAPP;

public partial class FeedBackPage : ContentPage
{
	public FeedBackPage()
	{
		InitializeComponent();

		//rating.Add(new Image { Source = "star.png" });

        Image[] rating_stars = new Image[5];

		// inorder to capture the current value of i
		var getDlg = delegate (int i) {
			
			System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> handler = 

			delegate (object? o , TappedEventArgs e)
			{
				for (int indx = 0; indx < rating_stars.Length; ++indx)
				{
					rating_stars[indx].Source = indx > i ? "star_unmarked.png" : "star.png";
				}
			};

			return handler;
		};

		for(int i = 0; i < rating_stars.Length; ++i)
		{
			var img = new Image();
			img.Source = "star_unmarked.png";
			rating_stars[i] = img;

            var tap_gesture = new TapGestureRecognizer();
			tap_gesture.Tapped += getDlg(i);

			img.GestureRecognizers.Add(tap_gesture);

            rating.Add(img);
		}

	
	}
}