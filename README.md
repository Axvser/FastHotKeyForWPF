# FastHotKeyForWPF 🚀

[中文](#中文) | [English](#english)

<a name="中文"></a>
## 中文版

### 简介 📖

用优雅的方式构建WPF热键功能，支持全局/本地热键注册、可视化控件、源码生成器等特性

[![GitHub](https://img.shields.io/badge/GitHub-Repository-blue?logo=github)](https://github.com/Axvser/FastHotKeyForWPF)
[![NuGet](https://img.shields.io/nuget/v/FastHotKeyForWPF?color=green&logo=nuget)](https://www.nuget.org/packages/FastHotKeyForWPF/)

### 版本矩阵 📦

| 版本   | 类型 | 目标框架                   | 特性               |
|--------|------|----------------------------|--------------------|
| 2.4.0  | LTS  | .NET 6                     | 非源码生成器       |
| 3.0.0  | LTS  | .NET 5 / .NET Framework 4.7.1 | 基础功能           |
| 4.0.0  | LTS  | .NET 5 / .NET Framework 4.6.2 | 统一API          |

### 最新特性 ✨

1. **统一API** - 跨框架一致的操作体验
2. **增强注销** - 返回成功注销的热键数量
3. **源码生成器** - 支持.NET Framework（需手动配置）
4. **文档升级** - 新增函数原型速查表

### 快速开始 🚀

#### Ⅰ 代码注册热键

```csharp
// 全局热键（任意窗口生效）
GlobalHotKey.Register(
    VirtualModifiers.Ctrl | VirtualModifiers.Alt,
    VirtualKeys.F1,
    (sender, e) => MessageBox.Show("全局热键触发！")
);

// 本地热键（指定控件生效）
LocalHotKey.Register(
    textBox1, 
    new[] { Key.LeftCtrl, Key.K, Key.D },
    (sender, e) => textBox1.Text = "Ctrl+K+D 已触发"
);
```

#### Ⅱ 可视化热键控件

1. 创建自定义控件（自动生成热键逻辑）

```csharp
[HotKeyComponent]
public partial class HotKeyBox : UserControl
{
    // 控件交互逻辑...
}
```

2. XAML绑定热键属性

```xml
<TextBox KeyDown="OnHotKeyReceived"
         Text="{Binding HotkeyText, RelativeSource={RelativeSource AncestorType=local:HotKeyBox}}"/>
```

### 核心API 🔧

#### GlobalHotKey

| 方法                          | 说明                          |
|-------------------------------|-------------------------------|
| `Awake()`                     | 初始化热键系统                |
| `Register(modifiers, keys)`   | 注册全局热键                  |
| `Unregister(modifiers, keys)` | 注销全局热键                  |
| `Dispose()`                   | 释放所有热键资源              |

#### LocalHotKey

| 方法                          | 说明                          |
|-------------------------------|-------------------------------|
| `Register(target, keys)`      | 注册控件级热键                |
| `Unregister(target)`          | 注销控件所有热键              |
| `UnregisterMainWindow()`      | 注销主窗口所有热键            |

### 完整文档 📚

[查看完整函数原型与使用指南](https://github.com/Axvser/FastHotKeyForWPF/wiki)

---

<a name="english"></a>
## English Version

### Introduction 📖

Elegant hotkey implementation for WPF, featuring global/local registration, visual controls, and source generators.

[![GitHub](https://img.shields.io/badge/GitHub-Repository-blue?logo=github)](https://github.com/Axvser/FastHotKeyForWPF)
[![NuGet](https://img.shields.io/nuget/v/FastHotKeyForWPF?color=green&logo=nuget)](https://www.nuget.org/packages/FastHotKeyForWPF/)

### Version Matrix 📦

| Version | Type | Target Frameworks            | Features          |
|---------|------|-------------------------------|-------------------|
| 2.4.0   | LTS  | .NET 6                        | Non-SourceGen     |
| 3.0.0   | LTS  | .NET 5 / .NET Framework 4.7.1 | Basic Features    |
| 4.0.0   | LTS  | .NET 5 / .NET Framework 4.6.2 | Unified API       |

### Highlights ✨

1. **Unified API** - Consistent cross-framework experience
2. **Enhanced Unregister** - Returns success count
3. **Source Generator** - .NET Framework support (manual config)
4. **Documentation** - Added function prototypes quick reference

### Quick Start 🚀

#### Ⅰ Code Registration

```csharp
// Global hotkey (works system-wide)
GlobalHotKey.Register(
    VirtualModifiers.Ctrl | VirtualModifiers.Alt,
    VirtualKeys.F1,
    (sender, e) => MessageBox.Show("Global Hotkey Triggered!")
);

// Local hotkey (control-specific)
LocalHotKey.Register(
    textBox1,
    new[] { Key.LeftCtrl, Key.K, Key.D },
    (sender, e) => textBox1.Text = "Ctrl+K+D Activated"
);
```

#### Ⅱ Visual Control

1. Create custom control (auto-generated logic)

```csharp
[HotKeyComponent]
public partial class HotKeyBox : UserControl
{
    // Control interactions...
}
```

2. XAML Data Binding

```xml
<TextBox KeyDown="OnHotKeyReceived"
         Text="{Binding HotkeyText, RelativeSource={RelativeSource AncestorType=local:HotKeyBox}}"/>
```

### Core API 🔧

#### GlobalHotKey

| Method                        | Description                   |
|-------------------------------|-------------------------------|
| `Awake()`                     | Initialize hotkey system      |
| `Register(modifiers, keys)`   | Register global hotkey        |
| `Unregister(modifiers, keys)` | Unregister global hotkey      |
| `Dispose()`                   | Release all hotkey resources  |

#### LocalHotKey

| Method                          | Description                   |
|---------------------------------|-------------------------------|
| `Register(target, keys)`        | Register control-level hotkey |
| `Unregister(target)`            | Unregister all control hotkeys|
| `UnregisterMainWindow()`        | Clear main window hotkeys     |

### Full Documentation 📚

[View Complete API Reference](https://github.com/Axvser/FastHotKeyForWPF/wiki)
