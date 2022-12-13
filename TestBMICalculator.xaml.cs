using RizkyApps.ViewModels;
namespace RizkyApps;

public partial class TestBMICalculator : ContentPage
{
	public TestBMICalculator()
	{
		InitializeComponent();
        BindingContext = new BMIVM();
    }
}