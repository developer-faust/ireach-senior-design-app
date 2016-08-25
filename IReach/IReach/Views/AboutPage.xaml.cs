using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

using Xamarin.Forms;

namespace IReach.Views
{
    public partial class AboutPage : ContentPage
    {
        public string Heading;
        public AboutPage ( )
        {
            InitializeComponent ( );

            Heading = "This is about page!";
            // rendering of this page is done natively on each platform
        }

    }
}
