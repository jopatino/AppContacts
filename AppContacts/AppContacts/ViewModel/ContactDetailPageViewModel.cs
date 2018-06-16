using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContactDetailPageViewModel
    {
        public Contact CurrentContact { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            CurrentContact = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
        }

        private async Task SaveContact()
        {
            await App.DataBase.SaveItemsAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            await App.DataBase.DeleteItemsAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }
    }
}
