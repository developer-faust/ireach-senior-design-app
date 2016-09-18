using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach
{
	public enum MenuType
	{
		Home,
        FoodLog, 
        About
    }
	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ( )
		{
			MenuType = MenuType.Home;
		}

		public string Icon { get; set; }
		public MenuType MenuType { get; set; } 
	}
}
