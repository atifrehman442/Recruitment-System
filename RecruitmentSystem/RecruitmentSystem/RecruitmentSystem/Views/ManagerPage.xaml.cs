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
    public partial class ManagerPage : ContentPage
    {
        private bool BackPressed = false;
        public ManagerPage()
        {
            InitializeComponent();
            this.BindingContext = new JobPostViewModel(Navigation);
        }

        private void TapGestureLogout(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void TapGesturePost(object sender, EventArgs e)
        {
            var jb = (JobPostViewModel)BindingContext;  
            Navigation.PushAsync(new JobPostPage(jb));
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        var Post = e.SelectedItem as JobPostModel;
        //        Utils.SelectPost = Post;
        //        Navigation.PushAsync(new ViewReceiveApplication());
        //    }
            
        //}
        

      
        private void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var job = e.Item as JobPostModel;
            Utils.SelectPost=job;
            Navigation.PushAsync(new ViewReceiveApplication());
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