using System.Collections.Generic;
using SearchEngine.Core.Common;

namespace SearchEngine.Core.Server.Indexes
{
    public class IndexStorage
    {
        private readonly SearchConfig _searchConfig;
        private Dictionary<string, Index> _indexes;

        public IndexStorage(SearchConfig searchConfig)
        {
            _searchConfig = searchConfig;
            _indexes = new Dictionary<string, Index>();
        }

        public void AttachIndex(string indexName, IndexConfig indexConfig)
        {
            
        }

        public Index GetIndex(string indexName)
        {
            return null;
        }
    }
}