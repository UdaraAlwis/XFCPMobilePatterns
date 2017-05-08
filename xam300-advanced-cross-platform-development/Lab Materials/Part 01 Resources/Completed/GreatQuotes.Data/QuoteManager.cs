using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());
        public static QuoteManager Instance { get { return instance.Value; } }

        readonly IQuoteLoader repo;
        public IList<GreatQuote> Quotes { get; private set; }

        private QuoteManager()
        {
            repo = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuote>(repo.Load());
        }

        public void Save()
        {
            repo.Save(Quotes);
        }
    }
}
