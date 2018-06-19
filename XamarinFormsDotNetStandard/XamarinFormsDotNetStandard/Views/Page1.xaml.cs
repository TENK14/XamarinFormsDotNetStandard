using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsDotNetStandard.ViewModels;

namespace XamarinFormsDotNetStandard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

			//this.BindingContext = new CustomerViewModel();
			this.BindingContext = new CustomerViewModel(Navigation);
		}
	}
}