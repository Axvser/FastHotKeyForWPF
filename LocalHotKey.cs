using System.Windows.Input;
using System.Windows;

namespace FastHotKeyForWPF
{
    public static class LocalHotKey
    {
#if NETFRAMEWORK

        public static void Register(KeyEventHandler keyevent, params Key[] keys)
        {
            var hashset = new HashSet<Key>();
            foreach (var key in keys)
            {
                hashset.Add(key);
            }
            var injector = new LocalHotKeyInjector(Application.Current.MainWindow, hashset, keyevent);
            if (LocalHotKeyInjector.Injectors.TryGetValue(Application.Current.MainWindow, out var injectorSet))
            {
                injectorSet.Add(injector);
            }
            else
            {
                LocalHotKeyInjector.Injectors.Add(Application.Current.MainWindow, [injector]);
            }
        }
        public static void Register(IInputElement target, KeyEventHandler keyevent, params Key[] keys)
        {
            var hashset = new HashSet<Key>();
            foreach (var key in keys)
            {
                hashset.Add(key);
            }
            var injector = new LocalHotKeyInjector(target, hashset, keyevent);
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {

                injectorSet.Add(injector);
            }
            else
            {
                LocalHotKeyInjector.Injectors.Add(target, [injector]);
            }
        }
        public static void Unregister(params Key[] keys)
        {
            var hashset = new HashSet<Key>();
            foreach (var key in keys)
            {
                hashset.Add(key);
            }
            if (LocalHotKeyInjector.Injectors.TryGetValue(Application.Current.MainWindow, out var injectorSet))
            {
                List<LocalHotKeyInjector> removed = [];
                foreach (var injector in injectorSet)
                {
                    if (hashset.IsSupersetOf(injector._targetKeys))
                    {
                        Application.Current.MainWindow.KeyDown -= injector.Receiver;
                        Application.Current.MainWindow.KeyUp -= injector.ReleaseReceiver;
                        Application.Current.MainWindow.MouseLeave -= injector.MouseLeave;
                        removed.Add(injector);
                    }
                }

                foreach (var injector in removed)
                {
                    injectorSet.Remove(injector);
                }

                if (!injectorSet.Any()) LocalHotKeyInjector.Injectors.Remove(Application.Current.MainWindow);
            }
        }
        public static void Unregister(IInputElement target, params Key[] keys)
        {
            var hashset = new HashSet<Key>();
            foreach (var key in keys)
            {
                hashset.Add(key);
            }
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {
                List<LocalHotKeyInjector> removed = [];
                foreach (var injector in injectorSet)
                {
                    if (hashset.IsSupersetOf(injector._targetKeys))
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

#endif
#if NET5_0_OR_GREATER

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
        public static void Register(IInputElement target,HashSet<Key> keys, KeyEventHandler keyevent)
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
        public static void Unregister(HashSet<Key> keys)
        {
            if (LocalHotKeyInjector.Injectors.TryGetValue(Application.Current.MainWindow, out var injectorSet))
            {
                List<LocalHotKeyInjector> removed = [];
                foreach (var injector in injectorSet)
                {
                    if (keys.IsSupersetOf(injector._targetKeys))
                    {
                        Application.Current.MainWindow.KeyDown -= injector.Receiver;
                        Application.Current.MainWindow.KeyUp -= injector.ReleaseReceiver;
                        Application.Current.MainWindow.MouseLeave -= injector.MouseLeave;
                        removed.Add(injector);
                    }
                }

                foreach (var injector in removed)
                {
                    injectorSet.Remove(injector);
                }

                if (!injectorSet.Any()) LocalHotKeyInjector.Injectors.Remove(Application.Current.MainWindow);
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
        public static void Unregister(IInputElement target, ICollection<HashSet<Key>> keysgroup)
        {
            if (LocalHotKeyInjector.Injectors.TryGetValue(target, out var injectorSet))
            {
                foreach (var keys in keysgroup)
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

#endif
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
        public static void Unregister()
        {
            if (LocalHotKeyInjector.Injectors.TryGetValue(Application.Current.MainWindow, out var injectorSet))
            {
                foreach (var injector in injectorSet)
                {
                    Application.Current.MainWindow.KeyDown -= injector.Receiver;
                    Application.Current.MainWindow.KeyUp -= injector.ReleaseReceiver;
                    Application.Current.MainWindow.MouseLeave -= injector.MouseLeave;
                }
                LocalHotKeyInjector.Injectors.Remove(Application.Current.MainWindow);
            }
        }
    }
}
