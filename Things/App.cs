using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Things
{
	public class App
	{

		static MainViewModel mainVM;
		static MainViewModel MainVM {
			get {
				return mainVM;
			}set {
				mainVM = value;
			}
		}

		public static Page AddItemPage {
			get;
			set;
		}

		public static Page GetMainPage ()
		{	
			var navigationPage = new NavigationPage ();

			AddItemPage = new AddItemPage () {
				BindingContext = MainVM
			};

			MainVM = new MainViewModel (navigationPage.Navigation);

			var inboxPage = new InboxPage {
				BindingContext = MainVM,
			};

			navigationPage.PushAsync (inboxPage);

			return navigationPage;
		}
	}
}

