using RecruitmentSystem.Connect;
using RecruitmentSystem.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace RecruitmentSystem.ViewModel
{
    public class JobPostViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection db;
        public JobPostModel jobpostmodel;
        private INavigation navigation;
        public ObservableCollection<JobPostModel> Jobs { get; set; } = new ObservableCollection<JobPostModel>();
        public JobPostViewModel(INavigation navigation)
        {
            db = DependencyService.Get<Iconnect>().GetConnection();
            db.CreateTable<JobPostModel>();
            Navigation = navigation;

            GetJobsManager();
             
        }

        // Create Job
        public Command JobPostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        jobpostmodel = new JobPostModel();
                        jobpostmodel.JobTitle = JobTitle;
                        jobpostmodel.Vacancies = Vacancies;
                        jobpostmodel.UserName = Utils.LogInUser.Fullname;
                        jobpostmodel.Deadline = Deadline.ToString("dd/MM/yyyy");


                        if (JobTitle != null && Vacancies != null && Deadline != null )
                        {
                            var Inserted=db.Insert(jobpostmodel);
                            if (Inserted > 0)
                            {
                                Jobs.Add(jobpostmodel);
                                await Application.Current.MainPage.DisplayAlert("", "Job create successfully", "OK");
                                await Navigation.PopAsync();
                            }                          
                        }
                        else
                        {

                            if (JobTitle == null)
                            {
                                JobTitleAlertMessage = ValidationMessage.Message;
                            }
                            if (Vacancies == null)
                            {
                                VacanciesAlertMessage = ValidationMessage.Message;
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

        //GetJobs
        private void GetJobsManager()
        {
            try
            {
                var Data = db.Table<JobPostModel>().ToList();
                var UserFullname = Utils.LogInUser.Fullname;
                var JobData = Data.Where(x => x.UserName == UserFullname).ToList();
                foreach (var job in JobData)
                {
                    Jobs.Add(job);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        string _JobTitle;
        public string JobTitle
        {
            get
            {
                return _JobTitle;
            }
            set
            {
                _JobTitle = value;

                OnPropertyChanged();
            }
        }

        string _Vacancies;
        public string Vacancies
        {
            get
            {
                return _Vacancies;
            }
            set
            {
                _Vacancies = value;
                OnPropertyChanged();
            }
        }

        DateTime _Deadline;
        public DateTime Deadline
        {
            get
            {
                return _Deadline;
            }
            set
            {
                _Deadline = value;
                OnPropertyChanged();
            }
        }

        string _JobTitleAlertMessage;
        public string JobTitleAlertMessage
        {
            get
            {
                return _JobTitleAlertMessage;
            }
            set
            {
                _JobTitleAlertMessage = value;

                OnPropertyChanged();
            }
        }

        string _VacanciesAlertMessage;
        public string VacanciesAlertMessage
        {
            get
            {
                return _VacanciesAlertMessage;
            }
            set
            {
                _VacanciesAlertMessage = value;
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
