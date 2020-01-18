using DataLayer.Models;
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

        double width, height;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;

                if (width > height)
                {
                    InitiativeBoardDefinition.Width = new GridLength(3, GridUnitType.Star);
                } else
                {
                    InitiativeBoardDefinition.Width = new GridLength(2, GridUnitType.Star);
                }
            }
        }
    }
}