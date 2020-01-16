using DataLayer.Models;
using InitiativeTracker.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InitiativeTracker.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureEditorPopup : PopupPage
    {
        public event EventHandler<Creature> CreatureCreationCancelled;

        Creature creature;
        public Creature Creature
        {
            get => creature;
            set
            {
                creature = value;
                OnPropertyChanged(nameof(Creature));
            }
        }


        public CreatureEditorPopup(Creature creature)
        {
            InitializeComponent();

            Creature = creature;
            BindingContext = Creature;
        }

        void OnCancelled(object sender, EventArgs e)
        {
            CreatureCreationCancelled?.Invoke(this, creature);
        }

        void OnDoneEditing(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}