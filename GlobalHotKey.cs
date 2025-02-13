using System.Runtime.InteropServices;
using System.Windows;
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
        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static IntPtr WindowhWnd = IntPtr.Zero;
        private static HwndSource? source;
        private static bool IsAwaked = false;

        private static Dictionary<int, IHotKeyComponent> Components { get; set; } = [];
        private static Queue<Tuple<uint, uint, ICollection<HotKeyEventHandler>>> WaitToBeRegistered { get; set; } = [];

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
                while (WaitToBeRegistered.Count > 0)
                {
                    if (WaitToBeRegistered.TryDequeue(out var meta))
                    {
                        Register(meta.Item1, meta.Item2, meta.Item3);
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
            source?.RemoveHook(new HwndSourceHook(WhileKeyInvoked));
            source?.Dispose();
            IsAwaked = false;
        }
        public static int Register(uint modifiers, uint triggers, ICollection<HotKeyEventHandler> handlers)
        {
            Awake();

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
                WaitToBeRegistered.Enqueue(Tuple.Create(modifiers, triggers, handlers));

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
                component.Covered();
            }
            return ureg;
        }

        public static int Register(IHotKeyComponent component)
        {
            Awake();
            var id = 2025 + HashCode.Combine(component.ModifierKeys, component.TriggerKeys);
            UnregisterHotKey(WindowhWnd, id);
            Components.Remove(id);
            if (RegisterHotKey(WindowhWnd, id, component.ModifierKeys, component.TriggerKeys))
            {
                Components.Add(id, component);
                return id;
            }
            return -1;
        }
        public static int Register(ModifierKeys modifierKeys, TriggerKeys triggerKeys, ICollection<HotKeyEventHandler> handlers)
        {
            return Register((uint)modifierKeys, (uint)triggerKeys, handlers);
        }
        public static bool Unregister(ModifierKeys modifierKeys, TriggerKeys triggerKeys)
        {
            return Unregister((uint)modifierKeys, (uint)triggerKeys);
        }
    }
}
