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
    public partial class ApplicationPage : ContentPage
    {
        public ApplicationPage()
        {
            InitializeComponent();
            this.BindingContext = new ApplicationViewModel(Navigation);
        }

        private void Qualification_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Qualification.Text != "")
            {
                QualificationAlertMessage.Text = "";
            }
            else
            {
                QualificationAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void CurrentlyEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            var me = CurrentlyEmployee.Title;
            if (me != "")
            {
                CurrentlyEmployeeAlertMessage.Text = "";
            }
            else
            {
                CurrentlyEmployeeAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void CurrentSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CurrentSalary.Text != "")
            {
                CurrentSalaryAlertMessage.Text = "";
            }
            else
            {
                CurrentSalaryAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void ExpectedSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExpectedSalary.Text != "")
            {
                ExpectedSalaryAlertMessage.Text = "";
            }
            else
            {
                ExpectedSalaryAlertMessage.Text = ValidationMessage.Message;
            }
        }

        private void Relocate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var me = Relocate.Title;
            if (me != "")
            {
                RelocateAlertMessage.Text = "";
            }
            else
            {
                RelocateAlertMessage.Text = ValidationMessage.Message;
            }
        }
    }
}