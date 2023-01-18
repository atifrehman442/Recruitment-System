using Microsoft.AppCenter.Crashes;
using RecruitmentSystem.Connect;
using RecruitmentSystem.Model;
using RecruitmentSystem.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace RecruitmentSystem.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection db;
        public SignUpModel signupmodel;
        private INavigation navigation;
        public LoginViewModel(INavigation navigation)
        {
            db = DependencyService.Get<Iconnect>().GetConnection();
            db.CreateTable<SignUpModel>();
            Navigation = navigation;
        }  
        public Command LoginCommand
        {
            get
            {                                                                            
                return new Command(async () =>
                {
                    try
                    {
                        if (EnterEmail != null && EnterPassword != null)
                        {
                            var data = db.Table<SignUpModel>().Where(x => x.Email == EnterEmail && x.Password == EnterPassword).FirstOrDefault();
                            if (data != null)
                            {
                                Utils.LogInUser = data;
                                var SelectedUser = data.User;
                                if (SelectedUser == "Manager")
                                {
                                    Utils.LogInUser = data;
                                    await Navigation.PushAsync(new ManagerPage());
                                }
                                else
                                {
                                    Utils.LogInUser = data;
                                    await Navigation.PushAsync(new ApplicantPage());
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Alert", " Enter valid email & password", "OK");
                            }
                        }
                        else
                        {

                            if (EnterEmail == null)
                            {
                                EmailAlertMessage = ValidationMessage.Message;
                            }
                            if (EnterPassword == null)
                            {
                                PasswordAlertMessage = ValidationMessage.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Crashes.TrackError(ex);
                    }
                });
            }
        }

        string _enterEmail;
        public string EnterEmail
        {
            get
            {
                return _enterEmail;
            }
            set
            {
                _enterEmail = value;
                OnPropertyChanged();
            }
        }

        string _enterPassword;
        public string EnterPassword
        {
            get
            {
                return _enterPassword;
            }
            set
            {
                _enterPassword = value;
                OnPropertyChanged();
            }
        }


        string _EmailAlertMessage;
        public string EmailAlertMessage
        {
            get
            {
                return _EmailAlertMessage;
            }
            set
            {
                _EmailAlertMessage = value;
                OnPropertyChanged();
            }
        }

        string _PasswordAlertMessage;
        public string PasswordAlertMessage
        {
            get
            {
                return _PasswordAlertMessage;
            }
            set
            {
                _PasswordAlertMessage = value;
                OnPropertyChanged();
            }
        }


        public INavigation Navigation { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
