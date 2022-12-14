using RizkyApps.ViewModels;
namespace RizkyApps.TestNavigation;

public partial class TestPage2 : ContentPage
{
    int count = 0;
    public TestPage2()
	{
		InitializeComponent();
        BindingContext = new CustomerVM();
    }
    public TestPage2(string sNote)
    {
        InitializeComponent();
        lblPage2.Text = sNote;
        var dat = new CustomerVM();
        dat.CustomerData.Notes = sNote;
        BindingContext = dat;
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
        //Navigation.PushAsync(new TestPage3());
        var currVM = (CustomerVM)BindingContext;
        var dat = new BMIVM();
        dat.BMI.Notes = txtNote.Text + " = " + currVM.CustomerData.Notes;
        Navigation.PushAsync(new TestPage3
        {
            BindingContext = dat
        }); ;
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}