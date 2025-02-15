#if NETFRAMEWORK

namespace FastHotKeyForWPF
{
    internal static class FrameworkSupport
    {
        public static int HashCombine(uint h1, uint h2)
        {
            unchecked
            {
                return (int)((h1 << 5) + h1) ^ (int)h2;
            }
        }

        public static int HashCombine(uint h1, uint h2, uint h3)
        {
            unchecked
            {
                int hash = HashCombine(h1, h2);
                hash = (hash << 5) + hash ^ (int)h3;
                return hash;
            }
        }

        public static int HashCombine(uint h1, uint h2, uint h3, uint h4)
        {
            unchecked
            {
                int hash = HashCombine(h1, h2, h3);
                hash = (hash << 5) + hash ^ (int)h4;
                return hash;
            }
        }
    }
}

#endif