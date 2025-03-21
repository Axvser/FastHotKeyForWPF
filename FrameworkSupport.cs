#if NETFRAMEWORK

namespace FastHotKeyForWPF
{
    internal static class FrameworkSupport
    {
        public static int HashCombine(uint h1, uint h2)
        {
            unchecked
            {
                uint rol5 = (h1 << 5) | (h1 >> 27);
                return ((int)rol5 + (int)h1) ^ (int)h2;
            }
        }
    }
}

#endif