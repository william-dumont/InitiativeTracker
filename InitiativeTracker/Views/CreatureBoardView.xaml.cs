using DataLayer.Models;
using InitiativeTracker.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InitiativeTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureBoardView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList<Creature>), typeof(CreatureBoardView));
        public IList<Creature> ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as IList<Creature>;
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public CreatureBoardView()
        {
            InitializeComponent();
        }

        async void AddCreature(object sender, EventArgs e)
        {
            Creature creature = new Creature();
            ItemsSource.Add(creature);
            RefreshView(null, null);
            CreatureEditorPopup popup = new CreatureEditorPopup() { BindingContext = creature };
            popup.EditionDone += RefreshView;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        void RefreshView(object sender, EventArgs e)
        {
            ItemsView.BatchBegin();
            IList<Creature> creatures = ItemsSource;
            ItemsSource = null;
            ItemsSource = creatures;
            ItemsView.BatchCommit();
        }

        void AddToInitiativeBoard(object sender, Creature creature)
        {

        }

        void DeleteCreature(object sender, Creature creature)
        {
            ItemsSource.Remove(creature);
        }

        void Raise(object sender, Creature creature)
        {
            int index = ItemsSource.IndexOf(creature);
            ItemsSource.Remove(creature);
            ItemsSource.Insert(Math.Max(index - 1, 0), creature);
        }

        void Lower(object sender, Creature creature)
        {
            int index = ItemsSource.IndexOf(creature);
            ItemsSource.Remove(creature);
            ItemsSource.Insert(Math.Min(index + 1, ItemsSource.Count), creature);
        }
    }
}