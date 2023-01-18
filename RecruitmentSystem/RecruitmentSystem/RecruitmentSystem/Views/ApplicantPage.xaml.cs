using Microsoft.AppCenter.Crashes;
using RecruitmentSystem.Model;
using RecruitmentSystem.Services;
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
    public partial class ApplicantPage : ContentPage
    {
        private bool BackPressed = false;
        public ApplicantPage()
        {
            InitializeComponent();
            this.BindingContext = new ApplicationViewModel(Navigation);
        }
        private void TapGestureLogout(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var Manager = e.SelectedItem as JobPostModel;
        //    Utils.SelectManager = Manager;
        //    Navigation.PushAsync(new ApplicationPage());
        //}

        private void ViewApplyApplication(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewApplyApplication());
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var Manager = e.Item as JobPostModel;
            Utils.SelectManager = Manager;
            Navigation.PushAsync(new ApplicationPage());
        }

        protected override bool OnBackButtonPressed()
        {
            try
            {
                if (BackPressed)

                    AppServices.ExitApp();
                AppServices.ShortAlert("Press Again to Exit App");

                BackPressed = true;


            }
            catch (Exception ex) { Crashes.TrackError(ex); }
            return true;
        }
        private async void DoubleTap()
        {
            await Task.Delay(2000);
            BackPressed = false;
        }
    }
}