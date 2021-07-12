using System.Collections.Generic;

namespace SearchEngine.Core.Common
{
    public class SearchConfig
    {
        public Dictionary<string, IndexConfig> Index { get; set; }
        public string IndexDirectory { get; set; }
    }
}