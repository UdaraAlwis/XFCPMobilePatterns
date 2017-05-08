using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());
        public static QuoteManager Instance { get { return instance.Value; } }

        readonly IQuoteLoader loader;
        public IList<GreatQuote> Quotes { get; private set; }

        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuote>(loader.Load());
        }

        public void SayQuote(GreatQuote quote)
        {
            if (quote == null)
                throw new ArgumentNullException("quote");

            ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();
            if (tts != null)
            {
                string text = quote.QuoteText;
                if (!string.IsNullOrWhiteSpace(quote.Author))
                {
                    text += " by " + quote.Author;
                }
                tts.Speak(text);
            }
        }

        public void Save()
        {
            loader.Save(Quotes);
        }
    }
}
