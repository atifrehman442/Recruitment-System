using RecruitmentSystem.Connect;
using RecruitmentSystem.Model;
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
    public class ViewReceiveViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection db;
        public ApplicationModel applicationmodel;
        public ObservableCollection<ApplicationModel> ReceiveApplication { get; set; } = new ObservableCollection<ApplicationModel>();
        public ViewReceiveViewModel()
        {
            db = DependencyService.Get<Iconnect>().GetConnection();
            db.CreateTable<ApplicationModel>();

            GetReceiveApplication();
        }

        //Get Receive Application

        private void GetReceiveApplication()
        {
            try
            {
                var UserName = Utils.LogInUser.Fullname;
                var JobPost = Utils.SelectPost.JobTitle;
                var ApplicationData = db.Table<ApplicationModel>().Where(x => x.ManagerName == UserName && x.PostName == JobPost).ToList();
                foreach (var app in ApplicationData)
                {
                    ReceiveApplication.Add(app);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

