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
        public CreatureEditorPopup()
        {
            InitializeComponent();
        }

        void NameCompleted(object sender, EventArgs e)
        {
            ArmorClassEntry.Focus();
            ArmorClassEntry.SelectionLength = ArmorClassEntry.Text.Length;
        }

        void ArmorClassCompleted(object sender, EventArgs e)
        {
            PassivePerceptionEntry.Focus();
            PassivePerceptionEntry.SelectionLength = PassivePerceptionEntry.Text.Length;
        }

        void PassivePerceptionCompleted(object sender, EventArgs e)
        {
            PassiveInvestigationEntry.Focus();
            PassiveInvestigationEntry.SelectionLength = PassiveInvestigationEntry.Text.Length;
        }

        void PassiveInvestigationCompleted(object sender, EventArgs e)
        {
            PassiveInsightEntry.Focus();
            PassiveInsightEntry.SelectionLength = PassiveInsightEntry.Text.Length;
        }
    }
}