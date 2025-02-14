namespace FastHotKeyForWPF
{
    public interface IHotKeyComponent
    {
        public uint VirtualModifiers { get; set; }
        public uint VirtualKeys { get; set; }

        public event HotKeyEventHandler Handler { add { } remove { } }
        public void Invoke();
        public void Covered();
    }
}
