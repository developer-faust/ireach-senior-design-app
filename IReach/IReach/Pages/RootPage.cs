using System.Collections.Generic;
using System.Threading.Tasks;
using IReach.Controls;
using IReach.Pages.Dashboard;
using IReach.Pages.Fitness;
using IReach.ViewModels.Base;
using IReach.ViewModels.Fitness;
using IReach.Views; 
using Xamarin.Forms;
using FoodLogPage = IReach.Pages.Food.User.FoodLogPage;

namespace IReach.Pages
{
    /// <summary>
    /// RootPage() : Is the Apps main page View. It has a Master (The Hamburger Menu) and the Details Which is pages
    /// that will be show when a menu Item is click.
    /// 
    /// The MenuPage:
    /// Creates a page to hold the items displayed when the Hamburger Icon is clicked.
    /// 
    /// </summary>
	public class RootPage : MasterDetailPage
	{
		/* Todo: Windows Phone
         * public static bool IsUWPDesktop { get; set; }
         */
	    private Dictionary<MenuType, NavigationPage> Pages { get; set; }
		public RootPage ( )
		{
			Pages = new Dictionary<MenuType, NavigationPage> ( );
			Master = new Pages.MenuPage (this);
            
            // The Context of which to Bind Properties in this Page
            // The Base ViewModel Has properties that will be used to notify views of changes.
            // It implements INotifyPropertyChanged
			BindingContext = new BaseViewModel
			{
				Title = "iREACH",
				Icon = "slideout.png"
			};

		    Navigate();
		}

        /// <summary>
        /// Navigates to a new Food Log FoodLog Page as the Default page displayed when App Shows RootPage()
        /// </summary>
	    public async void Navigate()
	    {
            await NavigateAsync(MenuType.FoodLog); 
        }

        /// <summary>
        /// Sets the page displayed to a new page. This is called when a MenuItem is Clicked.
        /// We pass in the Page as a parameter, since Page is the Base Class for all Pages i.e. ContentPage, NavigationPage etc..
        /// We can Easily assign Detail Page any page we want.
        /// </summary>
        /// <param name="page"></param>
	    void SetDetailIfNull(Page page)
	    {
	        if (Detail == null && page != null)
	            Detail = page;
	    }

        /// <summary>
        /// Finds the Page to navigate to base on what MenuItem is Clicked. We pass in the MenuType
        /// Then navigate accordingly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task NavigateAsync ( MenuType id )
		{
			Page newPage;
            IReachNavigationPage page;

            if ( !Pages.ContainsKey ( id ) )
			{
				switch ( id )
				{
					case MenuType.Home: 
                        page =  new IReachNavigationPage(new FoodDashboardPage()); 
                        SetDetailIfNull(page);
                        Pages.Add ( id, page);
						break;

                    case MenuType.Fitness:
                        page = new IReachNavigationPage(new FitnessPage()
                        {
                            BindingContext = new FitnessViewModel()
                        });
				        SetDetailIfNull(page);
				        Pages.Add(id, page);
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
