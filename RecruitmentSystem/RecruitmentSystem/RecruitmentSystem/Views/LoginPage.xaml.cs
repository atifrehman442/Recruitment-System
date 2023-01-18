using RecruitmentSystem.Model;
using RecruitmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecruitmentSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(Navigation);
        }

        private void TapGestureLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;
            if (MyEntry.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("eyeon.png");
                MyEntry.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("eyeoff.png");
                MyEntry.IsPassword = true;
            }
        }

        private void emailentry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emailentry.Text != "")
            {
                EmailAlertMessage.Text = "";
            }
            else
            {
                EmailAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void MyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MyEntry.Text != "")
            {
                PasswordAlertMessage.Text = "";
            }
            else
            {
                PasswordAlertMessage.Text = ValidationMessage.Message;
            }
        }
    }
}
