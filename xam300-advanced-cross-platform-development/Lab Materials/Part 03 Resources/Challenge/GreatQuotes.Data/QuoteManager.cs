using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes
{
    public class QuoteManager
    {
        public static QuoteManager Instance { get; private set; }

        readonly IQuoteLoader loader;
        readonly ITextToSpeech tts;
        public IList<GreatQuote> Quotes { get; private set; }

        public QuoteManager(IQuoteLoader loader, ITextToSpeech tts)
        {
            if (Instance != null)
                throw new Exception("Can only create a single QuoteManager.");
            Instance = this;
            this.loader = loader;
            this.tts = tts;
            Quotes = new ObservableCollection<GreatQuote>(loader.Load());
        }

        public void SayQuote(GreatQuote quote)
        {
            if (quote == null)
                throw new ArgumentNullException("quote");

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
