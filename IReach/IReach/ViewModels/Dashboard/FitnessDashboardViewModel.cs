using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Statics;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Dashboard
{
    public class FitnessDashboardViewModel : BaseViewModel
    {

        // Interface for a Fitness Service here

        // A Collection of Fitness Items
        private ObservableCollection<FitnessItem> _Fitness;
        

        // Gets a page relating to a fitness item
        public Command PushTabbedFitnessPageCommand { get; private set; } 

        public FitnessDashboardViewModel(Command pushTabbedFitnessPageCommand, INavigation navigation = null)
            : base(navigation)
        {
            PushTabbedFitnessPageCommand = pushTabbedFitnessPageCommand;

            // Init Fitness Service here

            // Init Fitness Collection
            _Fitness = new ObservableCollection<FitnessItem>();

            // Subscribe to the messaging service
            MessagingCenter.Subscribe<FitnessItem>(this, MessagingServiceConstants.SAVE_FITNESS, (fitness) =>
            {
                var index = Fitness.IndexOf(fitness);
                if (index >= 0)
                {
                    Fitness[index] = fitness;
                }
                else
                {
                    Fitness.Add(fitness);
                }

                Fitness = new ObservableCollection<FitnessItem>(Fitness.OrderBy(n => n.DateOfActivity));
            });

            IsInitialized = false;
        }

        public ObservableCollection<FitnessItem> Fitness
        {
            get { return _Fitness; }
            set
            {
                _Fitness = value;
                OnPropertyChanged("Fitness");
            }
        }

        // Load the initial seed data 
        private Command _LoadSeedDataCommand;

        public Command LoadSeedDataCommand
        {
            get
            {
                return _LoadSeedDataCommand ??
                       (_LoadSeedDataCommand = new Command(async () => await ExecuteLoadSeedDataCommand()));
            }
        }

        public async Task ExecuteLoadSeedDataCommand()
        {
           if(IsBusy)
                return;

            IsBusy =  true; 
            // TODO: Check if data client IsSeeded ?

            // Populate the collection with Fitness Items using FitnessDataService
            // Set Initialized to true
            // Set Busy to false.
        }

        // Command to load Fitness Data
        private Command _loadFitnessCommand;

        public Command LoadFitnessCommand
        {
            get
            {
                return _loadFitnessCommand ??
                       (_loadFitnessCommand = new Command(ExecuteLoadFitnessCommand, () => !IsBusy));
            }
        }

        private async void ExecuteLoadFitnessCommand( )
        {
            
        }
    }
}
