using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

//namespace Test_login1
//{
//    internal class App
//    {

//    }
//}

namespace Test_login1
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }


        public App()
        {
            if (!IsUserLoggedIn) 
            {
                MainPage = new NavigationPage(new LoginPage());

               
            }
            else 
            {
                MainPage = new NavigationPage(new Test_login1.MainPage()); 
            } 

        }
        
        
        protected override void OnStart()
        {
            // Handle when your app starts

         }
        
        protected override void OnSleep ()
        { // Handle when your app sleeps
        }



        protected override void OnResume()
        { // Handle when your app resumes
        }
       
    }
    }

