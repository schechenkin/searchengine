using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using SearchEngine.Core.Common;

namespace SearchEngine.Core.Server.Indexes
{
    using IndexMetadata = Dictionary<string, WordMetadata>;
    using IndexData = Dictionary<string, List<Hit>>;
    
    public class RamSegment : Index
    {
        int m_iUsedRam = 0;

        IndexStats mStats;
        IndexMetadata mMetadata;
        IndexData mDataIndex;

        public RamSegment(IndexConfig config)
        {
            using (var reader = new StreamReader(config.IndexDataPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach (var csvRow in csv.GetRecords<CsvRow>())
                {
                    
                }
            }
        }

        public override List<string>  ExecuteSelect(Query query)
        {
            throw new NotImplementedException();
        }
    }
    
    public class CsvRow
    {
        [Name("item_id")]
        public string ItemId { get; set; }
        
        [Name("title")]
        public string Title { get; set; }
        
        [Name("description")]
        public string Description { get; set; }
        
        [Name("price")]
        public decimal Price { get; set; }
        
        [Name("category_id")]
        public int CategoryId { get; set; }
    }
}