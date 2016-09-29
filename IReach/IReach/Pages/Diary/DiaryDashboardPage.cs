using System.Diagnostics;
using IReach.Localization;
using IReach.Pages.Splash;
using IReach.Statics;
using IReach.ViewModels.Diary;
using IReach.Views;
using IReach.Views.Diary;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Models.Local;
using IReach.Pages.Food;
using IReach.Services;
using IReach.ViewModels.Diet;

namespace IReach.Pages.Diary
{
    public class DiaryDashboardPage : ContentPage
    {
        private ScrollView _scrollView;
        private FloatingActionButtonView _fab;

        private DiaryDashboardChartViewModel _DiaryDashboardChartViewModel { get; set; } 
        private DiaryDashboardFoodsViewModel _DiaryDashboardFoodsViewModel { get; set; }

        private IAuthenticationService _AuthenticationService;

        // Construction
        public DiaryDashboardPage()
        {
            _AuthenticationService = DependencyService.Get<IAuthenticationService>();

            this.SetBinding(Page.TitleProperty, new Binding() { Source = TextResources.Diary });

            var foodsChartView = new DiaryDashboardChartView()
            {
                BindingContext = _DiaryDashboardChartViewModel = new DiaryDashboardChartViewModel()
            };


            // Bind FoodsView to ViewModel and Populate the list
            var foodsView = new FoodsView
            {
                BindingContext =
                    _DiaryDashboardFoodsViewModel =
                        new DiaryDashboardFoodsViewModel(new Command(PushTabbedFoodPageAction))
            };

            _scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children =
                    {
                        new Label()
                        {
                            Text = "Hello From ChartView"
                        },
                        foodsChartView,
                        foodsView
                    }
                }

            };

            if (Device.OS == TargetPlatform.Android)
            {
                _fab = new FloatingActionButtonView
                {
                    ImageName = "fab_add.png",
                    ColorNormal = Palette._001,
                    ColorPressed = Palette._002,
                    ColorRipple = Palette._001,

                    Clicked = async (sender, args) =>
                    {
                        // TODO: Implement click action


                        DateTime now = DateTime.UtcNow; 
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                now = now.AddDays(j);
                                DateTime today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);

                                var item = new FoodItem()
                                {
                                    Name = $"TestItem week{i + 1} day{j + 1}",
                                    Calories = 100 * j+1,
                                    DateCreated = today.AddDays(j),
                                    Servings = 1,
                                    MealType = MealTypeOption.All
                                };

                                await App.UserAsyncDb.SaveFoodAsync(item);

                            }
                        }
                    }
                };

                var absoluteLayout = new AbsoluteLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                // Position the pageLayout to fill the entire screen.
                // Manage positioning of child elements on the page by editing the pageLayout.
                AbsoluteLayout.SetLayoutFlags(_scrollView, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(_scrollView, new Rectangle(0f, 0f, 1f, 1f));
                absoluteLayout.Children.Add(_scrollView);

                // Overlay the FAB in the bottom-right corner
                AbsoluteLayout.SetLayoutFlags(_fab, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(_fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                absoluteLayout.Children.Add(_fab);

                Content = absoluteLayout;
            }
            else
            {
                ToolbarItems.Add(new ToolbarItem("Add", "add_ios_gray", () =>
                {
                    _DiaryDashboardFoodsViewModel.PushTabbedFoodPageCommand.Execute(null);
                }));


                Content = _scrollView;
            }


            // Messaging for android devices
            Device.OnPlatform(
                Android: () => MessagingCenter.Subscribe<SplashPage>(this, MessagingServiceConstants.AUTHENTICATED,
                    sender => OnAppearing()));
        }
        Action<object> PushTabbedFoodPageAction
        {
            get { return new Action<object>(o => PushTabbedFoodPage((FoodItem)o));}
        }

        async Task PushTabbedFoodPage(FoodItem food = null)
        {
            FoodDetailViewModel viewModel = new FoodDetailViewModel(Navigation, food);

            var foodDetailPage = new FoodDetailPage()
            {
                BindingContext = viewModel,
                Title = TextResources.Details
            };

            // TODO: IOS Device configuration Icon

            if (food != null)
            {
                foodDetailPage.Title = food.Name.Replace(',', ' '); 
            }
            else
            {
                foodDetailPage.Title = "New Food";
            }

            foodDetailPage.ToolbarItems.Add(
                new ToolbarItem(TextResources.Save, "save.png", async () =>
                {
                    if (string.IsNullOrWhiteSpace(viewModel.Food.Name))
                    {
                        await DisplayAlert("Missing Information", "Please fill in the food name to continue", "OK");
                        return;
                    }

                    var answer = await DisplayAlert(
                        title: TextResources.Foods_SaveConfirmTitle,
                        message: TextResources.Foods_SaveConfirmDescription,
                        accept: TextResources.Save,
                        cancel: TextResources.Cancel);

                    if (answer)
                    {
                        viewModel.SaveFoodCommand.Execute(null);
                        await Navigation.PopAsync();
                    }
                }));

            await Navigation.PushAsync(foodDetailPage);
        }
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Content.IsVisible = true;

            // Load Data for Chart View
            if (!_DiaryDashboardChartViewModel.IsInitialized && _DiaryDashboardFoodsViewModel.Foods != null)
            {
                await _DiaryDashboardChartViewModel.ExecuteLoadSeedDataCommand();
                _DiaryDashboardChartViewModel.IsInitialized = true;
            }

            // Load Foods View Model
            if (!_DiaryDashboardFoodsViewModel.IsInitialized)
            {
                await _DiaryDashboardFoodsViewModel.ExecuteLoadSeedDataCommand();
                _DiaryDashboardFoodsViewModel.IsInitialized = true;
            }
            // TODO: Insight tracking  
        }


    }
}
