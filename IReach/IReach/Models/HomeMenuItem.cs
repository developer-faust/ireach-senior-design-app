﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach
{
	public enum MenuType
	{ 
        Fitness,
        FoodLog, 
        About
    }
	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ( )
		{
			MenuType = MenuType.FoodLog;
		}

		public string Icon { get; set; }
		public MenuType MenuType { get; set; } 
	}
}
