using Microsoft.Maui.Controls;
using System;
using System.Reflection.PortableExecutable;
namespace MAUITestAPP;

public partial class ExplorePage : ContentPage, IQueryAttributable
{
	public ExplorePage()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        string address1 = "Howrah, West Bengal, India";

        myWebView.Navigated += async delegate
        {
            Console.WriteLine("COMPLETED LOADING");
            string fun = $"loadMapScenario('{address1}','{query["place"]}')";
            Console.Write("CALLING FUNC:" + fun);
            await myWebView.EvaluateJavaScriptAsync(fun);
            Console.WriteLine("COMPLETED MAP");
        };
    }

}