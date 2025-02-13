using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace FastHotKeyForWPF
{
    public enum ModifierKeys : uint
    {
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008,
        None = 0x0000
    }

    public enum TriggerKeys : uint
    {
        LeftButton = 0x01,
        RightButton = 0x02,
        Cancel = 0x03,
        MiddleButton = 0x04,
        XButton1 = 0x05,
        XButton2 = 0x06,
        Back = 0x08,
        Tab = 0x09,
        Clear = 0x0C,
        Enter = 0x0D,
        Shift = 0x10,
        Ctrl = 0x11,
        Alt = 0x12,
        Pause = 0x13,
        CapsLock = 0x14,
        Kana = 0x15,
        Hangul = 0x15,
        Junja = 0x17,
        Final = 0x18,
        Hanja = 0x19,
        Kanji = 0x19,
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
        public static readonly Dictionary<Key, ModifierKeys> KeyToModifierWinApiMapping = new()
        {
           { Key.LeftShift, ModifierKeys.Shift },
           { Key.RightShift, ModifierKeys.Shift },
           { Key.LeftCtrl, ModifierKeys.Ctrl },
           { Key.RightCtrl, ModifierKeys.Ctrl },
           { Key.LeftAlt, ModifierKeys.Alt },
           { Key.RightAlt, ModifierKeys.Alt },
           { Key.LWin, ModifierKeys.Win },
           { Key.RWin, ModifierKeys.Win },
        };

        public static readonly Dictionary<Key, TriggerKeys> KeyToTriggerWinApiMapping = new()
        {
           { Key.Cancel, TriggerKeys.Cancel },
           { Key.Back, TriggerKeys.Back },
           { Key.Tab, TriggerKeys.Tab },
           { Key.Clear, TriggerKeys.Clear },
           { Key.Enter, TriggerKeys.Enter },
           { Key.Pause, TriggerKeys.Pause },
           { Key.CapsLock, TriggerKeys.CapsLock },
           { Key.KanaMode, TriggerKeys.Kana },
           { Key.JunjaMode, TriggerKeys.Junja },
           { Key.FinalMode, TriggerKeys.Final },
           { Key.HanjaMode, TriggerKeys.Hanja },
           { Key.Escape, TriggerKeys.Escape },
           { Key.ImeConvert, TriggerKeys.Convert },
           { Key.ImeNonConvert, TriggerKeys.NonConvert },
           { Key.ImeAccept, TriggerKeys.Accept },
           { Key.ImeModeChange, TriggerKeys.ModeChange },
           { Key.Space, TriggerKeys.Space },
           { Key.PageUp, TriggerKeys.PageUp },
           { Key.PageDown, TriggerKeys.PageDown },
           { Key.End, TriggerKeys.End },
           { Key.Home, TriggerKeys.Home },
           { Key.Left, TriggerKeys.LeftArrow },
           { Key.Up, TriggerKeys.UpArrow },
           { Key.Right, TriggerKeys.RightArrow },
           { Key.Down, TriggerKeys.DownArrow },
           { Key.Select, TriggerKeys.Select },
           { Key.Print, TriggerKeys.Print },
           { Key.Execute, TriggerKeys.Execute },
           { Key.PrintScreen, TriggerKeys.PrintScreen },
           { Key.Insert, TriggerKeys.Insert },
           { Key.Delete, TriggerKeys.Delete },
           { Key.Help, TriggerKeys.Help },
           { Key.D0, TriggerKeys.D0 },
           { Key.D1, TriggerKeys.D1 },
           { Key.D2, TriggerKeys.D2 },
           { Key.D3, TriggerKeys.D3 },
           { Key.D4, TriggerKeys.D4 },
           { Key.D5, TriggerKeys.D5 },
           { Key.D6, TriggerKeys.D6 },
           { Key.D7, TriggerKeys.D7 },
           { Key.D8, TriggerKeys.D8 },
           { Key.D9, TriggerKeys.D9 },
           { Key.A, TriggerKeys.A },
           { Key.B, TriggerKeys.B },
           { Key.C, TriggerKeys.C },
           { Key.D, TriggerKeys.D },
           { Key.E, TriggerKeys.E },
           { Key.F, TriggerKeys.F },
           { Key.G, TriggerKeys.G },
           { Key.H, TriggerKeys.H },
           { Key.I, TriggerKeys.I },
           { Key.J, TriggerKeys.J },
           { Key.K, TriggerKeys.K },
           { Key.L, TriggerKeys.L },
           { Key.M, TriggerKeys.M },
           { Key.N, TriggerKeys.N },
           { Key.O, TriggerKeys.O },
           { Key.P, TriggerKeys.P },
           { Key.Q, TriggerKeys.Q },
           { Key.R, TriggerKeys.R },
           { Key.S, TriggerKeys.S },
           { Key.T, TriggerKeys.T },
           { Key.U, TriggerKeys.U },
           { Key.V, TriggerKeys.V },
           { Key.W, TriggerKeys.W },
           { Key.X, TriggerKeys.X },
           { Key.Y, TriggerKeys.Y },
           { Key.Z, TriggerKeys.Z },
           { Key.Apps, TriggerKeys.Apps },
           { Key.Sleep, TriggerKeys.Sleep },
           { Key.NumPad0, TriggerKeys.NumPad0 },
           { Key.NumPad1, TriggerKeys.NumPad1 },
           { Key.NumPad2, TriggerKeys.NumPad2 },
           { Key.NumPad3, TriggerKeys.NumPad3 },
           { Key.NumPad4, TriggerKeys.NumPad4 },
           { Key.NumPad5, TriggerKeys.NumPad5 },
           { Key.NumPad6, TriggerKeys.NumPad6 },
           { Key.NumPad7, TriggerKeys.NumPad7 },
           { Key.NumPad8, TriggerKeys.NumPad8 },
           { Key.NumPad9, TriggerKeys.NumPad9 },
           { Key.Multiply, TriggerKeys.Multiply },
           { Key.Add, TriggerKeys.Add },
           { Key.Subtract, TriggerKeys.Subtract },
           { Key.Decimal, TriggerKeys.Decimal },
           { Key.Divide, TriggerKeys.Divide },
           { Key.F1, TriggerKeys.F1 },
           { Key.F2, TriggerKeys.F2 },
           { Key.F3, TriggerKeys.F3 },
           { Key.F4, TriggerKeys.F4 },
           { Key.F5, TriggerKeys.F5 },
           { Key.F6, TriggerKeys.F6 },
           { Key.F7, TriggerKeys.F7 },
           { Key.F8, TriggerKeys.F8 },
           { Key.F9, TriggerKeys.F9 },
           { Key.F10, TriggerKeys.F10 },
           { Key.F11, TriggerKeys.F11 },
           { Key.F12, TriggerKeys.F12 },
           { Key.F13, TriggerKeys.F13 },
           { Key.F14, TriggerKeys.F14 },
           { Key.F15, TriggerKeys.F15 },
           { Key.F16, TriggerKeys.F16 },
           { Key.F17, TriggerKeys.F17 },
           { Key.F18, TriggerKeys.F18 },
           { Key.F19, TriggerKeys.F19 },
           { Key.F20, TriggerKeys.F20 },
           { Key.F21, TriggerKeys.F21 },
           { Key.F22, TriggerKeys.F22 },
           { Key.F23, TriggerKeys.F23 },
           { Key.F24, TriggerKeys.F24 },
           { Key.NumLock, TriggerKeys.NumLock },
           { Key.Scroll, TriggerKeys.ScrollLock },
           { Key.OemSemicolon, TriggerKeys.Semicolon },
           { Key.OemPlus, TriggerKeys.Plus },
           { Key.OemComma, TriggerKeys.Comma },
           { Key.OemMinus, TriggerKeys.Minus },
           { Key.OemPeriod, TriggerKeys.Period },
           { Key.OemQuestion, TriggerKeys.Slash },
           { Key.OemTilde, TriggerKeys.GraveAccentAndTilde },
           { Key.OemOpenBrackets, TriggerKeys.OpenBracket },
           { Key.OemPipe, TriggerKeys.Backslash },
           { Key.OemCloseBrackets, TriggerKeys.CloseBracket },
           { Key.OemQuotes, TriggerKeys.Quote },
           { Key.OemBackslash, TriggerKeys.OEM_102 },
           { Key.ImeProcessed, TriggerKeys.ProcessKey },
           { Key.OemAttn, TriggerKeys.Attention },
           { Key.CrSel, TriggerKeys.CrSel },
           { Key.ExSel, TriggerKeys.ExSel },
           { Key.EraseEof, TriggerKeys.EraseEOF },
           { Key.Play, TriggerKeys.Play },
           { Key.Zoom, TriggerKeys.Zoom },
           { Key.None, TriggerKeys.None },
           { Key.Pa1, TriggerKeys.PA1 },
           { Key.OemClear, TriggerKeys.OEM_Clear }
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
                    if (WaitToBeRegisteredInvisible.TryDequeue(out var meta))
                    {
                        Register(meta.Item1, meta.Item2, meta.Item3);
                    }
                }
                while (WaitToBeRegisteredVisual.Count > 0)
                {
                    if (WaitToBeRegisteredVisual.TryDequeue(out var meta))
                    {
                        var hash = HashCode.Combine(meta.Item1, meta.Item2);
                        RegisterHotKey(WindowhWnd, hash, meta.Item1, meta.Item2);
                        if (Components.TryGetValue(hash, out _))
                        {
                            Components[hash] = meta.Item3;
                        }
                        else
                        {
                            Components.Add(hash, meta.Item3);
                        }
                    }
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
            if (component.TriggerKeys == 0x0000 || component.ModifierKeys == 0x0000) return -1;

            if (IsAwaked)
            {
                var id = 2025 + HashCode.Combine(component.ModifierKeys, component.TriggerKeys);
                UnregisterHotKey(WindowhWnd, id);
                if (Components.TryGetValue(id, out var same))
                {
                    Components.Remove(id);
                    same.Covered();
                }
                if (RegisterHotKey(WindowhWnd, id, component.ModifierKeys, component.TriggerKeys))
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
                WaitToBeRegisteredVisual.Enqueue(Tuple.Create(component.ModifierKeys, component.TriggerKeys, component));
                return 0;
            }
        }
        public static int Register(uint modifiers, uint triggers, ICollection<HotKeyEventHandler> handlers)
        {
            if (modifiers == 0x0000 || triggers == 0x0000) return -1;

            if (IsAwaked)
            {
                var id = 2025 + HashCode.Combine(modifiers, triggers);
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
            var id = 2025 + HashCode.Combine(modifiers, triggers);
            var ureg = UnregisterHotKey(WindowhWnd, id);
            if (Components.TryGetValue(id, out var component))
            {
                Components.Remove(id);
            }
            return ureg;
        }

        public static int Register(ModifierKeys modifierKeys, TriggerKeys triggerKeys, ICollection<HotKeyEventHandler> handlers)
        {
            return Register((uint)modifierKeys, (uint)triggerKeys, handlers);
        }
        public static bool Unregister(ModifierKeys modifierKeys, TriggerKeys triggerKeys)
        {
            return Unregister((uint)modifierKeys, (uint)triggerKeys);
        }

        public static uint GetUint(this ICollection<ModifierKeys> source)
        {
            uint result = 0x0000;
            foreach (var modifier in source)
            {
                result |= (uint)modifier;
            }
            return result;
        }
        public static IEnumerable<string> GetNames(this ICollection<ModifierKeys> source)
        {
            return source.Select(m => m.ToString());
        }
        public static uint GetUint(this ICollection<TriggerKeys> source)
        {
            uint result = 0x0000;
            foreach (var trigger in source)
            {
                result |= (uint)trigger;
            }
            return result;
        }
        public static IEnumerable<string> GetNames(this ICollection<TriggerKeys> source)
        {
            return source.Select(t => t.ToString());
        }
    }
}
