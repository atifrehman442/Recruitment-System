using RecruitmentSystem.Connect;
using RecruitmentSystem.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RecruitmentSystem.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection db;
        public SignUpModel signupmodel;
        
        public SignUpViewModel(INavigation navigation)
        {
            Navigation = navigation;
            db = DependencyService.Get<Iconnect>().GetConnection();
            db.CreateTable<SignUpModel>();
        }

        public Command CommandSignUp
        {
            get
            {
                return new Command(async () =>
                {
                   try
                   {
                    signupmodel = new SignUpModel();
                    signupmodel.Fullname = Fullname;
                    signupmodel.Email = Email;
                    signupmodel.Phone = Phone;
                    signupmodel.User = User;
                    signupmodel.Password = Password;
                       

                        if (Fullname != null && Email != null && Phone != null && User != null && Password != null && Confirmpassword != null )
                    {
                         
                        string PhoneRegularExpresion = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{5,5}$";
                        bool phone = Regex.IsMatch(Phone, PhoneRegularExpresion);
                        string emailRegularExpresion = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                        bool email = Regex.IsMatch(Email, emailRegularExpresion);

                        var data = db.Table<SignUpModel>().ToList();
                        var isUser = data.Where(x => x.Email == Email).FirstOrDefault();

                        if (isUser == null && email==true && phone == true)
                        {

                            if (Confirmpassword == Password)
                            {
                                   
                                db.Insert(signupmodel);
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Alert", "Password not match", "OK");
                            }
                        }
                        else
                        {
                                if (email == true || phone == true)
                                {
                                    if (email == false)
                                    {
                                        await Application.Current.MainPage.DisplayAlert("Alert", "Email is incorrect ", "OK");
                                    }
                                    if (phone == false)
                                    {
                                        await Application.Current.MainPage.DisplayAlert("Alert", "Phone number is incorrect ", "OK");
                                    }
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Alert", "Email & Phone number is incorrect", "OK");
                                }
                            }

                    }
                    else
                    {
                            if (Fullname == null)
                            {
                                FullNameAlertMessage = ValidationMessage.Message;
                            }
                            if (Email == null)
                            {
                                EmailAlertMessage = ValidationMessage.Message;
                            }
                            if (Phone == null)
                            {
                                PhoneAlertMessage = ValidationMessage.Message;
                            }
                            if (User == null)
                            {
                                UserAlertMessage = ValidationMessage.Message; ;
                            }
                            if (Password == null)
                            {
                                PasswordAlertMessage = ValidationMessage.Message;
                            }
                            if (Confirmpassword == null)
                            {
                                ConfirmPasswordAlertMessage = ValidationMessage.Message;
                            }
                            //string[] valid = { Fullname, Email, Phone, User, Password, Confirmpassword };
                            //foreach (string s in valid)
                            //{
                            //    if (s == null)
                            //    {
                            //        var aa = ValidationMessage.Message;
                            //    }
                            //}
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                });
            }

        }


        string _fullname;
        public string Fullname
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;

                OnPropertyChanged();
            }
        }

        string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        string _confirmpassword;
        public string Confirmpassword
        {
            get
            {
                return _confirmpassword;
            }
            set
            {
                _confirmpassword = value;
                OnPropertyChanged();
            }
        }



        string _FullNameAlertMessage;
        public string FullNameAlertMessage
        {
            get
            {
                return _FullNameAlertMessage;
            }
            set
            {
                _FullNameAlertMessage = value;
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

        string _PhoneAlertMessage;
        public string PhoneAlertMessage
        {
            get
            {
                return _PhoneAlertMessage;
            }
            set
            {
                _PhoneAlertMessage = value;
                OnPropertyChanged();
            }
        }

        string __UserAlertMessage;
        public string UserAlertMessage
        {
            get
            {
                return __UserAlertMessage;
            }
            set
            {
                __UserAlertMessage = value;
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

        string _ConfirmPasswordAlertMessage;
        public string ConfirmPasswordAlertMessage
        {
            get
            {
                return _ConfirmPasswordAlertMessage;
            }
            set
            {
                _ConfirmPasswordAlertMessage = value;
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
