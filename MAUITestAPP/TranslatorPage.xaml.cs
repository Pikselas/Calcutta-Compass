using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Media;
using System.Globalization;
using System.Net;

namespace MAUITestAPP;

public partial class TranslatorPage : ContentPage
{
	public TranslatorPage()
	{
		InitializeComponent();
        translation_view.Source = "https://translate.google.com/?hl=en&sl=auto&tl=en";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        var isGranted = await SpeechToText.Default.RequestPermissions(token);
        if (!isGranted)
        {
            await Toast.Make("Permission not granted").Show(CancellationToken.None);
            return;
        }
        string txt = "";
        var recognitionResult = await SpeechToText.Default.ListenAsync(
                                            CultureInfo.GetCultureInfo("bn-IN"),
                                            new Progress<string>((partialText) =>
                                            {
                                                txt += partialText + " ";
                                            }), token);
        if (recognitionResult.IsSuccessful)
        {
            txt = txt = WebUtility.UrlEncode(recognitionResult.Text);
            translation_view.Source = new UrlWebViewSource { Url = $"https://translate.google.com/?hl=en&sl=auto&tl=en&text={txt}&op=translate" };
        }
        else
        {
            await Toast.Make(recognitionResult.Exception?.Message ?? "Unable to recognize speech").Show(CancellationToken.None);
        }
    }
}