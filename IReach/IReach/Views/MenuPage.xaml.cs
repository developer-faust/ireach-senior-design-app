﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IReach.Views
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
            ListViewMenu.BackgroundColor = Color.FromHex ("#FFFFFF");

           
			ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
			{
                new HomeMenuItem {Title = "Home", MenuType = MenuType.Home, Icon ="home.png" },
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
