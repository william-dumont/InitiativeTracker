using DataLayer.Models;
using InitiativeTracker.Other;
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

        ObservableCollection<Creature> creaturesInInitiative;
        public ObservableCollection<Creature> CreaturesInInitiative
        {
            get => creaturesInInitiative;
            set
            {
                creaturesInInitiative = value;
                creaturesInInitiative.CollectionChanged += CreatureLibraryChanged;
                OnPropertyChanged(nameof(CreaturesInInitiative));
            }
        }

        ICommand addToBoardCommand;
        public ICommand AddToBoardCommand
        {
            get => addToBoardCommand;
            set
            {
                addToBoardCommand = value;
                OnPropertyChanged(nameof(AddToBoardCommand));
            }
        }

        ICommand removeFromBoardCommand;
        public ICommand RemoveFromBoardCommand
        {
            get => removeFromBoardCommand;
            set
            {
                removeFromBoardCommand = value;
                OnPropertyChanged(nameof(RemoveFromBoardCommand));
            }
        }

        public InitiativeTrackerViewModel()
        {
            var creatures = DeviceMemory.ReadFromDevice<List<Creature>>("creatures.lib");
            CreatureLibrary = creatures == null ? new ObservableCollection<Creature>() : new ObservableCollection<Creature>(creatures);

            var initiative = DeviceMemory.ReadFromDevice<List<Creature>>("initiative.lib");
            CreaturesInInitiative = creatures == null ? new ObservableCollection<Creature>() : new ObservableCollection<Creature>(creatures);

            AddToBoardCommand = new Command<Creature>(c => AddToInitiativeBoard(c));
            RemoveFromBoardCommand = new Command<Creature>(c => RemoveFromInitiativeBoard(c));
        }

        void CreatureLibraryChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            OnPropertyChanged(nameof(CreatureLibrary));
            DeviceMemory.SaveToDevice(new List<Creature>(CreatureLibrary), "creatures.lib");
        }

        void CreaturesInInitiativeChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CreaturesInInitiative));
            DeviceMemory.SaveToDevice(new List<Creature>(CreatureLibrary), "initiative.lib");
        }

        void AddToInitiativeBoard(Creature creature)
        {
            CreatureLibrary.Remove(creature);
            CreaturesInInitiative.Add(creature);
        }

        void RemoveFromInitiativeBoard(Creature creature)
        {
            CreaturesInInitiative.Remove(creature);
            CreatureLibrary.Add(creature);
        }
    }
}
