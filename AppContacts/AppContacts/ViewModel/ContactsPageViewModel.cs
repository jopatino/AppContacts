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
        public Contact CurrentContact { get; set; }
        public INavigation Navigation { get; set; }
        public Command ItemTappedCommand { get; }

        ItemTappedCommand = new Command(async() => GoToDetailContact(CurrentContact));

        public ContactsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task.Run(async () => contactsList = await App.DataBase.GetAllGroupedAsync()).Wait();
            AddContactCommand = new Command(
                async () => await GoToDetailContact()
                );
            ItemTappedCommand = new Command(async () => GoToDetailContact(CurrentContact));
        }

        private async Task GoToDetailContact(Contact contact = null)
        {
            if(contact == null)
            {
                await Navigation.PushAsync(new ContactDetailPage());
            }
            else
            {
                await Navigation.PushAsync(new ContactDetailPage(CurrentContact));
            }
            
        }
    }
}
