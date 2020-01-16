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

        ICommand addCreatureCommand;
        public ICommand AddCreatureCommand
        {
            get => addCreatureCommand;
            set
            {
                addCreatureCommand = value;
                OnPropertyChanged(nameof(AddCreatureCommand));
            }
        }

        public InitiativeTrackerViewModel()
        {
            CreatureLibrary = new ObservableCollection<Creature>()
            {
                new Creature()
                {
                    Name = "Aura",
                    BackgroundColor = Color.Red,
                    AccentColor = Color.Yellow
                },
                new Creature()
                {
                    Name = "Kree",
                    BackgroundColor = Color.Yellow,
                    AccentColor = Color.White
                },
                new Creature()
                {
                    Name = "Leilani",
                    BackgroundColor = Color.Teal,
                    AccentColor = Color.Blue
                },
                new Creature()
                {
                    Name = "Artur",
                    BackgroundColor = Color.Brown,
                    AccentColor = Color.Green
                }
            };

            AddCreatureCommand = new Command(() => CreateCreature());
        }

        void CreatureLibraryChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            OnPropertyChanged(nameof(CreatureLibrary));
        }

        async void CreateCreature()
        {
            Creature creature = new Creature();
            CreatureLibrary.Add(creature);
            CreatureEditorPopup creatureEditorPopup = new CreatureEditorPopup(creature);
            creatureEditorPopup.CreatureCreationCancelled += CreatureCreationCancelled;
            await PopupNavigation.Instance.PushAsync(new CreatureEditorPopup(creature));
        }

        void CreatureCreationCancelled(object sender, Creature creature)
        {
            CreatureLibrary.Remove(creature);
        }
    }
}
