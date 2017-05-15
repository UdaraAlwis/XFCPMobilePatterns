using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Practices.Unity;

namespace XFMyNotesAppDI.Droid
{
    [Activity(Label = "XFMyNotesAppDI", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            App.Container = new UnityContainer();
            App.Container.RegisterType<INoteLoader, NoteLoaderDroid>();
            App.Container.RegisterType<INoteReader, NoteReaderDroid>();

            LoadApplication(new App());
        }
    }
}

