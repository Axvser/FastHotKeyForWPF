using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace FastHotKeyForWPF
{
    public enum VirtualModifiers : uint
    {
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008,
        None = 0x0000
    }

    public enum VirtualKeys : uint
    {
        Back = 0x08,
        Tab = 0x09,
        Clear = 0x0C,
        Enter = 0x0D,
        Shift = 0x10,
        Ctrl = 0x11,
        Alt = 0x12,
        Pause = 0x13,
        CapsLock = 0x14,
        Escape = 0x1B,
        Convert = 0x1C,
        NonConvert = 0x1D,
        Accept = 0x1E,
        ModeChange = 0x1F,
        Space = 0x20,
        PageUp = 0x21,
        PageDown = 0x22,
        End = 0x23,
        Home = 0x24,
        LeftArrow = 0x25,
        UpArrow = 0x26,
        RightArrow = 0x27,
        DownArrow = 0x28,
        Select = 0x29,
        Print = 0x2A,
        Execute = 0x2B,
        PrintScreen = 0x2C,
        Insert = 0x2D,
        Delete = 0x2E,
        Help = 0x2F,
        D0 = 0x30,
        D1 = 0x31,
        D2 = 0x32,
        D3 = 0x33,
        D4 = 0x34,
        D5 = 0x35,
        D6 = 0x36,
        D7 = 0x37,
        D8 = 0x38,
        D9 = 0x39,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        LeftWindows = 0x5B,
        RightWindows = 0x5C,
        Apps = 0x5D,
        Sleep = 0x5F,
        NumPad0 = 0x60,
        NumPad1 = 0x61,
        NumPad2 = 0x62,
        NumPad3 = 0x63,
        NumPad4 = 0x64,
        NumPad5 = 0x65,
        NumPad6 = 0x66,
        NumPad7 = 0x67,
        NumPad8 = 0x68,
        NumPad9 = 0x69,
        Multiply = 0x6A,
        Add = 0x6B,
        Separator = 0x6C,
        Subtract = 0x6D,
        Decimal = 0x6E,
        Divide = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        NumLock = 0x90,
        ScrollLock = 0x91,
        LeftShift = 0xA0,
        RightShift = 0xA1,
        LeftCtrl = 0xA2,
        RightCtrl = 0xA3,
        LeftAlt = 0xA4,
        RightAlt = 0xA5,
        BrowserBack = 0xA6,
        BrowserForward = 0xA7,
        BrowserRefresh = 0xA8,
        BrowserStop = 0xA9,
        BrowserSearch = 0xAA,
        BrowserFavorites = 0xAB,
        BrowserHome = 0xAC,
        VolumeMute = 0xAD,
        VolumeDown = 0xAE,
        VolumeUp = 0xAF,
        MediaNextTrack = 0xB0,
        MediaPreviousTrack = 0xB1,
        MediaStop = 0xB2,
        MediaPlayPause = 0xB3,
        LaunchMail = 0xB4,
        LaunchMediaSelect = 0xB5,
        LaunchApp1 = 0xB6,
        LaunchApp2 = 0xB7,
        Semicolon = 0xBA,
        Plus = 0xBB,
        Comma = 0xBC,
        Minus = 0xBD,
        Period = 0xBE,
        Slash = 0xBF,
        GraveAccentAndTilde = 0xC0,
        OpenBracket = 0xDB,
        Backslash = 0xDC,
        CloseBracket = 0xDD,
        Quote = 0xDE,
        OEM_102 = 0xE2,
        ProcessKey = 0xE5,
        Packet = 0xE7,
        Attention = 0xF6,
        CrSel = 0xF7,
        ExSel = 0xF8,
        EraseEOF = 0xF9,
        Play = 0xFA,
        Zoom = 0xFB,
        NoName = 0xFC,
        PA1 = 0xFD,
        OEM_Clear = 0xFE,
        None = 0x0000
    }

    public static class GlobalHotKey
    {
        public static readonly Dictionary<Key, VirtualModifiers> WinApiModifiersMapping = new()
        {
           { Key.LeftShift, VirtualModifiers.Shift },
           { Key.RightShift, VirtualModifiers.Shift },
           { Key.LeftCtrl, VirtualModifiers.Ctrl },
           { Key.RightCtrl, VirtualModifiers.Ctrl },
           { Key.LeftAlt, VirtualModifiers.Alt },
           { Key.RightAlt, VirtualModifiers.Alt },
           { Key.LWin, VirtualModifiers.Win },
           { Key.RWin, VirtualModifiers.Win },
        };

        public static readonly Dictionary<Key, VirtualKeys> WinApiKeysMapping = new()
        {
           { Key.Back, VirtualKeys.Back },
           { Key.Tab, VirtualKeys.Tab },
           { Key.Clear, VirtualKeys.Clear },
           { Key.Enter, VirtualKeys.Enter },
           { Key.Pause, VirtualKeys.Pause },
           { Key.CapsLock, VirtualKeys.CapsLock },
           { Key.Escape, VirtualKeys.Escape },
           { Key.ImeConvert, VirtualKeys.Convert },
           { Key.ImeNonConvert, VirtualKeys.NonConvert },
           { Key.ImeAccept, VirtualKeys.Accept },
           { Key.ImeModeChange, VirtualKeys.ModeChange },
           { Key.Space, VirtualKeys.Space },
           { Key.PageUp, VirtualKeys.PageUp },
           { Key.PageDown, VirtualKeys.PageDown },
           { Key.End, VirtualKeys.End },
           { Key.Home, VirtualKeys.Home },
           { Key.Left, VirtualKeys.LeftArrow },
           { Key.Up, VirtualKeys.UpArrow },
           { Key.Right, VirtualKeys.RightArrow },
           { Key.Down, VirtualKeys.DownArrow },
           { Key.Select, VirtualKeys.Select },
           { Key.Print, VirtualKeys.Print },
           { Key.Execute, VirtualKeys.Execute },
           { Key.PrintScreen, VirtualKeys.PrintScreen },
           { Key.Insert, VirtualKeys.Insert },
           { Key.Delete, VirtualKeys.Delete },
           { Key.Help, VirtualKeys.Help },
           { Key.D0, VirtualKeys.D0 },
           { Key.D1, VirtualKeys.D1 },
           { Key.D2, VirtualKeys.D2 },
           { Key.D3, VirtualKeys.D3 },
           { Key.D4, VirtualKeys.D4 },
           { Key.D5, VirtualKeys.D5 },
           { Key.D6, VirtualKeys.D6 },
           { Key.D7, VirtualKeys.D7 },
           { Key.D8, VirtualKeys.D8 },
           { Key.D9, VirtualKeys.D9 },
           { Key.A, VirtualKeys.A },
           { Key.B, VirtualKeys.B },
           { Key.C, VirtualKeys.C },
           { Key.D, VirtualKeys.D },
           { Key.E, VirtualKeys.E },
           { Key.F, VirtualKeys.F },
           { Key.G, VirtualKeys.G },
           { Key.H, VirtualKeys.H },
           { Key.I, VirtualKeys.I },
           { Key.J, VirtualKeys.J },
           { Key.K, VirtualKeys.K },
           { Key.L, VirtualKeys.L },
           { Key.M, VirtualKeys.M },
           { Key.N, VirtualKeys.N },
           { Key.O, VirtualKeys.O },
           { Key.P, VirtualKeys.P },
           { Key.Q, VirtualKeys.Q },
           { Key.R, VirtualKeys.R },
           { Key.S, VirtualKeys.S },
           { Key.T, VirtualKeys.T },
           { Key.U, VirtualKeys.U },
           { Key.V, VirtualKeys.V },
           { Key.W, VirtualKeys.W },
           { Key.X, VirtualKeys.X },
           { Key.Y, VirtualKeys.Y },
           { Key.Z, VirtualKeys.Z },
           { Key.Apps, VirtualKeys.Apps },
           { Key.Sleep, VirtualKeys.Sleep },
           { Key.NumPad0, VirtualKeys.NumPad0 },
           { Key.NumPad1, VirtualKeys.NumPad1 },
           { Key.NumPad2, VirtualKeys.NumPad2 },
           { Key.NumPad3, VirtualKeys.NumPad3 },
           { Key.NumPad4, VirtualKeys.NumPad4 },
           { Key.NumPad5, VirtualKeys.NumPad5 },
           { Key.NumPad6, VirtualKeys.NumPad6 },
           { Key.NumPad7, VirtualKeys.NumPad7 },
           { Key.NumPad8, VirtualKeys.NumPad8 },
           { Key.NumPad9, VirtualKeys.NumPad9 },
           { Key.Multiply, VirtualKeys.Multiply },
           { Key.Add, VirtualKeys.Add },
           { Key.Subtract, VirtualKeys.Subtract },
           { Key.Decimal, VirtualKeys.Decimal },
           { Key.Divide, VirtualKeys.Divide },
           { Key.F1, VirtualKeys.F1 },
           { Key.F2, VirtualKeys.F2 },
           { Key.F3, VirtualKeys.F3 },
           { Key.F4, VirtualKeys.F4 },
           { Key.F5, VirtualKeys.F5 },
           { Key.F6, VirtualKeys.F6 },
           { Key.F7, VirtualKeys.F7 },
           { Key.F8, VirtualKeys.F8 },
           { Key.F9, VirtualKeys.F9 },
           { Key.F10, VirtualKeys.F10 },
           { Key.F11, VirtualKeys.F11 },
           { Key.F12, VirtualKeys.F12 },
           { Key.F13, VirtualKeys.F13 },
           { Key.F14, VirtualKeys.F14 },
           { Key.F15, VirtualKeys.F15 },
           { Key.F16, VirtualKeys.F16 },
           { Key.F17, VirtualKeys.F17 },
           { Key.F18, VirtualKeys.F18 },
           { Key.F19, VirtualKeys.F19 },
           { Key.F20, VirtualKeys.F20 },
           { Key.F21, VirtualKeys.F21 },
           { Key.F22, VirtualKeys.F22 },
           { Key.F23, VirtualKeys.F23 },
           { Key.F24, VirtualKeys.F24 },
           { Key.NumLock, VirtualKeys.NumLock },
           { Key.Scroll, VirtualKeys.ScrollLock },
           { Key.OemSemicolon, VirtualKeys.Semicolon },
           { Key.OemPlus, VirtualKeys.Plus },
           { Key.OemComma, VirtualKeys.Comma },
           { Key.OemMinus, VirtualKeys.Minus },
           { Key.OemPeriod, VirtualKeys.Period },
           { Key.OemQuestion, VirtualKeys.Slash },
           { Key.OemTilde, VirtualKeys.GraveAccentAndTilde },
           { Key.OemOpenBrackets, VirtualKeys.OpenBracket },
           { Key.OemPipe, VirtualKeys.Backslash },
           { Key.OemCloseBrackets, VirtualKeys.CloseBracket },
           { Key.OemQuotes, VirtualKeys.Quote },
           { Key.OemBackslash, VirtualKeys.OEM_102 },
           { Key.ImeProcessed, VirtualKeys.ProcessKey },
           { Key.OemAttn, VirtualKeys.Attention },
           { Key.CrSel, VirtualKeys.CrSel },
           { Key.ExSel, VirtualKeys.ExSel },
           { Key.EraseEof, VirtualKeys.EraseEOF },
           { Key.Play, VirtualKeys.Play },
           { Key.Zoom, VirtualKeys.Zoom },
           { Key.Pa1, VirtualKeys.PA1 },
           { Key.OemClear, VirtualKeys.OEM_Clear }
        };

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static IntPtr WindowhWnd = IntPtr.Zero;
        private static HwndSource? source;
        public static bool IsAwaked { get; private set; } = false;

        private static Dictionary<int, IHotKeyComponent> Components { get; set; } = [];
        private static Queue<Tuple<uint, uint, ICollection<HotKeyEventHandler>>> WaitToBeRegisteredInvisible { get; set; } = [];
        private static Queue<Tuple<uint, uint, IHotKeyComponent>> WaitToBeRegisteredVisual { get; set; } = [];

        internal const int WM_HOTKEY = 0x0312;
        private static IntPtr WhileKeyInvoked(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_HOTKEY:
                    int id = wParam.ToInt32();

                    if (Components.TryGetValue(id, out var component))
                    {
                        component.Invoke();
                    }

                    handled = true;
                    break;

            }
            return IntPtr.Zero;
        }

        public static void Awake()
        {
            if (IsAwaked) return;

            WindowhWnd = new WindowInteropHelper(Application.Current.MainWindow).Handle;
            if (WindowhWnd != IntPtr.Zero)
            {
                source = HwndSource.FromHwnd(WindowhWnd);
                source.AddHook(new HwndSourceHook(WhileKeyInvoked));
                IsAwaked = true;
                while (WaitToBeRegisteredInvisible.Count > 0)
                {
#if NET5_0_OR_GREATER
                    if (WaitToBeRegisteredInvisible.TryDequeue(out var meta))
                    {
#endif
#if NETFRAMEWORK
                        var meta = WaitToBeRegisteredInvisible.Dequeue();
#endif
                        Register(meta.Item1, meta.Item2, meta.Item3);
#if NET5_0_OR_GREATER
                    }
#endif

                }
                while (WaitToBeRegisteredVisual.Count > 0)
                {
#if NET5_0_OR_GREATER

                    if (WaitToBeRegisteredVisual.TryDequeue(out var meta))
                    {
#endif
#if NETFRAMEWORK
                    var meta = WaitToBeRegisteredVisual.Dequeue();
                    var hash = 2025 + FrameworkSupport.HashCombine(meta.Item1, meta.Item2);
#endif
#if NET5_0_OR_GREATER
                        var hash = 2025 + HashCode.Combine(meta.Item1, meta.Item2);
#endif
                        RegisterHotKey(WindowhWnd, hash, meta.Item1, meta.Item2);
                        if (Components.TryGetValue(hash, out _))
                        {
                            Components[hash] = meta.Item3;
                        }
                        else
                        {
                            Components.Add(hash, meta.Item3);
                        }
#if NET5_0_OR_GREATER
                    }
#endif
                }
            }
        }
        public static void Dispose()
        {
            if (!IsAwaked) return;

            foreach (var component in Components)
            {
                UnregisterHotKey(WindowhWnd, component.Key);
            }
            Components.Clear();
            source?.RemoveHook(new HwndSourceHook(WhileKeyInvoked));
            source?.Dispose();
            IsAwaked = false;
        }

        public static int Register(IHotKeyComponent component)
        {
            if (component.VirtualKeys == 0x0000 || component.VirtualModifiers == 0x0000) return -1;

            if (IsAwaked)
            {
#if NETFRAMEWORK
                var id = 2025 + FrameworkSupport.HashCombine(component.VirtualModifiers, component.VirtualKeys);
#endif
#if NET5_0_OR_GREATER
                var id = 2025 + HashCode.Combine(component.VirtualModifiers, component.VirtualKeys);
#endif
                UnregisterHotKey(WindowhWnd, id);
                if (Components.TryGetValue(id, out var same))
                {
                    Components.Remove(id);
                    same.Covered();
                }
                if (RegisterHotKey(WindowhWnd, id, component.VirtualModifiers, component.VirtualKeys))
                {
                    Components.Add(id, component);
                    return id;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                WaitToBeRegisteredVisual.Enqueue(Tuple.Create(component.VirtualModifiers, component.VirtualKeys, component));
                return 0;
            }
        }

        public static int Register(uint modifiers, uint triggers, ICollection<HotKeyEventHandler> handlers)
        {
            if (modifiers == 0x0000 || triggers == 0x0000) return -1;

            if (IsAwaked)
            {
#if NETFRAMEWORK
                var id = 2025 + FrameworkSupport.HashCombine(modifiers, triggers);
#endif
#if NET5_0_OR_GREATER
                var id = 2025 + HashCode.Combine(modifiers, triggers);
#endif
                Unregister(modifiers, triggers);
                var reg = RegisterHotKey(WindowhWnd, id, modifiers, triggers);

                if (reg)
                {
                    var component = new InvisibleHotkeyComponent(modifiers, triggers);
                    foreach (var handler in handlers)
                    {
                        component.Handler += handler;
                    }
                    Components.Add(id, component);
                }

                return reg ? id : -1;
            }
            else
            {
                WaitToBeRegisteredInvisible.Enqueue(Tuple.Create(modifiers, triggers, handlers));
                return 0;
            }
        }
        public static bool Unregister(uint modifiers, uint triggers)
        {
#if NETFRAMEWORK
            var id = 2025 + FrameworkSupport.HashCombine(modifiers, triggers);
#endif
#if NET5_0_OR_GREATER
            var id = 2025 + HashCode.Combine(modifiers, triggers);
#endif
            var ureg = UnregisterHotKey(WindowhWnd, id);
            if (Components.TryGetValue(id, out _))
            {
                Components.Remove(id);
            }
            return ureg;
        }
        public static int Register(VirtualModifiers modifierKeys, VirtualKeys triggerKeys, ICollection<HotKeyEventHandler> handlers)
        {
            return Register((uint)modifierKeys, (uint)triggerKeys, handlers);
        }
        public static bool Unregister(VirtualModifiers modifierKeys, VirtualKeys triggerKeys)
        {
            return Unregister((uint)modifierKeys, (uint)triggerKeys);
        }

        public static uint GetUint(this ICollection<VirtualModifiers> source)
        {
            return source.Any() ? (uint)source.Aggregate((current, next) => current | next) : 0x0000;
        }
        public static uint GetUint(this ICollection<VirtualKeys> source)
        {
            return source.Any() ? (uint)source.Aggregate((current, next) => current | next) : 0x0000;
        }
        public static IEnumerable<string> GetNames(this ICollection<VirtualModifiers> source)
        {
            return source.Select(m => m.ToString());
        }
    }
}
