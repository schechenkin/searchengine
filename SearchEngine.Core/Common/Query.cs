using System.Collections.Generic;

namespace SearchEngine.Core.Common
{
    public class Query
    {
	    private string mIndexName;
	    private int mLimit = -1;
	    private List<KeyValuePair<string, int>> mDMatchFieldMask;
	    private RankerType mRankerType;

	    public Query(string indexName, int limit, List<KeyValuePair<string, int>> dMatchFieldMask, RankerType rankerType)
	    {
		    this.mIndexName = indexName;
		    this.mLimit = limit;
		    this.mDMatchFieldMask = dMatchFieldMask;
		    this.mRankerType = rankerType;
	    }
    }
}