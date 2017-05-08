using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes
{
    public class QuoteManager
    {
        public static QuoteManager Instance { get; private set; }

        readonly IQuoteLoader loader;
        public IList<GreatQuote> Quotes { get; private set; }

        public QuoteManager(IQuoteLoader loader)
        {
            if (Instance != null)
                throw new Exception("Can only create a single QuoteManager.");
            Instance = this;
            this.loader = loader;
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
