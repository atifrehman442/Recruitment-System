using RecruitmentSystem.Connect;
using RecruitmentSystem.Model;
using RecruitmentSystem.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace RecruitmentSystem.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection db;
        public JobPostModel jobpostmodel;
        public ApplicationModel applicationmodel;
        private INavigation navigation;
        public ObservableCollection<JobPostModel> AllJobs { get; set; } = new ObservableCollection<JobPostModel>();
        public ObservableCollection<ApplicationModel> ViewApplication { get; set; } = new ObservableCollection<ApplicationModel>();
        public ApplicationViewModel(INavigation navigation)
        {
            db = DependencyService.Get<Iconnect>().GetConnection();
            db.CreateTable<JobPostModel>();
            db.CreateTable<ApplicationModel>();
            Navigation = navigation;

            GetJobApplicant();
            GetApplyApplication();
        }

        //Get AllJobs

        #region GetJobApplicant
        private void GetJobApplicant()
        {
            try
            {
                var AllJobsData = db.Table<JobPostModel>().ToList();
                foreach (var job in AllJobsData)
                {
                    AllJobs.Add(job);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Applicant Apply Job

        #region ApplyCommand
        public Command ApplyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        applicationmodel = new ApplicationModel();
                        applicationmodel.Qualification = Qualification;
                        applicationmodel.CurrentlyEmployee = CurrentlyEmployee;
                        applicationmodel.CurrentSalary = CurrentSalary;
                        applicationmodel.ExpectedSalary = ExpectedSalary;
                        applicationmodel.Relocate = Relocate;
                        applicationmodel.ManagerName = Utils.SelectManager.UserName;
                        applicationmodel.PostName = Utils.SelectManager.JobTitle;
                        applicationmodel.ApplicantName = Utils.LogInUser.Fullname;

                        if (Qualification != null && CurrentlyEmployee != null && CurrentSalary != null && ExpectedSalary != null && Relocate != null )
                        {
                            var Inserted = db.Insert(applicationmodel);
                            if (Inserted > 0)
                            {
                                await Application.Current.MainPage.DisplayAlert("", " Apply successfully", "OK");
                                await Navigation.PopAsync();
                            }
                        }
                        else
                        {

                            if (Qualification == null)
                            {
                                QualificationAlertMessage = ValidationMessage.Message;
                            }
                            if (CurrentlyEmployee == null)
                            {
                                CurrentlyEmployeeAlertMessage = ValidationMessage.Message;
                            }
                            if (CurrentSalary == null)
                            {
                                CurrentSalaryAlertMessage = ValidationMessage.Message;
                            }
                            if (ExpectedSalary == null)
                            {
                                ExpectedSalaryAlertMessage = ValidationMessage.Message;
                            }
                            if (Relocate == null)
                            {
                                RelocateAlertMessage = ValidationMessage.Message;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                });
            }
        }
        #endregion


        //Get Apply Application

        #region GetApplyApplication
        private void GetApplyApplication()
        {
            try
            {
                var Applicant = Utils.LogInUser.Fullname;

                var ApplicationData = db.Table<ApplicationModel>().Where(x => x.ApplicantName == Applicant).ToList();
                foreach (var app in ApplicationData)
                {
                    ViewApplication.Add(app);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        string _Qualification;
        public string Qualification
        {
            get
            {
                return _Qualification;
            }
            set
            {
                _Qualification = value;

                OnPropertyChanged();
            }
        }

        string _CurrentlyEmployee;
        public string CurrentlyEmployee
        {
            get
            {
                return _CurrentlyEmployee;
            }
            set
            {
                _CurrentlyEmployee = value;
                OnPropertyChanged();
            }
        }

        string _CurrentSalary;
        public string CurrentSalary
        {
            get
            {
                return _CurrentSalary;
            }
            set
            {
                _CurrentSalary = value;
                OnPropertyChanged();
            }
        }

        string _ExpectedSalary;
        public string ExpectedSalary
        {
            get
            {
                return _ExpectedSalary;
            }
            set
            {
                _ExpectedSalary = value;
                OnPropertyChanged();
            }
        }

        string _Relocate;
        public string Relocate
        {
            get
            {
                return _Relocate;
            }
            set
            {
                _Relocate = value;
                OnPropertyChanged();
            }
        }



        string _QualificationAlertMessagee;
        public string QualificationAlertMessage
        {
            get
            {
                return _QualificationAlertMessagee;
            }
            set
            {
                _QualificationAlertMessagee = value;

                OnPropertyChanged();
            }
        }

        string _CurrentlyEmployeeAlertMessage;
        public string CurrentlyEmployeeAlertMessage
        {
            get
            {
                return _CurrentlyEmployeeAlertMessage;
            }
            set
            {
                _CurrentlyEmployeeAlertMessage = value;
                OnPropertyChanged();
            }
        }

        string _CurrentSalaryAlertMessage;
        public string CurrentSalaryAlertMessage
        {
            get
            {
                return _CurrentSalaryAlertMessage;
            }
            set
            {
                _CurrentSalaryAlertMessage = value;

                OnPropertyChanged();
            }
        }

        string _ExpectedSalaryAlertMessage;
        public string ExpectedSalaryAlertMessage
        {
            get
            {
                return _ExpectedSalaryAlertMessage;
            }
            set
            {
                _ExpectedSalaryAlertMessage = value;
                OnPropertyChanged();
            }
        }

        string _RelocateAlertMessage;
        public string RelocateAlertMessage
        {
            get
            {
                return _RelocateAlertMessage;
            }
            set
            {
                _RelocateAlertMessage = value;
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
