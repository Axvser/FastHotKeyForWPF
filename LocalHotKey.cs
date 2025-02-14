using System.Windows.Input;
using System.Windows;

namespace FastHotKeyForWPF
{
    public static class LocalHotKey
    {
        public static void Register(HashSet<Key> keys, KeyEventHandler keyevent)
        {
            var injector = new LocalHotKeyInjector(Application.Current.MainWindow, keys, keyevent);
            if (LocalHotKeyInjector.Injectors.TryGetValue(Application.Current.MainWindow, out var injectorSet))
            {

                injectorSet.Add(injector);
            }
            else
            {
                LocalHotKeyInjector.Injectors.Add(Application.Current.MainWindow, [injector]);
            }
        }
        public static void Register(IInputElement target, HashSet<Key> keys, KeyEventHandler keyevent)
        {
            var injector = new LocalHotKeyInjector(target, keys, keyevent);
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {

                injectorSet.Add(injector);
            }
            else
            {
                LocalHotKeyInjector.Injectors.Add(target, [injector]);
            }
        }
        public static void Unregister(IInputElement target)
        {
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {
                foreach (var injector in injectorSet)
                {
                    target.KeyDown -= injector.Receiver;
                    target.KeyUp -= injector.ReleaseReceiver;
                    target.MouseLeave -= injector.MouseLeave;
                }
                LocalHotKeyInjector.Injectors.Remove(target);
            }
        }
        public static void Unregister(IInputElement target, HashSet<Key> keys)
        {
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {
                List<LocalHotKeyInjector> removed = [];
                foreach (var injector in injectorSet)
                {
                    if (keys.IsSupersetOf(injector._targetKeys))
                    {
                        target.KeyDown -= injector.Receiver;
                        target.KeyUp -= injector.ReleaseReceiver;
                        target.MouseLeave -= injector.MouseLeave;
                        removed.Add(injector);
                    }
                }

                foreach (var injector in removed)
                {
                    injectorSet.Remove(injector);
                }

                if (!injectorSet.Any()) LocalHotKeyInjector.Injectors.Remove(target);
            }
        }
    }
}
