using RizkyApps.Jobs;

namespace RizkyApps.TestNavigation;

public partial class TestPage3 : ContentPage
{
    int count = 0;
    public TestPage3()
	{
		InitializeComponent();
	}
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void btnForward_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TestPage3());
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void btnRoot_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }

    private void btnLogOut_Clicked(object sender, EventArgs e)
    {
        NavUtil.InsertPage(Navigation, "TestLoginPageNav");
        Navigation.PopToRootAsync();
    }
}