using DataLayer.Models;
using InitiativeTracker.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace InitiativeTracker.ViewModels
{
    public class InitiativeTrackerViewModel : ViewModelBase
    {
        ObservableCollection<Creature> creatureLibrary;
        public ObservableCollection<Creature> CreatureLibrary
        {
            get => creatureLibrary;
            set
            {
                creatureLibrary = value;
                creatureLibrary.CollectionChanged += CreatureLibraryChanged;
                OnPropertyChanged(nameof(CreatureLibrary));
            }
        }

        public InitiativeTrackerViewModel()
        {
            CreatureLibrary = new ObservableCollection<Creature>()
            {
                new Creature()
                {
                    Name = "Aura"
                },
                new Creature()
                {
                    Name = "Kree"
                },
                new Creature()
                {
                    Name = "Leilani"
                },
                new Creature()
                {
                    Name = "Artur"
                }
            };
        }

        void CreatureLibraryChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            OnPropertyChanged(nameof(CreatureLibrary));
        }
    }
}
