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
        public DiaryDashboardPage()
        {
            _AuthenticationService = DependencyService.Get<IAuthenticationService>();

            this.SetBinding(Page.TitleProperty, new Binding() { Source = TextResources.Diary });

            var foodsChartView = new DiaryDashboardChartView()
            {
                BindingContext = _DiaryDashboardChartViewModel = new DiaryDashboardChartViewModel()
            };

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

                    Clicked = (sender, args) =>
                    {
                        // TODO: Implement click action
                        Debug.WriteLine("FAB Add Clicked");
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
                    // Todo: Implement IOS click action
                }));


                Content = _scrollView;
            } 


            // Messaging for android devices
            Device.OnPlatform(
                Android: () => MessagingCenter.Subscribe<SplashPage>(this, MessagingServiceConstants.AUTHENTICATED,
                    sender => OnAppearing())); 
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Content.IsVisible = true;

            await _DiaryDashboardFoodsViewModel.ExecuteLoadSeedDataCommand();
            _DiaryDashboardFoodsViewModel.IsInitialized = true;
            // TODO: Insight tracking 
        }

     
    }
}
