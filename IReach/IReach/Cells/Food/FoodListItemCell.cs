using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Statics;
using Xamarin.Forms;

namespace IReach.Cells.Food
{
    public class FoodListItemCell : ViewCell
    {
        public Label FoodNameLabel { get; private set; }
        public Label DateCreatedLabel { get; private set; }
        public Label CalorieAmountLabel { get; private set; }
        public ProgressBar ProgressBar { get; private set; }
        public FoodListItemCell()
        {
            StyleId = "none";

            #region FoodName Label
            FoodNameLabel = new Label()
            {
                TextColor = Palette._006,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) * 1.2,
                VerticalTextAlignment = TextAlignment.End,
                LineBreakMode = LineBreakMode.TailTruncation
            };


            FoodNameLabel.SetBinding(
                Label.TextProperty,
                new Binding("Name"));
            #endregion


            #region DateCreatedLabel Label
            DateCreatedLabel = new Label()
            {
                TextColor = Palette._007,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.End,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            DateCreatedLabel.SetBinding(
                Label.TextProperty,
                new Binding(
                    path:"DateCreated",
                    stringFormat: "{0:MMMM d, yyyy}"));
            #endregion

            #region DateCreatedLabel Label
            CalorieAmountLabel = new Label()
            {
                TextColor = Palette._007,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.End,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            CalorieAmountLabel.SetBinding(
                Label.TextProperty,
                new Binding("Calories"));
            #endregion
            
            var contentView = new ContentView();
            
            // Set padding
            contentView.Padding = new Thickness(10, 0);
            RelativeLayout relativeLayout = new RelativeLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // add the foodNameLabel to the relativeLayout
            relativeLayout.Children.Add(
                view: FoodNameLabel,
                xConstraint:Constraint.RelativeToParent(parent => 0),
                yConstraint:Constraint.RelativeToParent(parent => 0),
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height / 3));

            // add the DateCreated Label to the relativeLayout
            relativeLayout.Children.Add(
               view: DateCreatedLabel,
               xConstraint: Constraint.RelativeToParent(parent => 0),
               yConstraint: Constraint.RelativeToParent(parent => parent.Height / 3),
               widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
               heightConstraint: Constraint.RelativeToParent(parent => parent.Height / 3));

            // add the Calorie Amount Label to the relativeLayout
            relativeLayout.Children.Add(
               view: CalorieAmountLabel,
               xConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
               yConstraint: Constraint.RelativeToParent(parent => 0),
               widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 2),
               heightConstraint: Constraint.RelativeToParent(parent => parent.Height / 3));

            contentView.Content = relativeLayout;

            View = contentView;
        }

    }
}
