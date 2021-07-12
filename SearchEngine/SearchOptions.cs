using System.Collections.Generic;

namespace SearchEngine
{
    public class SearchOptions
    {
        public string Stopwords { get; set; }
        public string Wordforms { get; set; }
        
        public List<IndexOption> Indexes { get; set; }
    }

    public class IndexOption
    {
        public string Type { get; set; }
        public string Path { get; set; }
    }
}