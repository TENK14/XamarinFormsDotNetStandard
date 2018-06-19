using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsDotNetStandard.Droid.Toast_Android))]
namespace XamarinFormsDotNetStandard.Droid
{
	public class Toast_Android : IToast
	{
		public void Show(string message)
		{
			Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
		}
	}
}