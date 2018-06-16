using System;
using System.Collections.Generic;
using System.Text;

namespace AppContacts.Data
{
    using AppContacts.Model;
    using SQLite;
    public class ContactsDataBase
    {
        private readonly SQLiteAsyncConnection dataBase;

        public ContactsDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);

            dataBase.CreateTableAsync<Contact>().Wait();
        }
    }
}
