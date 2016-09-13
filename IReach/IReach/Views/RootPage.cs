using System;
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
	    private Dictionary<MenuType, NavigationPage> Pages;
		public RootPage ( )
		{
			Pages = new Dictionary<MenuType, NavigationPage> ( );
			Master = new MenuPage (this);

			BindingContext = new BaseViewModel
			{
				Title = "IReach",
				Icon = "slideout.png"
			};

			NavigateAsync ( MenuType.Home );
			InvalidateMeasure ( );
		}

		public async Task NavigateAsync ( MenuType id )
		{
			Page newPage = null;
			if ( !Pages.ContainsKey ( id ) )
			{
				switch ( id )
				{
					case MenuType.Home:
						Pages.Add ( id, new IReachNavigationPage ( new HomePage ( ) ) );
						break;  
                    case MenuType.Diet:
                        Pages.Add(id, new IReachNavigationPage(new FoodListPage()));
				        break;
                    case MenuType.BrowseGroup:
                        Pages.Add(id, new IReachNavigationPage(new USDABrowseFoodsPage( ) ) );
                        break;
                    case MenuType.SearchFood:
                        Pages.Add ( id, new IReachNavigationPage ( new USDASearchFoodPage ( ) ) );
                        break;
                    case MenuType.About:
                        Pages.Add ( id, new IReachNavigationPage ( new AboutPage ( ) ) );
                        break;
                }  
			} 
            newPage = Pages[ id ]; 

            if ( Detail != null && Device.OS == TargetPlatform.WinPhone )
                await Detail.Navigation.PopToRootAsync ( );

            Detail = newPage;

            /* TODO: Window Universal App
             * if ( IsUWPDesktop )
                 return;
            */

            if ( Device.Idiom != TargetIdiom.Tablet )
                IsPresented = false;
         
        }
	}
}
