using System.Collections.Generic;
using SearchEngine.Core.Common;

namespace SearchEngine.Core.Server.Indexes
{
    public abstract class Index
    {
        public abstract List<string> ExecuteSelect(Query query);
    }
}