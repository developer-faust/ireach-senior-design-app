using IReach.Converters;
using IReach.Localization;
using IReach.Models;
using IReach.Statics;
using IReach.ViewModels.Dashboard;
using IReach.ViewModels.Diary;
using IReach.Views.Base;
using IReach.Views.Diet;
using Xamarin.Forms;

namespace IReach.ViewModels.Foods
{
    public class FoodsView : ModelBoundContentView<FoodsDashboardViewModel>
    {
        public FoodsView()
        {
            #region foods list activity indicator
            var foodListActivityIndicator = new ActivityIndicator()
            {
                HeightRequest = RowSizes.MediumRowHeightDouble
            };

            foodListActivityIndicator.SetBinding(IsEnabledProperty, "IsBusy");
            foodListActivityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            foodListActivityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            #endregion

            #region loading label
            var loadingLabel = new Label()
            {
                Text = TextResources.DiaryDashboard_FoodChart_LoadingLabel,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HeightRequest = RowSizes.MediumRowHeightDouble,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End,
                TextColor = Palette._007
            };
            loadingLabel.SetBinding(IsEnabledProperty, "IsBusy");
            loadingLabel.SetBinding(IsVisibleProperty, "IsBusy");
            #endregion

            #region foods list header
            // FoodListHeaderView is an example of a custom view composed with Xamarin.Forms.
            // It takes an action as a constructor parameter, which will be used by the add new lead button ("+").
            var foodListHeaderView = new FoodListHeaderView(new Command(ExecutePushFoodDetailsTabbedPageCommand));
            foodListHeaderView.SetBinding(IsEnabledProperty, "IsBusy", converter: new InverseBooleanConverter());
            foodListHeaderView.SetBinding(IsVisibleProperty, "IsBusy", converter: new InverseBooleanConverter());
            #endregion

            #region foodsListView
            var foodListView = new FoodsListView();
            foodListView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Foods");
            foodListView.SetBinding(IsEnabledProperty, "IsBusy", converter: new InverseBooleanConverter());
            foodListView.SetBinding(IsVisibleProperty, "IsBusy", converter: new InverseBooleanConverter());

            foodListView.ItemTapped += (sender, e) =>
            {
                FoodItem foodListItem = (FoodItem)e.Item;
                ExecutePushFoodDetailsTabbedPageCommand(foodListItem);
            };
            #endregion


            #region compose view hierarchy
            Content = new StackLayout()
            {
                Spacing = 0,
                Children =
                {
                    foodListHeaderView,
                    loadingLabel,
                    foodListActivityIndicator,
                    foodListView
                }
            };
            #endregion

        }

        private void ExecutePushFoodDetailsTabbedPageCommand(object food = null)
        {
            ViewModel.PushTabbedFoodPageCommand.Execute(food);
        }
    }
}
