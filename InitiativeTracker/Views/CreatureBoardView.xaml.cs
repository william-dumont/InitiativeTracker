using DataLayer.Models;
using InitiativeTracker.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<Creature>), typeof(CreatureBoardView));
        public ObservableCollection<Creature> ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as ObservableCollection<Creature>;
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly BindableProperty AddToBoardCommandProperty = BindableProperty.Create(nameof(AddToBoardCommand), typeof(ICommand), typeof(CreatureBoardView));
        public ICommand AddToBoardCommand
        {
            get => GetValue(AddToBoardCommandProperty) as ICommand;
            set
            {
                SetValue(AddToBoardCommandProperty, value);
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
            await PopupNavigation.Instance.PushAsync(new CreatureEditorPopup() { BindingContext = creature });
        }

        void AddToInitiativeBoard(object sender, Creature creature)
        {
            AddToBoardCommand?.Execute(creature);
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

        async void EditCreature(object sender, Creature e)
        {
            await PopupNavigation.Instance.PushAsync(new CreatureEditorPopup() { BindingContext = e });
        }
    }
}