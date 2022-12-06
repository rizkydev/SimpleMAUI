

namespace RizkyApps;

public partial class TestGenerateQuotes : ContentPage
{
    List<string> listQuotes = new List<string>();

    public TestGenerateQuotes()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMauiAsset();
    }

    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

        //var contents = reader.ReadToEnd();
        var tempLine = string.Empty;
        while(reader.Peek() != -1)
        {
            var dat = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(dat))
            {
                if(!string.IsNullOrWhiteSpace(tempLine))
                    listQuotes.Add(tempLine);
                tempLine = string.Empty;
            }
            else
            {
                tempLine += " " + dat;
            }
        }
    }

    private void btnGenerate_Clicked(object sender, EventArgs e)
    {
		Generateprocess();
		SetColor();
    }

    private void Generateprocess()
    {
        var rand = new Random();
        var index = rand.Next(listQuotes.Count());
        lblQuotes.Text = listQuotes[index];
    }

	private void SetColor()
	{
        var rand = new Random();
        var cColor1 = System.Drawing.Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        var cColor2 = System.Drawing.Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        var cColor = ColorUtility.ColorControls.GetColorGradient(cColor1, cColor2, 6);

        float stopOffset = 0;
        var stopsColl = new GradientStopCollection();
        foreach(var dat in cColor)
        {
            stopsColl.Add(new GradientStop(Color.FromArgb(dat.Name), stopOffset));
            stopOffset = stopOffset + 0.2f;
        }

        var cGradient = new LinearGradientBrush(stopsColl, new Point(0, 0), new Point(1, 1));
        GridBackColor.Background = cGradient;
    }

}