using Microsoft.Maui.Controls;
using System;
using System.Reflection.PortableExecutable;
namespace MAUITestAPP;

public partial class ExplorePage : ContentPage
{
	public ExplorePage()
	{
		InitializeComponent();

        string address1 = "Howrah, West Bengal, India";
        string address2 = "Kolkata, West Bengal, India";

        myWebView.Navigated += async delegate
        {
            Console.WriteLine("COMPLETED LOADING");
            string fun = $"loadMapScenario('{address1}','{address2}')";
            Console.Write("CALLING FUNC:" + fun);
            await myWebView.EvaluateJavaScriptAsync(fun);
            Console.WriteLine("COMPLETED MAP");
        };
    }
}