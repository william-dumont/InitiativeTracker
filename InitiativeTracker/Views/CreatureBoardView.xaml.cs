using DataLayer.Models;
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
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<Creature>), typeof(CreatureBoardView));
        public IEnumerable<Creature> ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as IEnumerable<Creature>;
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly BindableProperty AddCreatureCommandProperty = BindableProperty.Create(nameof(AddCreatureCommand), typeof(ICommand), typeof(CreatureBoardView));
        public ICommand AddCreatureCommand
        {
            get => GetValue(AddCreatureCommandProperty) as ICommand;
            set
            {
                SetValue(AddCreatureCommandProperty, value);
            }
        }

        public CreatureBoardView()
        {
            InitializeComponent();
        }
    }
}