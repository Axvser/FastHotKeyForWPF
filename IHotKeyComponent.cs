namespace FastHotKeyForWPF
{
    public interface IHotKeyComponent
    {
        public uint ModifierKeys { get; set; }
        public uint TriggerKeys { get; set; }

        public event HotKeyEventHandler Handler { add { } remove { } }
        public void Invoke();
        public void Covered();
    }
}
