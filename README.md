# IntNetViewer 🌐

**IntNetViewer** is a modern, lightweight, and customizable web browser built for speed, security, and simplicity. Designed with developers and power users in mind, IntNetViewer supports tabbed browsing, ~~extension capabilities~~ (coming soon), and seamless web standards compatibility.

## 🚀 Features

- 🔖 **Tabbed Browsing** – Effortlessly manage multiple pages with a smooth tab interface.
- ~~🛡️ **Privacy First** – Built-in ad and tracker blocking to keep your data safe.~~ (coming soon)
- ⚡ **Fast Rendering** – Powered by a modern rendering engine for high performance.
- 🎨 **Customizable UI** – Tweak themes, layout, and shortcuts to match your workflow.
- ~~🧩 **Extension Support** – Extend functionality with optional plugin architecture (coming soon).~~
- ~~🔍 **Smart Address Bar** – Auto-completion, search suggestions, and history-aware navigation.~~ (coming soon)

## 📦 Installation

### Windows

Download the latest release from the [Releases Page](https://github.com/robloxboy1000/IntNetViewer/releases), extract the ZIP file, and run `Launcher.exe`.

### macOS & Linux

Go to [IntNetViewer (macOS)](https://github.com/robloxboy100058/IntNetViewer) (Note: the macOS version is currently broken.)

And I apologize, but I won't be able to make a Linux version anytime soon.

## 🛠️ Building from Source

### Prerequisites

- [.NET Framework 4.6.2+](https://dotnet.microsoft.com/)
- [CEFSharp](https://github.com/cefsharp/CefSharp) (if using Chromium rendering)
- Visual Studio 2022 or later

### Clone & Build

1. Open Visual Studio 2022
2. Select `Clone a repository`
3. Enter `https://github.com/robloxboy1000/IntNetViewer.git`
4. Click `Clone`
5. Make your own changes
6. Build for `Release` and `x64` (or `Debug` and `x64`)

## 🔧 Configuration
Configuration options are available in the config.cfg file located in the `bin` directory. You can set:

Default homepage

~~Search engine~~ (coming soon)

~~Download folder~~

Theme (light/dark/system)

## 📚 Documentation
See the Wiki for detailed documentation on usage, customization, and contributing.

## 🙌 Contributing
We welcome contributions! Please fork the repo, make changes on a feature branch, and submit a pull request.

## 📃 License
Public Domain by [Unlicense](https://unlicense.org/). See [UNLICENSE](https://github.com/robloxboy1000/IntNetViewer/blob/main/UNLICENSE) for more details.

## 🧠 Credits
Developed and maintained by **PixlPlaya5**. Powered by open-source technologies including .NET and CEF.

Happy browsing with IntNetViewer! 🚀
## Files
- **Launcher.exe** - This only checks the current Windows version, if it's lower than Windows 10, it doesn't launch IntNetViewer.
- **bin/int.exe** - The main event. This is the main IntNetViewer application.