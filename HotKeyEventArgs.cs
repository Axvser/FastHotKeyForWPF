namespace FastHotKeyForWPF
{
    public delegate void HotKeyEventHandler(object? sender, HotKeyEventArgs e);

    public class HotKeyEventArgs(uint modifiers, uint triggers) : EventArgs
    {
        public uint Modifiers => modifiers;
        public uint Triggers => triggers;

        public ICollection<VirtualModifiers> GetModifierKeys()
        {
            List<VirtualModifiers> keys = [];
            foreach (VirtualModifiers flag in Enum.GetValues(typeof(VirtualModifiers)))
            {
                if ((Modifiers & (uint)flag) == (uint)flag && (uint)flag != 0x0000)
                {
                    keys.Add(flag);
                }
            }
            return keys;
        }

        public ICollection<VirtualKeys> GetTriggerKeys()
        {
            List<VirtualKeys> keys = [];
            foreach (VirtualKeys flag in Enum.GetValues(typeof(VirtualKeys)))
            {
                if ((Triggers & (uint)flag) == (uint)flag && (uint)flag != 0x0000)
                {
                    keys.Add(flag);
                }
            }
            return keys;
        }
    }
}