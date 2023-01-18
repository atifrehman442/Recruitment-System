using RecruitmentSystem.Model;
using RecruitmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace RecruitmentSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobPostPage : ContentPage
    {
        public JobPostPage(JobPostViewModel jobPostViewModel)
        {
            InitializeComponent();
            this.BindingContext = jobPostViewModel;
        }

        private void JobTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
                if (JobTitle.Text != "")
                {
                JobTitleAlertMessage.Text = "";
                }
                else
                {
                JobTitleAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void Vacancies_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Vacancies.Text != "")
            {
                VacanciesAlertMessage.Text = "";
            }
            else
            {
                VacanciesAlertMessage.Text = ValidationMessage.Message;
            }
        }
    }
}