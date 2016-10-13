using System.Collections.Generic;
using IReach.Views;
using Xamarin.Forms;
using IReach.ViewModels.Base;

namespace IReach.Pages
{
	public partial class MenuPage : ContentPage
	{
		RootPage root;
		List<HomeMenuItem> menuItems;
		public MenuPage (RootPage root)
		{
            this.root = root; 
            InitializeComponent( );
            BindingContext = new BaseViewModel
            {
                Title = "IReach.Forms",
                Subtitle = "IReach.Forms",
                Icon = "slideout.png"
            };


            BackgroundColor = Color.FromHex ("#F44336");
            ListViewMenu.BackgroundColor = Color.FromHex ("#CFD8DC");

           
			ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
			{
                new HomeMenuItem {Title = "Home", MenuType = MenuType.Home, Icon ="home.png" },
                new HomeMenuItem {Title = "Fitness", MenuType = MenuType.Fitness, Icon = "home.png"},
                new HomeMenuItem {Title = "Food Log", MenuType = MenuType.FoodLog, Icon ="diet.png" },  
                new HomeMenuItem {Title = "About", MenuType = MenuType.About, Icon ="about.png" } 
            };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async ( sender, e ) =>
			{
				if ( ListViewMenu.SelectedItem == null )
					return;

				await this.root.NavigateAsync ( ( ( HomeMenuItem )e.SelectedItem ).MenuType );  
			};

            
        }
	}
}
