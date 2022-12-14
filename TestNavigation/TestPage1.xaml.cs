namespace RizkyApps.TestNavigation;

public partial class TestPage1 : ContentPage
{
    int count = 0;

    public TestPage1()
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
        //Navigation.PushAsync(new TestPage2());
        Navigation.PushAsync(new TestPage2(txtNote.Text));
    }

    private void btnModal_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TestModalPage());
    }
}