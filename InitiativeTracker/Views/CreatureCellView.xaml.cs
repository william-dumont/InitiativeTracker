using DataLayer.Models;
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
    public partial class CreatureCellView : ContentView
    {
        public event EventHandler<Creature> OnLowered;
        public event EventHandler<Creature> OnRaised;
        public event EventHandler<Creature> OnAdded;
        public event EventHandler<Creature> OnDeleted;

        public CreatureCellView()
        {
            InitializeComponent();
        }

        void Add(object sender, EventArgs e)
        {
            OnAdded?.Invoke(this, BindingContext as Creature);
        }

        void Delete(object sender, EventArgs e)
        {
            OnDeleted?.Invoke(this, BindingContext as Creature);
        }

        void Lower(object sender, EventArgs e)
        {
            OnLowered?.Invoke(this, BindingContext as Creature);
        }

        void Raise(object sender, EventArgs e)
        {
            OnRaised?.Invoke(this, BindingContext as Creature);
        }
    }
}