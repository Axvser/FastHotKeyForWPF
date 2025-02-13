namespace FastHotKeyForWPF
{
    internal class InvisibleHotkeyComponent(uint modifierKeys, uint triggerKeys) : IHotKeyComponent
    {
        public uint ModifierKeys { get; set; } = modifierKeys;
        public uint TriggerKeys { get; set; } = triggerKeys;

        private event HotKeyEventHandler? handlers;
        public virtual event HotKeyEventHandler Handler
        {
            add { handlers += value; }
            remove { handlers -= value; }
        }

        public void Invoke()
        {
            handlers?.Invoke(null, new HotKeyEventArgs(ModifierKeys, TriggerKeys));
        }
        public void Covered()
        {

        }
    }
}
