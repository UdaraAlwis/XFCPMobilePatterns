using System;
using Foundation;
using UIKit;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GreatQuotes
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
        readonly SimpleContainer container = new SimpleContainer();

		public override UIWindow Window { get; set; }

		public override void FinishedLaunching(UIApplication application)
		{
            container.Register<IQuoteLoader, QuoteLoader>();
            container.Register<ITextToSpeech, TextToSpeechService>();
            container.Create<QuoteManager>();
        }

        public override async void DidEnterBackground(UIApplication application)
		{
			CancellationTokenSource cts = new CancellationTokenSource();

			var taskId = UIApplication.SharedApplication.BeginBackgroundTask(() => cts.Cancel());

			try {
				await Task.Run(() => {
					QuoteManager.Instance.Save();
				}, cts.Token);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex.Message);
			}
			finally {
				UIApplication.SharedApplication.EndBackgroundTask(taskId);
			}
		}
	}
}

