namespace FastHotKeyForWPF
{
    public delegate void HotKeyEventHandler(object? sender, HotKeyEventArgs e);

    public class HotKeyEventArgs(uint modifiers, uint triggers) : EventArgs
    {
        public uint Modifiers => modifiers;
        public uint Triggers => triggers;

        public ICollection<ModifierKeys> GetModifierKeys()
        {
            List<ModifierKeys> keys = [];
            foreach (ModifierKeys flag in Enum.GetValues(typeof(ModifierKeys)))
            {
                if ((Modifiers & (uint)flag) == (uint)flag && (uint)flag != 0x0000)
                {
                    keys.Add(flag);
                }
            }
            return keys;
        }

        public ICollection<TriggerKeys> GetTriggerKeys()
        {
            List<TriggerKeys> keys = [];
            foreach (TriggerKeys flag in Enum.GetValues(typeof(TriggerKeys)))
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