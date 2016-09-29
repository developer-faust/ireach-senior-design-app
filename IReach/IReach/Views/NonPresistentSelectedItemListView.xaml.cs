using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IReach.Views
{
    public partial class NonPresistentSelectedItemListView : ListView
    {
        public NonPresistentSelectedItemListView()
        {
            InitializeComponent();

            ItemSelected += (sender, e) => SelectedItem = null;
        }
    }
}
