using AppContacts.Data;
using AppContacts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppContacts
{
	public partial class App : Application
	{
        private static ContactsDataBase dataBase;
        public static ContactsDataBase DataBase
        {
            get
            {
                if(dataBase == null)
                {
                    try
                    {
                        dataBase = new ContactsDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contacts.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw;
                    }
                }
                return dataBase;
            }
            set
            {
                dataBase = value;
            }
        }
		public App ()
		{
			InitializeComponent();

			MainPage = new AppContacts.View.ContactsPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
