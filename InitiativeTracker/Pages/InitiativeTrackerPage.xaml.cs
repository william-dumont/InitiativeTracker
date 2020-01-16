using InitiativeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InitiativeTracker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitiativeTrackerPage : ContentPage
    {
        public InitiativeTrackerPage()
        {
            InitializeComponent();

            BindingContext = new InitiativeTrackerViewModel();
        }
    }
}