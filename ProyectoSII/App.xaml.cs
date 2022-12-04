using ProyectoSII.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSII
{
    public partial class App : Application
    {
        static SQLIteHelper _db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public static SQLIteHelper SQLiteDB
        {
            get
            {
                if(_db == null)
                {
                    _db = new SQLIteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) ,"Escueladb3"));
                }
                return _db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
