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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new SignUpViewModel(Navigation);
        }

        private void TapGestureSignup(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void FullNameTextChanged(object sender, TextChangedEventArgs e)
        {
            if (FullName.Text != "")
            {
                FullNameAlertMessage.Text = "";
            }
            else
            {
                FullNameAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void EmailTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Email.Text != "")
            {
                EmailAlertMessage.Text = "";
            }
            else
            {
                EmailAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void PhoneTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Phone.Text != "")
            {
                PhoneAlertMessage.Text = "";
            }
            else
            {
                PhoneAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void PasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text != "")
            {
                PasswordAlertMessage.Text = "";
            }
            else
            {
                PasswordAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void ConfirmPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ConfirmPassword.Text != "")
            {
                ConfirmPasswordAlertMessage.Text = "";
            }
            else
            {
                ConfirmPasswordAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void User_SelectedIndexChanged(object sender, EventArgs e)
        {
            var me = User.Title;
            if (me!= "")
            {
                UserAlertMessage.Text = "";
            }
            else
            {
                UserAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void ImageButtonClicked(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;
            if (Password.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("eyeon.png");
                Password.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("eyeoff.png");
                Password.IsPassword = true;
            }
        }

        private void ImageButtonClicked1(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;
            if (ConfirmPassword.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("eyeon.png");
                ConfirmPassword.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("eyeoff.png");
                ConfirmPassword.IsPassword = true;
            }
        }
    }
}