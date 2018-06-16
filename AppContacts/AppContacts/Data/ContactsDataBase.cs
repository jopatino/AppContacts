using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppContacts.Data
{
    using AppContacts.Helpers;
    using AppContacts.Model;
    using SQLite;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class ContactsDataBase
    {
        private readonly SQLiteAsyncConnection dataBase;
        private object sorted;

        //Crear tabla contactos
        public ContactsDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);

            dataBase.CreateTableAsync<Contact>().Wait();
        }

        //Obtener lista
        public async Task<List<Contact>> GetItemsAsync()
        {
            var data = await dataBase.Table<Contact>().ToListAsync();
            return data;

        }

        public Task<Contact> GetItemAsync(int id)
        {
            var data = dataBase.Table<Contact>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return data;

        }
        public Task<int> SaveItemsAsync(Contact item)
        {
            if(item.Id != 0)
            {
                return dataBase.UpdateAsync(item);
            }
            else
            {
                return dataBase.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemsAsync(Contact item)
        {
            return dataBase.DeleteAsync(item);

        }

        public async Task<ObservableCollection<Grouping<string, Contact>>> GetAllGroupedAsync()
        {
            IList<Contact> contacts = await App.DataBase.GetItemsAsync();
            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];
            if (contacts != null)
            {
                sorted =
                from c in contacts
                orderby c.Nombre
                group c by c.Nombre[0].ToString()
                into theGroup
                select
                new Grouping<string, Contact>
                (theGroup.Key, theGroup);
            }


            return new ObservableCollection<Grouping<string, Contact>>(sorted);
        }
    }
}
