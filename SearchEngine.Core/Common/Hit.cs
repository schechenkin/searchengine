using System;

namespace SearchEngine.Core.Common
{
    public struct Hit
    {
        public UInt32 DocumentId;
        public UInt16 FieldId;
        public UInt16 HitPos;
    }
}