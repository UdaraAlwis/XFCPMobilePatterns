using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XFMyNotesAppSL.Droid
{
    [Activity(Label = "MyNotesSL", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            ServiceLocator.Instance.Add<INoteLoader, NoteLoaderDroid>();
            ServiceLocator.Instance.Add<INoteReader, NoteReaderDroid>();
            
            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            NoteManager.Instance.Save();

            base.OnBackPressed();
        }
        protected override void OnPause()
        {
            base.OnPause();

            NoteManager.Instance.Save();
        }
    }
}

