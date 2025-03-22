# FastHotKeyForWPF

Build `hotkey` elegantly

Get →

- [github](https://github.com/Axvser/FastHotKeyForWPF)
- [nuget](https://www.nuget.org/packages/FastHotKeyForWPF/)

Versions →

- [2.4.0](#) `LTS` `net 6` `Non-SourceGenerator`
- [3.0.0](#) `LTS` `net 5` `net framework4.7.1`
- [4.0.0](#) `LTS` `net 5` `net framework4.6.2` `Unified API`

---

Update →

1. Unified API, whether in 'net' or 'net framework', can use the same code to manage hot keys

2. The methods for logging out of local hotkeys have also been optimized, and now they return the number of local hotkeys that were successfully logged out, making it easier to determine when logging out of local hotkeys.

3. The `Source Generator` is now available under the `net framework`
   - (1) You need to modify the `.csproj` file to add the following code
   ```xml
   <LangVersion>latest</LangVersion>
   ```
   - (2) You need to add the generator manually
   - `...\packages\FastHotKeyForWPF.Generator.1.4.0\analyzers\dotnet\cs\FastHotKeyForWPF.Generator.dll"`
  
   - After completing the above steps, you can use `Source Generator` just as you would in `net`

4. Documentation added function prototype view

---

# Catalogue

- [HotKey API](#ⅠInvisible)
  - [Invisible](#ⅠInvisible) `Set the hotkey in an encoded manner`
    - [Global HotKey](#Global)
    - [Local HotKey](#Local)
  - [Visual](#ⅡVisual) `Custom UserControl For HotKey Settings`
    - [Source Generator](##1.UseSourceGenerator)
    - [Layout & DataBinding](##2.Layout&DataBinding)
    - [Component API](##HotKeyBoxGeneratedMembersReference)
- [Key Helper](#keyhelper)
  - [Test Keys](#testkeys)
  - [uint Combine & Parse](#uintcombine&parse)
- [Function Prototype](#FunctionPrototype)
  - [GlobalHotKey](#GlobalHotKey)
  - [LocalHotKey](#LocalHotKey)
  - [KeyHelper](#KeyHelper)

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

# Ⅱ Visual

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

---

# HotKeyBox Generated Members Reference

This document describes the key components and extensibility points of the auto-generated `HotKeyBox` control.

## Core Methods Table

| Method Name                      | Overloadable | Description                                                                                     |
|----------------------------------|--------------|-------------------------------------------------------------------------------------------------|
| **Properties**                   |              |                                                                                                 |
| `IsRegistered`                   | Yes          | Indicates hotkey registration status. Triggers `OnSuccess()`/`OnFailed()` when value changes    |
| `VirtualModifiers`               | No           | DependencyProperty for modifier keys (Alt/Ctrl/Shift/Win)                                      |
| `VirtualKeys`                    | No           | DependencyProperty for trigger keys                                                            |
| **Event Handlers**               |              |                                                                                                 |
| `Handler`                        | No           | Event triggered when hotkey is activated                                                       |
| **Core Functionality**           |              |                                                                                                 |
| `Invoke()`                       | Yes          | Virtual method that fires the hotkey event                                                      |
| `Covered()`                      | Yes          | Virtual method called when hotkey is overridden by another registration                         |
| `OnHotKeyReceived()`             | Yes          | Virtual keyboard input handler (WPF KeyEvent processor)                                         |
| `UpdateHotKey()`                 | Yes          | Virtual method that updates UI and registration status                                          |
| **Partial Methods**              |              |                                                                                                 |
| `OnFailed()`                     | Yes          | Source generator hook for failed registration (auto-implementable)                              |
| `OnSuccess()`                    | Yes          | Source generator hook for successful registration (auto-implementable)                          |
| `OnModifiersChanged()`           | Yes          | Extensible logic when modifier keys change                                                     |
| `OnKeysChanged()`                | Yes          | Extensible logic when trigger key changes                                                      |
| `OnHotKeyInvoking()`             | Yes          | Pre-execution hook for hotkey events                                                           |
| `OnHotKeyInvoked()`              | Yes          | Post-execution hook for hotkey events                                                          |
| `OnCovering()`                   | Yes          | Pre-hook for hotkey override process                                                           |
| `OnCovered()`                    | Yes          | Post-hook for hotkey override process                                                          |
| `OnHotKeyUpdating()`             | Yes          | Pre-hook for hotkey UI update                                                                  |
| `OnHotKeyUpdated()`              | Yes          | Post-hook for hotkey UI update                                                                 |
| **DProperty Callbacks**          |              |                                                                                                 |
| `Inner_OnModifiersChanged()`     | No           | Automatic registration handler for modifier changes (generated)                                |
| `Inner_OnKeysChanged()`          | No           | Automatic registration handler for key changes (generated)                                     |

## Key Overload Guidelines
1. **Virtual Methods** (`Invoke`, `Covered`, etc.):  
   Override in derived classes to modify base behavior

2. **Partial Methods** (`On[Action]`):  
   Implement in separate partial class files to extend functionality without modifying generated code

3. **Dependency Properties**:  
   Use standard WPF patterns for value change handling (bindings/styles/triggers)

> 💡 All extension points are designed for **zero-conflict modification** - your custom implementations will persist across source generator updates.

---

# KeyHelper

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

---

# FunctionPrototype

一、GlobalHotKey

Core operation

```csharp
public static void Awake() // Initializing the hot key system
public static void Dispose() // Release all hotkey resources
```

Hotkey registration

```csharp
public static int Register(IHotKeyComponent component)
public static int Register(uint modifiers, uint triggers, params HotKeyEventHandler[] handlers)
public static int Register(VirtualModifiers modifierKeys, VirtualKeys triggerKeys, params HotKeyEventHandler[] handlers)
```

Hotkey logout

```csharp
public static bool Unregister(uint modifiers, uint triggers)
public static bool Unregister(VirtualModifiers modifierKeys, VirtualKeys triggerKeys)
```

二、LocalHotKey

Registration method

```csharp
public static void Register(KeyEventHandler keyevent, params Key[] keys)
public static void Register(HashSet<Key> keys, KeyEventHandler keyevent)
public static void Register(IInputElement target, KeyEventHandler keyevent, params Key[] keys)
public static void Register(IInputElement target, HashSet<Key> keys, KeyEventHandler keyevent)
```

Logout method

```csharp
public static int Unregister(IInputElement target, params Key[] keys)
public static int Unregister(IInputElement target, HashSet<Key> keys)
public static int Unregister(IInputElement target, ICollection<HashSet<Key>> keysgroup)
public static int Unregister(IInputElement target)
public static int UnregisterMainWindow(params Key[] keys)
public static int UnregisterMainWindow(HashSet<Key> keys)
public static int UnregisterMainWindow()
```

三、KeyHelper

Functional approach

```csharp
public static void Test(VirtualModifiers testModifiers) 
// Test whether the native key can be recognized and used for hotkeys
```

Extension method

```csharp
public static uint GetUint(this ICollection<VirtualModifiers> source)
public static IEnumerable<VirtualModifiers> GetModifiers(this uint source)
public static IEnumerable<string> GetNames(this ICollection<VirtualModifiers> source)
```

---