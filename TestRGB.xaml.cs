using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
namespace RizkyApps;

public partial class TestRGB : ContentPage
{
    string sHexString = string.Empty;

	public TestRGB()
	{
		InitializeComponent();
	}

    private void sldr2_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        SetColor(GetColor());
    }
    private void sldr3_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        SetColor(GetColor());
    }
    private void sldr1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        SetColor(GetColor());
    }

    private Color GetColor()
	{
		var rDat = Convert.ToInt32(sldr1.Value);
		var gDat = Convert.ToInt32(sldr2.Value);
		var bDat = Convert.ToInt32(sldr3.Value);
		var currColor = Color.FromRgb(rDat,gDat,bDat);
		return currColor;
    }

	private void SetColor(Color colDat)
	{
		warnaBelakang.Background = colDat;
		btnGen.Background = colDat;
        sHexString = colDat.ToHex();
        lblHex.Text = "Value : " + sHexString;
        Debug.WriteLine(colDat.ToString());
    }

    private void btnGen_Clicked(object sender, EventArgs e)
    {
        var ranDat = new Random();
        sldr1.Value = ranDat.Next(0, 255);
        sldr2.Value = ranDat.Next(0, 255);
        sldr3.Value = ranDat.Next(0, 255);
        SetColor(GetColor());
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(sHexString);
        var toastControl = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toastControl.Show();
    }
}