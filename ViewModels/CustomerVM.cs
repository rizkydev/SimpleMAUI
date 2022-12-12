using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RizkyApps.Models;

namespace RizkyApps.ViewModels
{
    internal class CustomerVM
    {
        public Customer CustomerData { get; set; }
        public CustomerVM()
        {
            CustomerData = new Customer()
            {
                Id = -1,
                Name = "RockyCool",
                Address = "Bekasi",
                Birthday = new DateTime(1993, 01, 01),
                Notes = "testing Data MVVM",
                //test convert text to bool
                Recommended = "yes"
            };

            //==========================
            //ini lanjutan ClickCommandShow

            ClickCommandShow = new Command(AlertCommand);
            ClickCommandShow2 = new Command((dat) => App.Current.MainPage.DisplayAlert("Title", "Birthday : " + Convert.ToDateTime(dat).ToString("dd-MMMM-yyyy"), "Ok"));
        }

        //====================================
        //cara membuat command simple menggunakan lamda expression
        //public ICommand ClickCommandShow =>
        //    new Command(() => App.Current.MainPage.DisplayAlert("Title", "Body", "Ok"));

        //cara menjabarkan command tanpa lamda expression
        public ICommand ClickCommandShow { get; }
        public ICommand ClickCommandShow2 { get; }
        private void AlertCommand()
        {
            App.Current.MainPage.DisplayAlert("Title", "Body", "Close");
        }
    }
}
