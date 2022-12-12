using RizkyApps.Views;

namespace RizkyApps;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new MainPage();

		//================= Test Navigasi
		//MainPage = new NavigationPage( new TestBaru());

        //================= Test Ganti Warna
        //MainPage = new TestRGB();

        //================= Test Angka Angka
        //MainPage = new TestNumberPayment();

        //================= Test Generate Quotes
        //MainPage = new TestGenerateQuotes();

        //================= Test Binding Data
        //MainPage = new TestBinding();

        //================= Test Word Quiz
        //MainPage = new TestWordQuiz();

        //================= Test Model View ViewModel (MVVM)
        MainPage = new TestMVVM();

    }
}
