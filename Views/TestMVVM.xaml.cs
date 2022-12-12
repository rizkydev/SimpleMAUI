using RizkyApps.Models;
using RizkyApps.ViewModels;
namespace RizkyApps.Views;

public partial class TestMVVM : ContentPage
{
	public TestMVVM()
	{
		InitializeComponent();
		BindingContext = new CustomerVM();
	}
}