# FastHotKeyForWPF

Build `global hotkeys` elegantly

Get →

- [github](https://github.com/Axvser/FastHotKeyForWPF)
- [nuget](https://www.nuget.org/packages/FastHotKeyForWPF/)

Versions →

2.9.0 `preview for 3.0.0`

---

# Ⅰ Invisible

This pattern means that you don't need to create user controls, but do everything related to hotkeys directly in code

- ## Global

You can register globally available hotkeys

- Before a hotkey can be registered, the GlobalHotKey must be awaked in place

- It can also be triggered when the mouse is not located within the program

- Non-system keys are limited to one

```csharp
using FastHotKeyForWPF;
using System.Windows;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Here you get the window handle, and once you're done, you can use the hotkey registration, modification, and other functions provided by the library
            GlobalHotKey.Awake();

            // Add HotKey
            GlobalHotKey.Register(VirtualModifiers.Ctrl | VirtualModifiers.Alt, // modifiers
                                  VirtualKeys.F1 | VirtualKeys.F2,      // triggers
                                  [Test1, Test2]);                       // events

            // Remove HotKey
            GlobalHotKey.Unregister(VirtualModifiers.Ctrl | VirtualModifiers.Alt, // modifiers
                                    VirtualKeys.F1 | VirtualKeys.F2);     // triggers
        }

        protected override void OnClosed(EventArgs e)
        {
            // Release the hotkey before the program closes
            GlobalHotKey.Dispose();

            base.OnClosed(e);
        }

        private void Test1(object? sender, HotKeyEventArgs e)
        {
            // If you manage hotkeys in invisible mode, sender will always be null
            if (sender != null && sender is HotKeyBox hkb)
            {
                // If you're managing hotkeys in visual mode, the sender may be your custom user control
            }

            // Of course, you can use both modes, or you can have different hotkeys trigger the same handler event
        }

        private void Test2(object? sender, HotKeyEventArgs e)
        {
            MessageBox.Show($"{e.Modifiers}");
            // Retrieves the value of the triggered hotkey

            MessageBox.Show($"{e.GetModifierKeys().Count}");
            // Modifiers can be parsed from uint very precisely.

            MessageBox.Show($"{e.GetTriggerKeys().Count}");
            // Other keys can only parse out possible values from uint.Be careful with the parsing of Keys
        }
    }
}
```

- ## Local

You can register multiple local hotkeys for a control as follows

- Hotkeys can be triggered when the focus is on the control

- Multiple non-system keys are allowed to participate

```csharp
  LocalHotKey.Register(inputbox, [Key.LeftCtrl, Key.K, Key.D],
      (sender, e) =>
      {
          MessageBox.Show("Ctrl + K + D");
      });

  LocalHotKey.Register(inputbox, [Key.LeftAlt, Key.K, Key.D],
      (sender, e) =>
      {
          MessageBox.Show("Alt + K + D");
      });

  LocalHotKey.Register(inputbox, [Key.LeftAlt, Key.LeftCtrl, Key.E, Key.F],
      (sender, e) =>
      {
          MessageBox.Show("Alt + Ctrl + E + F");
      });

  LocalHotKey.Unregister(inputbox, [Key.LeftAlt, Key.K, Key.D]);
```

---

# Ⅱ Visual

This pattern means that you will allow users to edit hotkeys in visual interfaces, and the library provides source generators to help you quickly build logical implementations of these interfaces

Use the default user controls provided by the library

```xml
  xmlns:fhk="clr-namespace:FastHotKeyForWPF;assembly=FastHotKeyForWPF"
```

```xml
  <fhk:HotKeyBox Handler="Test1" Width="400" Height="100" Margin="122,230,278,105"/>
```

---

# Ⅲ Customize a user control for setting hotkeys

- ## 1. Use Source Generator

```csharp
using FastHotKeyForWPF;
using System.Windows.Controls;

namespace WpfApp4
{
    [HotKeyComponent]
    public partial class HotKeyBox : UserControl
    {
        public HotKeyBox()
        {
            InitializeComponent();
        }

        private void TextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox box)
            {
                box.Focusable = true;
                box.Focus();
            }
        }

        private void TextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox box)
            {
                box.Focusable = false;
                System.Windows.Input.Keyboard.ClearFocus();
            }
        }
    }
}

```

- ## 2. Layout & Data Binding

```xml
<UserControl x:Class="WpfApp4.HotKeyBox"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:WpfApp4"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    <UserControl.Template>
        <ControlTemplate>
            <!-- [ OnHotKeyReceived ] is automatically generated -->
            <TextBox KeyDown="OnHotKeyReceived"
                     MouseEnter="TextBox_MouseEnter"
                     MouseLeave="TextBox_MouseLeave"
                     Text="{Binding Text, RelativeSource={RelativeSource AncestorType=local:HotKeyBox}}" 
                     Foreground="{TemplateBinding Foreground}" 
                     FontSize="{TemplateBinding FontSize}"
                     IsReadOnly="True"/>
        </ControlTemplate>
    </UserControl.Template>
</UserControl>

```

- ## 3. Use your custom control to build the interface for hot key settings.

- ## 4. What the source generator specifically produces

| Produce                                  | Description                                                                                                                                                                                                                         |
|------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| VirtualModifiers                         | A dependency property representing the virtual modifiers for the hotkey. Changing this value directly registers or modifies the hotkey without updating the UI.                                                                               |
| VirtualKeys                              | A dependency property representing the virtual keys for the hotkey. Changing this value directly registers or modifies the hotkey without updating the UI.                                                                                 |
| OnModifiersChanged                       | Partial method to optionally extend logic when the key modifiers are changed.                                                                                                                                                           |
| OnKeysChanged                            | Partial method to optionally extend logic when the keys are changed.                                                                                                                                                                    |
| Handler                                  | Event triggered when the hotkey is invoked. Multiple handlers can be added or removed from this event.                                                                                                                              |
| Invoke                                   | Method to invoke the hotkey handling events, calling `OnHotKeyInvoking` before invoking all registered handlers, and then calling `OnHotKeyInvoked` after invocation.                                                               |
| OnHotKeyInvoking                         | Partial method called before the hotkey event is triggered.                                                                                                                                                                             |
| OnHotKeyInvoked                          | Partial method called after the hotkey event is triggered.                                                                                                                                                                              |
| Covered                                  | Method executed if the key combination duplicates an existing hotkey registration elsewhere, clearing internal state and resetting properties. Calls `OnCovered` afterward.                                                           |
| OnCovering                               | Partial method called before the component is covered due to duplicate hotkey registration.                                                                                                                                            |
| OnCovered                                | Partial method called after the component is covered due to duplicate hotkey registration.                                                                                                                                            |
| Text                                     | Dependency property representing the text representation of the hotkey combination, updated automatically based on `modifiers` and `triggers` sets.                                                                              |
| OnHotKeyReceived                         | Protected virtual method handling keyboard input for binding purposes, updates UI by modifying `modifiers` and `triggers` sets based on received key events.                                                                           |
| UpdateHotKey                             | Protected virtual method updating the hotkey properties (`VirtualModifiers`, `VirtualKeys`, and `Text`) based on current `modifiers` and `triggers` states. Also calls `OnHotKeyUpdating` before and `OnHotKeyUpdated` after the update.       |
| OnHotKeyUpdating                         | Partial method called before the hotkey is updated.                                                                                                                                                                                     |
| OnHotKeyUpdated                          | Partial method called after the hotkey is updated.                                                                                                                                                                                      |

