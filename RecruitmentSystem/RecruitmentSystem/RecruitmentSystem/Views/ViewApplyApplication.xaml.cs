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
    public partial class ViewApplyApplication : ContentPage
    {
        public ViewApplyApplication()
        {
            InitializeComponent();
            this.BindingContext = new ApplicationViewModel(Navigation);
        }
    }
}