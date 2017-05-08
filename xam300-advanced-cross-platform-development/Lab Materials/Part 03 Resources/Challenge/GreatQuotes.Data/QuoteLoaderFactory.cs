using System;

namespace GreatQuotes
{
    public static class QuoteLoaderFactory
    {
        public static Func<IQuoteLoader> Create { get; set; }
    }
}
