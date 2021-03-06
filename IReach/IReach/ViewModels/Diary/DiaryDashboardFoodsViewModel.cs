﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Interfaces;
using IReach.Models;
using IReach.Statics;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Diary
{
    public class DiaryDashboardFoodsViewModel : BaseViewModel
    {
        IUserFoodDataService _DataClient;

        Command _LoadSeedDataCommand;
        Command _loadFoodsCommand;

        ObservableCollection<FoodItem> _Foods;
        public Command PushTabbedFoodPageCommand { get; private set; }
        public bool NeedsRefresh { get; set; }

        public DiaryDashboardFoodsViewModel(Command pushTabbedFoodPageCommand, INavigation navigation = null)
            : base(navigation)
        {
            PushTabbedFoodPageCommand = pushTabbedFoodPageCommand;
            _DataClient = DependencyService.Get<IUserFoodDataService>();
            Foods = new ObservableCollection<FoodItem>();

            MessagingCenter.Subscribe<FoodItem>(this, MessagingServiceConstants.SAVE_FOOD, (food) =>
            {
                var index = Foods.IndexOf(food);
                if (index >= 0)
                {
                    Foods[index] = food;
                }
                else
                {
                    Foods.Add(food);
                }

                Foods = new ObservableCollection<FoodItem>(Foods.OrderBy(n => n.Name));
            });

            IsInitialized = false;
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

            // FOR TESTING
            if (!_DataClient.IsSeeded)
            {
               // await _DataClient.SeedLocalDataAsync();
            }

            Foods = (await _DataClient.GetFoodsAsync()).ToObservableCollection();

            IsInitialized = true;
            IsBusy = false;
        }

        public Command LoadSeedDataCommand
        {
            get
            {
                return _LoadSeedDataCommand ??
                       (_LoadSeedDataCommand = new Command(async () => await ExecuteLoadSeedDataCommand()));
            }
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
