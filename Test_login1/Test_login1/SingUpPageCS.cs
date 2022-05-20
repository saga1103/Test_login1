using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;


namespace Test_login1
{
    internal class SingUpPageCS: ContentPage
    {
        Entry usernameEntry, passwordEntry, emailEntry;
        Label messageLabel; 
        public SingUpPageCS()
        {
            messageLabel = new Label();
            usernameEntry = new Entry { Placeholder = "username" };
            passwordEntry = new Entry { IsPassword = true };
            emailEntry = new Entry(); var signUpButton = new Button { Text = "Sign Up" };
            signUpButton.Clicked += OnSignUpButtonClicked;
            Title = "Sign Up";
            Content = new StackLayout 
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = { new Label { Text = "Username" },
                    usernameEntry, new Label { Text = "Password" },
                    passwordEntry, new Label { Text = "Email address" },
                    emailEntry, signUpButton, messageLabel } 
            };
        }


        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User() { Username = usernameEntry.Text, Password = passwordEntry.Text, Email = emailEntry.Text };
            // Sign up logic goes here
            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded) 
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null) 
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPageCS(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync(); } } else { messageLabel.Text = "Sign up failed"; 
            }
        }



        // 데이터베이스의 테이블에 넣는 메서드 
        //public void CreateSign() 
        //{
        //    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        //    sqlConnectionStringBuilder.DataSource = "서버IP"; sqlConnectionStringBuilder.InitialCatalog = "DB명";
        //    sqlConnectionStringBuilder.UserID = "계정";
        //    sqlConnectionStringBuilder.Password = "계정암호";
        //    sqlConnectionStringBuilder.IntegratedSecurity = false;
        //    SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        //    conn.Open(); try { string Query = "MERGE USER_MAST";
        //        Query += " USING(SELECT 'X' AS DUAL) AS B ";
        //        Query += " ON [USER_ID] = '" + usernameEntry.Text + "'"; 
        //        Query += " WHEN MATCHED THEN";
        //        Query += " UPDATE SET USER_PSWD = '" + passwordEntry.Text + "'";
        //        Query += " WHEN NOT MATCHED THEN";
        //        Query += " INSERT([USER_ID], USER_PSWD) VALUES ('" + usernameEntry.Text + "','" + passwordEntry.Text + "');";
        //        SqlCommand cmd = new SqlCommand(); 
        //        cmd.Connection = conn;
        //        cmd.CommandText = Query;
        //        cmd.ExecuteNonQuery();
        //        conn.Close(); 
        //    } catch (Exception Ex) { conn.Close(); } finally { conn.Close(); } }

     







        bool AreDetailsValid(User user) 
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@")); 
        }





    }
}
