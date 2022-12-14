namespace RizkyApps.TestNavigation;

public partial class TestModalPage : ContentPage
{
	public TestModalPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}