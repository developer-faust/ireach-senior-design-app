using IReach.Statics;
using Xamarin.Forms;

namespace IReach.Controls
{
	public class IReachNavigationPage  : NavigationPage
	{
		public IReachNavigationPage ( Page root ) : base(root)
        {
			Init ( );
		}

		public IReachNavigationPage ( )
		{
			Init ( );
		}

		void Init ( )
		{

			BarBackgroundColor = Palette._002;
			BarTextColor = Color.White;
		} 
	}
}
