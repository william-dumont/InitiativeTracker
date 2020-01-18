using DataLayer.Models;
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
    }
}