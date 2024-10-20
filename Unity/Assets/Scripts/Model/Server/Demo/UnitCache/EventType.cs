using System;

namespace ET.Server
{
    public struct LRUUnitCacheDelete
    {
        public EntityRef<LRUCache> LruCache;
        public long Key;
    }

    public struct AddToBytes
    {
        public EntityRef<Unit> Unit;
        public Type Type;
        public byte[] Bytes;
    }
}