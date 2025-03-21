# FastHotKeyForWPF

Build `hotkey` elegantly

Get →

- [github](https://github.com/Axvser/FastHotKeyForWPF)
- [nuget](https://www.nuget.org/packages/FastHotKeyForWPF/)

Versions →

- [2.4.0](#) `LTS` `net 6` `Non-SourceGenerator` `Old API`
- [3.0.0](#) `LTS` `net 5` `net framework4.7.1`

API differences →

The .NET framework does not support the use of `collection expressions`. Therefore, compared with the API of .NET Core, the API of .NET framework has made some adjustments `in the way collections are presented as function parameters`, but overall they are consistent, and there is no need to worry.

---

# Catalogue

- [HotKey API](#ⅠInvisible)
  - [Invisible](#ⅠInvisible) `Only C# Code`
    - [Global HotKey](#Global)
    - [Local HotKey](#Local)
  - [Visual](#ⅡVisual) `Custom UserControl For HotKey Settings`
- [Key Helper](#keyhelper)
  - [Test Keys](#testkeys)
  - [uint Combine & Parse](#uintcombine&parse)

---

# Ⅰ Invisible `net 5` `net framework4.7.1`

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
                                  VirtualKeys.F1,                               // key
                                  [Test1, Test2]);                              // events

            // Remove HotKey
            GlobalHotKey.Unregister(VirtualModifiers.Ctrl | VirtualModifiers.Alt,
                                    VirtualKeys.F1);
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
            // system modifier can have more than one valid value

            MessageBox.Show($"{e.GetVirtualKey()}");
            // Not a system modifier; only one valid Key exists
        }
    }
}
```

- ## Local

You can register multiple local hotkeys for a control as follows

- Hotkeys can be triggered when the focus is on the control

- Multiple non-system keys are allowed to participate

```csharp
  // Inject hotkeys into MainWindow without specifying a registration target
  LocalHotKey.Register([Key.LeftCtrl, Key.K, Key.D],
      (sender, e) =>
      {
          MessageBox.Show("Ctrl + K + D");
      });

  // Inject hotkeys for the specified target
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

  // Delete all hotkeys of control
  LocalHotKey.Unregister(inputbox);

  // Removes the specified hotkey
  LocalHotKey.Unregister(inputbox, [Key.LeftAlt, Key.K, Key.D]);
```

---

# Ⅱ Visual `net 5`

Customize a user control for setting hotkeys

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

| Property/Method                    | Description                                                                                                                                                                                                 |
|------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| VirtualModifiers                   | A property representing the virtual modifiers of a hotkey. Modifying this will register or modify the hotkey without updating the UI.                                                                       |
| OnModifiersChanged                 | Partial method that can be extended to add custom logic when modifiers change.                                                                                                                                |
| VirtualKeys                        | A property representing the virtual keys of a hotkey. Modifying this will register or modify the hotkey without updating the UI.                                                                             |
| OnKeysChanged                      | Partial method that can be extended to add custom logic when keys change.                                                                                                                                     |
| Handler                            | Event raised when the hotkey is triggered. Handlers are invoked with HotKeyEventArgs containing the current state of the hotkey.                                                                              |
| Invoke                             | Invokes the hotkey handler event, calling OnHotKeyInvoking before and OnHotKeyInvoked after invoking handlers.                                                                                                |
| OnHotKeyInvoking                   | Partial method called just before the hotkey event is triggered.                                                                                                                                            |
| OnHotKeyInvoked                    | Partial method called just after the hotkey event is triggered.                                                                                                                                             |
| Covered                            | Called when another instance of HotKeyBox registers the same key combination, overwriting this instance. Clears all properties and calls OnCovering and OnCovered.                                             |
| OnCovering                         | Partial method called before the component is covered by another instance.                                                                                                                                    |
| OnCovered                          | Partial method called after the component is covered by another instance.                                                                                                                                     |
| Text                               | Represents the textual representation of the hotkey combination. Typically updated automatically via data binding.                                                                                            |
| OnHotKeyReceived                   | Processes keyboard events received by WPF controls, updating internal state based on user input.                                                                                                               |
| UpdateHotKey                       | Updates the hotkey's virtual modifiers and keys based on the current state, setting the Text property accordingly. Calls OnHotKeyUpdating and OnHotKeyUpdated.                                                |
| OnHotKeyUpdating                   | Partial method called just before the hotkey is updated.                                                                                                                                                    |
| OnHotKeyUpdated                    | Partial method called just after the hotkey is updated.                                                                                                                                                     |
| OnFailed                           | Triggered when registration fails |
| OnSuccess                          | Triggered on successful registration |

---

# KeyHelper `net 5` `net framework4.7.1`

- ## Test Keys

  - You can specify a modifier and then do the following, using Ctrl as an example

  ```csharp
    KeyHelper.Test(VirtualModifiers.Ctrl);
  ```

  - When the test is turned on, hotkeys are automatically registered. You can trigger these hotkeys to know whether a Key is supported by the library, or which one the Key corresponds to in the enumeration

  ```csharp
    MessageBox.Show($"Pressed Ctrl + {virtualKey}");
  ```

- ## uint Combine & Parse

```csharp
  var modifiers = new VirtualModifiers[] { VirtualModifiers.Ctrl, VirtualModifiers.Shift, VirtualModifiers.Alt };

  var combined = modifiers.GetUint();

  var parsed = combined.GetModifiers();
```