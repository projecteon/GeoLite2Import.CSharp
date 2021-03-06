using System.Collections.Generic;
using System.Linq;

namespace GeoLite2Import.Business
{
    public class ImportCommand<T> : ICommand<IEnumerable<T>> where T: new()
    {
        IEnumerable<string> CsvEntries { get; }

        public ImportCommand(IEnumerable<string> csvEntries)
        {
            CsvEntries = csvEntries;
        }        

        public IEnumerable<T> Execute()
        {
            return CsvEntries.Select(csvEntry => CsvAttributeStringParser.Parse<T>(csvEntry));
        }
    }
}