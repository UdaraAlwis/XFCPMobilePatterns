using System.Collections.Generic;

namespace GreatQuotes
{
	public interface IQuoteLoader
	{
	    IEnumerable<GreatQuote> Load();
	    void Save(IEnumerable<GreatQuote> quotes);
	}
}