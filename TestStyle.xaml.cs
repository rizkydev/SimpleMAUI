using Microsoft.Maui.Controls;

namespace RizkyApps;

public partial class TestStyle : ContentPage
{
	int iCount = 0;
	public TestStyle()
	{
		InitializeComponent();
	}

    private void btn7_Clicked(object sender, EventArgs e)
    {
        Resources["stlDynamic"] = Resources["stlSecondButton"];
    }
}