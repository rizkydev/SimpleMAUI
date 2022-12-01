namespace RizkyApps;

public partial class TestBaru : ContentPage
{
    public TestBaru()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new MainPage());
        }
        catch (Exception aw)
        {
            var x = aw.Message.ToString();
        }
    }
}