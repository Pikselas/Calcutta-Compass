﻿using CommunityToolkit.Maui.Media;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Controls.Shapes;
using System.Globalization;

namespace MAUITestAPP
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                var places = PlaceRequestHandler.GetPlaceList();
                if (places != null)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        foreach (var place in places)
                        {
                            places_container.Add(GetPanel(place));
                        }
                    });
                }
            });
        }
        private void GotoPlace(PlaceRequestHandler.PlaceDataType place_data)
        {
            var navigationParameter = new Dictionary<string, object> { { "place_data", place_data } };
            Shell.Current.GoToAsync(nameof(ExplorePlacePage), navigationParameter);
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

        private IView pain(string Name, float Rating, string ImgSrc, Action clicked)
        {
            // main frame
            // using grid as it helps for overlaying
            Grid grid = new Grid();
            grid.HeightRequest = 150;

            // background design
            var bg_layout = new HorizontalStackLayout();
            bg_layout.HeightRequest = 150;
            bg_layout.BackgroundColor = Color.FromHex("#040624");

            // stroke shape full circle
            var border_stroke_shape = new RoundRectangle();
            border_stroke_shape.CornerRadius = 150;

            // 1st circle
            var circle_1 = new Border();
            circle_1.Stroke = Brush.Transparent;
            circle_1.WidthRequest = 280;
            circle_1.HeightRequest = 280;
            circle_1.StrokeShape = border_stroke_shape;
            circle_1.BackgroundColor = Color.FromHex("#22bf73");

            var circle_1_margin = new Thickness();
            circle_1_margin.Left = 50;
            circle_1_margin.Top = 225;

            circle_1.Margin = circle_1_margin;

            // 2nd circle
            var circle_2 = new Border();
            circle_2.Stroke = Brush.Transparent;
            circle_2.WidthRequest = 200;
            circle_2.HeightRequest = 200;
            circle_2.StrokeShape = border_stroke_shape;
            circle_2.BackgroundColor = Color.FromHex("#22bf73");

            var circle_2_margin = new Thickness();
            circle_2_margin.Left = -45;
            circle_2_margin.Top = 60;

            circle_2.Margin = circle_2_margin;

            bg_layout.Add(circle_1);
            bg_layout.Add(circle_2);

            // Content
            var content_layout = new HorizontalStackLayout();

            // place image
            var image_border = new Border();
            image_border.HeightRequest = 140;
            image_border.WidthRequest = 180;
            image_border.Stroke = Brush.Transparent;

            var image_border_stroke_shape = new RoundRectangle();
            image_border_stroke_shape.CornerRadius = new CornerRadius(0, 45, 0, 45);

            image_border.StrokeShape = image_border_stroke_shape;

            var image = new Image();
            image.Source = ImgSrc;
            image.Aspect = Aspect.AspectFill;

            image_border.Content = image;
            content_layout.Add(image_border);

            // place details
            var details_layout = new VerticalStackLayout();

            var title = new Label();
            title.Text = Name;
            title.TextColor = Color.FromHex("#adf0ff");
            title.FontFamily = "Bellfast";
            title.FontSize = 30;
            title.FontAttributes = FontAttributes.Bold;

            var rating_border = new Border();
            rating_border.HorizontalOptions = LayoutOptions.Start;
            rating_border.WidthRequest = 70;
            rating_border.Padding = 5;

            var rating_border_stroke = new RoundRectangle();
            rating_border_stroke.CornerRadius = 15;

            rating_border.StrokeShape = rating_border_stroke;

            var rating_layout = new HorizontalStackLayout();

            var rating = new Label();
            rating.Text = Rating.ToString();
            rating.TextColor = Color.Parse("AliceBlue");
            rating.FontSize = 20;

            rating_layout.Add(new Image { Source = "star.png" });
            rating_layout.Add(rating);

            rating_border.Content = rating_layout;

            var go_btn = new ImageButton { Source = "goto_explore.png" };
            go_btn.Clicked += delegate { clicked(); };

            var go_btn_margin = new Thickness();
            go_btn_margin.Left = 140;
            go_btn_margin.Top = 0;

            go_btn.Margin = go_btn_margin;

            var btn_shadow = new Shadow();
            btn_shadow.Brush = Brush.AliceBlue;
            btn_shadow.Radius = 10;

            go_btn.Shadow = btn_shadow;

            details_layout.Add(title);
            details_layout.Add(rating_border);
            details_layout.Add(go_btn);

            content_layout.Add(details_layout);

            grid.Add(bg_layout);
            grid.Add(content_layout);

            var border = new Border();
            border.HeightRequest = 150;
            border.Content = grid;
            border.Stroke = Brush.Transparent;
            border.StrokeThickness = 0;

            return border;
        }

        /* private IView GetPanel(PlaceRequestHandler.PlaceDataType data)
         {
             var border = new Border();
             border.Stroke = Brush.Transparent;

             var rect = new RoundRectangle();
             rect.CornerRadius = 45;
             border.StrokeShape = rect;
             var layout = new StackLayout();
             layout.Padding = 10;
             var grid = new Grid();
             grid.HeightRequest = 350;
             var img = new Image();
             img.Source = data.photos.FirstOrDefault();
             img.Aspect = Aspect.AspectFill;
             grid.Add(img);
             grid.Add(layout);
             border.Content = grid;

             grid = new Grid();
             var border2 = new Border();
             grid.Add(border2);
             border2.BackgroundColor = Color.Parse("AntiqueWhite");
             border2.HorizontalOptions = LayoutOptions.Start;
             rect = new RoundRectangle();
             rect.CornerRadius = 25;
             border2.StrokeShape = rect;
             border2.WidthRequest = 70;
             border2.HeightRequest = 40;
             var layout2 = new HorizontalStackLayout();
             layout2.Padding = 5;
             var img2 = new Image();
             img2.Source = "star.png";
             layout2.Add(img2);
             var label = new Label();
             label.Text = data.rating.ToString();
             label.FontSize = 20;
             layout2.Add(label);
             var imgbtn = new ImageButton();
             imgbtn.Source = "favourite_unselected.png";
             imgbtn.HorizontalOptions = LayoutOptions.End;
             grid.Add(imgbtn);
             border2.Content = layout2;
             layout.Add(grid);

             grid = new Grid();
             grid.VerticalOptions = LayoutOptions.EndAndExpand;
             var layout3 = new VerticalStackLayout();
             layout3.Padding = 10;
             var label2 = new Label();
             label2.Text = data.name;
             label2.TextColor = Color.Parse("WhiteSmoke");
             label2.VerticalOptions = LayoutOptions.Center;
             label2.FontSize = 30;
             label2.WidthRequest = 150;
             label2.HorizontalOptions = LayoutOptions.Start;
             layout3.Add(label2);

             var layout4 = new HorizontalStackLayout();

             var loc_image = new Image { Source = "location_blue.png" };

             var label3 = new Label();
             label3.Text = data.address;
             label3.TextColor = Color.Parse("Azure");
             label3.VerticalOptions = LayoutOptions.Center;

             layout4.Add(loc_image);
             layout4.Add(label3);
             layout3.Add(layout4);

             var imgbtn1 = new ImageButton();
             imgbtn1.Source = "goto_explore.png";
             imgbtn1.HorizontalOptions = LayoutOptions.End;
             imgbtn1.VerticalOptions = LayoutOptions.End;
             imgbtn1.Clicked += delegate
             {
                 GotoPlace(data);
             };

             grid.Add(imgbtn1);
             grid.Add(layout3);
             layout.Add(grid);

             return border;
         } */

        private IView GetPanel(PlaceRequestHandler.PlaceDataType place)
        {
            var tap_gesture = new TapGestureRecognizer();
            tap_gesture.Tapped += (s, e) =>
            {
                GotoPlace(place);
            };

            //first border
            var border = new Border();
            border.Stroke = Brush.Transparent;

            border.GestureRecognizers.Add(tap_gesture);

            var rect = new RoundRectangle();
            rect.CornerRadius = 25;
            border.StrokeShape = rect;
            border.HeightRequest = 200;
            border.BackgroundColor = Color.FromHex("#cdecfa");

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
            img.Source = place.photos.FirstOrDefault();
            img.Aspect = Aspect.AspectFill;
            border2.Content = img;

            layout.Add(border2);

            //verticalstacklayout1
            var layout2 = new VerticalStackLayout();
            layout2.Padding = 10;

            var label = new Label();
            label.FontSize = 22;
            label.WidthRequest = 180;
            label.FontFamily = "Monospace";
            label.Text = place.name;
            label.LineBreakMode = LineBreakMode.TailTruncation;
            layout2.Add(label);

            layout.Add(layout2);

            //horizontalstacklayout2
            var layout3 = new HorizontalStackLayout();

            var img1 = new Image();
            img1.Source = "location.png";

            var label1 = new Label();
            label1.FontSize = 15;
            label1.Text = place.address;
            label1.FontFamily = "Monospace";
            label1.WidthRequest = 160;
            label1.LineBreakMode = LineBreakMode.TailTruncation;
            label1.VerticalOptions = LayoutOptions.Center;

            layout3.Add(img1);
            layout3.Add(label1);

            layout2.Add(layout3);

            //starting scroll view
            var view = new ScrollView();
            view.Margin = 5;
            view.WidthRequest = 150;
            view.Orientation = ScrollOrientation.Horizontal;
            view.HorizontalScrollBarVisibility = ScrollBarVisibility.Never;

            //horizontalStackLayout in scroll view
            var layout4 = new HorizontalStackLayout();
            layout4.Spacing = 5;
            view.Content = layout4;

            if (place.photos.Length > 1)
            {
                foreach (var photo in place.photos.AsSpan(1))
                {
                    var border3 = new Border();
                    border3.Stroke = Brush.Transparent;
                    border3.WidthRequest = 100;
                    border3.HeightRequest = 70;
                    var rect2 = new RoundRectangle();
                    rect2.CornerRadius = 15;
                    border3.StrokeShape = rect2;

                    var img2 = new Image();
                    img2.Source = photo;
                    img2.Aspect = Aspect.AspectFill;

                    border3.Content = img2;
                    layout4.Add(border3);
                }
            }

            //border after scroll view
            var border5 = new Border();
            border5.Stroke = Brush.Transparent;
            border5.HeightRequest = 25;
            var rect4 = new RoundRectangle();
            rect4.CornerRadius = 25;
            border5.StrokeShape = rect4;
            border5.BackgroundColor = Color.FromHex("#2b282e");

            var rating_layout = new StackLayout();
            border5.Content = rating_layout;

            var hor_layout = new HorizontalStackLayout();
            hor_layout.HorizontalOptions = LayoutOptions.Center;

            rating_layout.Add(hor_layout);

            var label2 = new Label();
            label2.FontAttributes = FontAttributes.Bold;
            //label2.VerticalOptions = LayoutOptions.Center;
            label2.VerticalOptions = LayoutOptions.Center;
            label2.TextColor = Color.Parse("AliceBlue");
            label2.Text = place.rating.ToString();

            var star_img = new Image();
            star_img.Source = "star_smol.jpg";
            star_img.VerticalOptions = LayoutOptions.Center;

            hor_layout.Add(label2);
            hor_layout.Add(star_img);

            layout2.Add(view);
            layout2.Add(border5);

            border.Content = layout;
            // border.Content = layout2;

            return border;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(TranslatorPage));
        }


        private void search_entry_Completed(object sender, EventArgs e)
        {
            places_container.Clear();
            Dispatcher.Dispatch(() =>
            {
                var places = PlaceRequestHandler.SearchPlace(search_entry.Text);
                if (places != null)
                {
                    places_container.Clear();

                    foreach (var place in places)
                    {
                        places_container.Add(GetPanel(place));
                    }
                }
            });
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(EntryPage));
        }
    }
}