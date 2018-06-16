using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppContacts.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppContacts.Droid.Services
{
    using System.IO;
    using AppContacts.Droid.Services;
    using Xamarin.Forms;
    public class FileHelper:IFileHelper
    {
        public FileHelper()
        {

        }

        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}