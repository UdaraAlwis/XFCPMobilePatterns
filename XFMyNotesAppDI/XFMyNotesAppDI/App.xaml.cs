using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace XFMyNotesAppDI
{
    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }

        public App()
        {
            InitializeComponent();

            Container.RegisterInstance(typeof(NoteManager), nameof(NoteManager));

            MainPage = new NavigationPage(new XFMyNotesAppDI.NoteListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
