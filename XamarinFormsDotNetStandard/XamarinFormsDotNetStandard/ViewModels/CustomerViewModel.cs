using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsDotNetStandard.Models;
using XamarinFormsDotNetStandard.Services;

namespace XamarinFormsDotNetStandard.ViewModels
{
	public class CustomerViewModel : ViewModelBase
	{
		INavigation navigation;
		public CustomerViewModel(INavigation navigation)
		{
			var service = new CustomerService();
			CustomerList = new ObservableCollection<Customer>(service.GetCustomers());
			this.navigation = navigation;

			AddCommand = new Command(
			execute: () =>
			{
				var arr = Name.Split(',');
				CustomerList.Add(new Customer
				{
					Id = CustomerList.Count + 1,
					FirstName = arr[0],
					LastName = arr.Length > 1 ? arr[1] : string.Empty
				});

				DependencyService.Get<IToast>().Show($"'{Name}' byl přidán.");
				Name = String.Empty;
				RefreshCanExecutes();
			},
			canExecute: () =>
			{
				return !String.IsNullOrWhiteSpace(Name);
			});

			// Bez parametru
			//DeleteItemCommand = new Command(
			//	execute: () =>
			//	{
			//		int test = 0;
			//	},
			//	canExecute: () =>
			//	{
			//		return true;
			//	}
			//);

			// S parametrem
			DeleteItemCommand = new Command<Customer>(
				execute: (Customer arg) =>
				{
					CustomerList.Remove(arg as Customer);
				},
				canExecute: (Customer arg) =>
				{
					return true;
				}
			);

			NextPageCommand = new Command(
				execute: () =>
				{
					navigation.PushAsync(new Views.Page2());
				});
		}

		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				SetProperty(ref name, value);
			}
		}

		private ObservableCollection<Customer> customerList;
		public ObservableCollection<Customer> CustomerList
		{
			get
			{
				return customerList;
			}
			set
			{
				SetProperty(ref customerList, value);
			}
		}

		public ICommand AddCommand { get; private set; }

		public ICommand DeleteItemCommand { get; private set; }
		public ICommand NextPageCommand { get; private set; }

		void RefreshCanExecutes()
		{
			(AddCommand as Command).ChangeCanExecute();
			(DeleteItemCommand as Command).ChangeCanExecute();
			(NextPageCommand as Command).ChangeCanExecute();
		}
	}
}
