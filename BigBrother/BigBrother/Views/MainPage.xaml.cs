using BigBrother.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BigBrother.Views
{
	public partial class MainPage : CarouselPage
	{
		private string credentials = null;
		public MainPage()
		{
			InitializeComponent();
			if (credentials == null && false)	//TODO: remove && false to get login prompt
			{
				RequestLogin();
			}
		}

		private async void RequestLogin()
		{
			await Navigation.PushModalAsync(new LoginPage());
		}
	}
}