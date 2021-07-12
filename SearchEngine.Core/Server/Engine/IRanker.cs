using SearchEngine.Core.Common;

namespace SearchEngine.Core.Server.Engine
{
    public interface IRanker
    {
        void Init(IndexStats stat);
        void ProceedHit(Hit hit);
        double Complete();
    }

    public static class RankerUtils
    {
        public static IRanker CreateRanker(RankerType rankerType)
        {
            return null;
        }
    }
}