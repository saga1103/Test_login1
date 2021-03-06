using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test_login1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e) 
        {
            App.IsUserLoggedIn = false; Navigation.InsertPageBefore(new LoginPage(), this); 
            await Navigation.PopAsync(); 
        }

    }
}
