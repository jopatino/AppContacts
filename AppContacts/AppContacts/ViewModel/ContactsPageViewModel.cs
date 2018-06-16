using AppContacts.Helpers;
using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AppContacts.View;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        public ObservableCollection<Grouping<string, Contact>> contactsList { get; set; }
        public Command AddContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactsPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Task.Run(async () => contactsList = await App.DataBase.GetAllGroupedAsync()).Wait();
            AddContactCommand = new Command(
                async () => await GoToDetailContact()
                );
        }

        private async Task GoToDetailContact()
        {
            await Navigation.PushAsync(new ContactDetailPage);
        }
    }
}
