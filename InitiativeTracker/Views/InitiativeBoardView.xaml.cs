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
    public partial class InitiativeBoardView : ContentView
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

        public static readonly BindableProperty RemoveFromBoardCommandProperty = BindableProperty.Create(nameof(RemoveFromBoardCommand), typeof(ICommand), typeof(CreatureBoardView));
        public ICommand RemoveFromBoardCommand
        {
            get => GetValue(RemoveFromBoardCommandProperty) as ICommand;
            set
            {
                SetValue(RemoveFromBoardCommandProperty, value);
            }
        }

        public InitiativeBoardView()
        {
            InitializeComponent();
        }

        void RemoveFromInitiativeBoard(object sender, Creature creature)
        {
            RemoveFromBoardCommand?.Execute(creature);
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

        double width, height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;

                if(width > height)
                {
                    LayoutGrid.RowDefinitions.Clear();
                    LayoutGrid.ColumnDefinitions.Clear();
                    LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5) });
                    LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                    LayoutGrid.Children.Remove(InitiativeView);
                    LayoutGrid.Children.Add(InitiativeView, 0, 0);
                    LayoutGrid.Children.Remove(SeparatorView);
                    LayoutGrid.Children.Add(SeparatorView, 1, 0);
                    LayoutGrid.Children.Remove(ButtonsLayout);
                    LayoutGrid.Children.Add(ButtonsLayout, 2, 0);
                    ButtonsLayout.Orientation = StackOrientation.Vertical;

                } else
                {
                    LayoutGrid.RowDefinitions.Clear();
                    LayoutGrid.ColumnDefinitions.Clear();
                    LayoutGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                    LayoutGrid.Children.Remove(InitiativeView);
                    LayoutGrid.Children.Add(InitiativeView, 0, 0);
                    LayoutGrid.Children.Remove(SeparatorView);
                    LayoutGrid.Children.Add(SeparatorView, 0, 1);
                    LayoutGrid.Children.Remove(ButtonsLayout);
                    LayoutGrid.Children.Add(ButtonsLayout, 0, 2);
                    ButtonsLayout.Orientation = StackOrientation.Horizontal;
                }
            }
        }
    }
}