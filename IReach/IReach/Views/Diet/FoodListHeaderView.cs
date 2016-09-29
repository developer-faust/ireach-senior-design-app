using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using IReach.Statics;
using Xamarin.Forms;

namespace IReach.Views.Diet
{
    public class FoodListHeaderView : ContentView
    {
        private readonly Command _NewFoodTappedCommand;

        public FoodListHeaderView(Command newFoodTappedCommand)
        {
            _NewFoodTappedCommand = newFoodTappedCommand;
            
            #region title label
            Label headerTitleLabel = new Label()
            {
                Text = TextResources.Foods_FoodListHeaderTitle.ToUpperInvariant(),
                TextColor = Palette._003,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };
            #endregion

            #region new lead image "button"
            var newFoodImage = new Image
            {
                Source = new FileImageSource { File = Device.OnPlatform("add_ios_gray", "add_android_gray", null) },
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            //Going to use FAB
            newFoodImage.IsVisible = false;
            newFoodImage.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = _NewFoodTappedCommand,
                NumberOfTapsRequired = 1
            });
            #endregion


            #region absolutLayout
            AbsoluteLayout absolutLayout = new AbsoluteLayout();

            absolutLayout.Children.Add(
                headerTitleLabel,
                new Rectangle(0, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize),
                AbsoluteLayoutFlags.PositionProportional);

            absolutLayout.Children.Add(
                newFoodImage,
                new Rectangle(1, .5, AbsoluteLayout.AutoSize, .5),
                AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional);
            #endregion

            #region setup contentView
            ContentView contentView = new ContentView()
            {
                Padding = new Thickness(10, 0), // give the content some padding on the left and right
                HeightRequest = RowSizes.MediumRowHeightDouble, // set the height of the content view
            };
            #endregion

            #region compose the view hierarchy
            contentView.Content = absolutLayout;
            #endregion

            Content = contentView;
        }
    }
}
