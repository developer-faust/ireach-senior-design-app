﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using IReach.Controls;
using Xamarin.Forms;
using MvvmHelpers;

namespace IReach.Views
{
	public class RootPage : MasterDetailPage
	{
		/* Todo: Windows Phone
         * public static bool IsUWPDesktop { get; set; }
         */
	    private Dictionary<MenuType, NavigationPage> Pages { get; set; }
		public RootPage ( )
		{
			Pages = new Dictionary<MenuType, NavigationPage> ( );
			Master = new MenuPage (this);

			BindingContext = new BaseViewModel
			{
				Title = "iREACH",
				Icon = "slideout.png"
			};

		    Navigate();
		}

	    public async void Navigate()
	    {
            await NavigateAsync(MenuType.FoodLog); 
        }

	    void SetDetailIfNull(Page page)
	    {
	        if (Detail == null && page != null)
	            Detail = page;
	    }
		public async Task NavigateAsync ( MenuType id )
		{
			Page newPage;
			if ( !Pages.ContainsKey ( id ) )
			{
				switch ( id )
				{
					case MenuType.Home:

                        var page =  new IReachNavigationPage(new HomePage());

                        SetDetailIfNull(page);
                        Pages.Add ( id, page);
						break;
                    case MenuType.FoodLog:
				        page = new IReachNavigationPage(new FoodLogPage());
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break; 
                    case MenuType.About:

                        page = new IReachNavigationPage(new AboutPage());
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        Pages.Add ( id, page);
                        break;
                }  
			} 
            newPage = Pages[ id ];

		    if (newPage == null)
		        return;

		    if (Detail != null && Device.OS == TargetPlatform.WinPhone)
		    {
		        await Detail.Navigation.PopToRootAsync();
		    }

		    Detail = newPage; 

            if ( Device.Idiom != TargetIdiom.Tablet )
                IsPresented = false;
         
        }
	}
}
