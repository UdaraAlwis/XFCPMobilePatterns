using Android.App;
using System;
using Android.Runtime;

namespace GreatQuotes
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		readonly SimpleContainer container = new SimpleContainer();

		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
			container.Register<IQuoteLoader, QuoteLoader>();
            container.Register<ITextToSpeech, TextToSpeechService>();
			container.Create<QuoteManager>();

			base.OnCreate();
		}

		public static void Save()
		{
			QuoteManager.Instance.Save();
		}
	}
}

