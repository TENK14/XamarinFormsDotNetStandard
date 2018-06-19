using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsDotNetStandard
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Navigation.PushAsync(new Views.Page2());
		}
	}
}
