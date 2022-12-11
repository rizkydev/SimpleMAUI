using RizkyApps.Models;
using System.Xml.Linq;

namespace RizkyApps;

public partial class TestBinding : ContentPage
{
	int iCounter = 0;
	public TestBinding()
	{
		InitializeComponent();
	}

    private void btnEnter_Clicked(object sender, EventArgs e)
    {
		SetBinding();
    }

	private void SetBinding()
	{
		var cust = new Customer
		{
			Id = 1,
			Name = "Rocky",
			Address = "Indo",
			Birthday = new DateTime(1993, 1, 18),
			Notes = "Test"
		};

		if (iCounter == 0)
		{
            //Binding lewat binding C# bukan xaml
            var custBind = new Binding();
            custBind.Source = cust;
            custBind.Path = "Name";
            txtName.SetBinding(Label.TextProperty, custBind);

            //var custBind2 = new Binding();
            //custBind2.Source = cust;
            //custBind2.Path = "Name";
            //txtName2.SetBinding(Label.TextProperty, custBind2);
			iCounter++;
        }
		else if (iCounter == 1)
        {
			//Binding lewat bindingContext per item controller
			cust.Name = "Rocky 2";
            txtName.BindingContext = cust;
            txtName.SetBinding(Label.TextProperty, "Name");

            //txtName2.BindingContext = cust;
            //txtName2.SetBinding(Label.TextProperty, "Name");
            iCounter++;
        }
		else
		{
            cust.Name = "Rocky 3";
			//NOTE : jika SUDAH PERNAH MENGGUNAKAN BINDING MANUAL. maka inisialisasi ini TIDAK BERFUNGSI
            //Binding untuk semua nya
            BindingContext = cust;
        }
	}

}