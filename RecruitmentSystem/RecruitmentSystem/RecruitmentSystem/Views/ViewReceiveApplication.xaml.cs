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
    public partial class ViewReceiveApplication : ContentPage
    {
        public ViewReceiveApplication()
        {
            InitializeComponent();
            this.BindingContext = new ViewReceiveViewModel();
        }
    }
}