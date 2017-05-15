using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace XFMyNotesAppSL.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            ServiceLocator.Instance.Add<INoteLoader, NoteLoaderIos>();
            ServiceLocator.Instance.Add<INoteReader, NoteReaderIos>();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override async void DidEnterBackground(UIApplication application)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            var taskId = UIApplication.SharedApplication.BeginBackgroundTask(() => cts.Cancel());

            try
            {
                await Task.Run(() => {
                    NoteManager.Instance.Save();
                }, cts.Token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                UIApplication.SharedApplication.EndBackgroundTask(taskId);
            }
        }
    }
}
