using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InitiativeTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitiativeBoardView : ContentView
    {
        public InitiativeBoardView()
        {
            InitializeComponent();
        }
    }
}