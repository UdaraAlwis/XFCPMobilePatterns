using Android.App;
using System;
using Android.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		static QuoteLoader quoteLoader;
		public static List<GreatQuote> Quotes { get; private set; }

		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			quoteLoader = new QuoteLoader();
			Quotes = quoteLoader.Load().ToList();
		}

		public static void Save()
		{
			quoteLoader.Save(Quotes);
		}
	}
}

