using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Interfaces;
using IReach.Models;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Diary
{
    public class DiaryDashboardFoodsViewModel : BaseViewModel
    {
        IFoodDataService _DataClient;

        Command _LoadSeedDataCommand;
        Command _loadFoodsCommand;

        ObservableCollection<FoodItem> _Foods;
        public Command PushTabbedFoodPageCommand { get; private set; }
        public bool NeedsRefresh { get; set; }

        public DiaryDashboardFoodsViewModel(Command pushTabbedFoodPageCommand, INavigation navigation = null)
            : base(navigation)
        {
            PushTabbedFoodPageCommand = pushTabbedFoodPageCommand;
            _DataClient = DependencyService.Get<IFoodDataService>();
            Foods = new ObservableCollection<FoodItem>();
        }

        public ObservableCollection<FoodItem> Foods
        {
            get { return _Foods; }
            set
            {
                _Foods = value;
                OnPropertyChanged("Foods");
            }
        }
        public async Task ExecuteLoadSeedDataCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            if (!_DataClient.IsSeeded)
            {
                await _DataClient.SeedLocalDataAsync();
            }

            Foods = (await _DataClient.GetFoodsAsync()).ToObservableCollection();

            IsInitialized = true;
            IsBusy = false;
        }

        public Command LoadFoodsCommand
        {
            get
            {
                return _loadFoodsCommand ?? (_loadFoodsCommand = new Command(ExecuteLoadFoodsCommand, () => !IsBusy));
            }
        }

        public async void ExecuteLoadFoodsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            LoadFoodsCommand.ChangeCanExecute();

            Foods.Clear();
            Foods.AddRange(await _DataClient.GetFoodsAsync());

            IsBusy = false;
            LoadFoodsCommand.ChangeCanExecute();
        }
    }
}
