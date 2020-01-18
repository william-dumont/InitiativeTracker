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
    public partial class InitiativeCellView : ContentView
    {
        public event EventHandler<Creature> OnLowered;
        public event EventHandler<Creature> OnRaised;
        public event EventHandler<Creature> OnRemoved;
        public event EventHandler<Creature> OnDeleted;
        public event EventHandler<Creature> OnEdited;

        public InitiativeCellView()
        {
            InitializeComponent();
        }

        void Remove(object sender, EventArgs e)
        {
            OnRemoved?.Invoke(this, BindingContext as Creature);
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

        void Edit(object sender, EventArgs e)
        {
            OnEdited?.Invoke(this, BindingContext as Creature);
        }
    }
}