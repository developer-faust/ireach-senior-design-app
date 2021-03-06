﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IReach.Models;

namespace IReach.Interfaces
{
    public interface IUserFoodDataService
    {
        Task<ObservableCollection<FoodItem>> GetFoodsAsync();
        Task<FoodItem> GetFoodAsync(int id);
        Task SaveFoodAsync(FoodItem food);
        Task DeleteFoodAsync(int foodId);

        bool IsSeeded { get; }
        Task SeedLocalDataAsync();
    }
}