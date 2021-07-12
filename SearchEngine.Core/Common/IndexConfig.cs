namespace SearchEngine.Core.Common
{
    public class IndexConfig
    {
        public IndexConfig(string indexName, IndexType indexType, string indexDataPath, string pathToStemmer, IndexConfig inherit, string stopwords, string wordForms)
        {
            IndexName = indexName;
            IndexType = indexType;
            IndexDataPath = indexDataPath;
            PathToStemmer = pathToStemmer;
            Inherit = inherit;
            Stopwords = stopwords;
            WordForms = wordForms;
        }

        public string IndexName { get; }
        public IndexType IndexType { get; }
        public string IndexDataPath { get; }
        public string PathToStemmer { get; }
        public IndexConfig Inherit { get; }
        public string Stopwords  { get; }
        public string WordForms  { get; }

        public static IndexConfig DummyIndexConfig(string source, string indexDataPath, string pathToStreamer, IndexConfig inherit, string stopWords, string wordForms)
        {
	        return new IndexConfig("dummy", 
                IndexType.Dummy, 
                indexDataPath, 
                pathToStreamer, 
                inherit, 
                stopWords,
		        wordForms);
        }
    }
}