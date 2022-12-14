using RizkyApps.Jobs;

namespace RizkyApps.TestNavigation;

public partial class TestLoginPageNav : ContentPage
{
	public TestLoginPageNav()
	{
		InitializeComponent();
	}

    private void btnForward_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TestPage1());
        NavUtil.DeletePage(Navigation, "TestLoginPageNav");
    }
}