# LibUISharp
[![License](https://img.shields.io/badge/License-MIT-blue.svg?longCache=true)](https://github.com/tom-corwin/LibUISharp/blob/master/LICENSE.md)
[![Build status](https://ci.appveyor.com/api/projects/status/o2y9fu126dqmi4pv?svg=true)](https://ci.appveyor.com/project/tom-corwin/libuisharp)
[![CodeFactor](https://www.codefactor.io/repository/github/tom-corwin/libuisharp/badge)](https://www.codefactor.io/repository/github/tom-corwin/libuisharp)
![NuGet](https://img.shields.io/nuget/vpre/LibUISharp.svg)

LibUISharp is a library containing bindings for [libui](https://github.com/andlabs/libui). Currently, LibUISharp is only built as a .NET Standard 2.0 library, but can also support other frameworks as-per community interest.

**Please Note**: [libui](https://github.com/andlabs/libui) is *mid-alpha* software, meaning the underlying API in LibUISharp is a work-in-progress. Any LibUISharp releases up until v0.4.0 are CI builds, and are not guaranteed to work.

## Looking for Contributors!
Currently, I don't have the free time to make LibUISharp complete on my own. Because of this, I am looking for help from the community. Whether an issue, or a new feature, nothing is to small.

## Features

LibUISharp allows you to create native, cross-platform graphical user interface (GUI) applications containing various controls, such as a `Button` or a `TabControl`, 

Check out the demos in the `demos\` folder for examples.

### Controls

* Button
* CheckBox
* ColorPicker
* ComboBox
* DateTimePicker
* FontPicker
* Form
* Grid
* GroupBox
* Label
* MenuStrip/MenuStripItem
* MessageBox
* StackPanel
* ProgressBar
* RadioButtonGroup
* Separator
* Slider
* SpinBox
* TextBox
* TabControl
* Window

### Drawing/Text
* AttributedText
* Brush
* Context
* Font
* FontFeatures
* Path
* Surface
* TextAttribute
* TextLayout

## Supported Platforms

LibUISharp supports 64-bit Windows, macOS, and Linux <sub>[[source](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md)]</sub>:

| Operating System                                     | Version                                           | Architecture | Prerequiusites |
| :--------------------------------------------------- | :------------------------------------------------ | :----------- | :------------- |
| Windows Client<br/>Windows Server                    | 7 SP1+, 8.1, 10 Build 1607+<br/>2008 R2 SP1+      | x64<br/>x64  |                |
| Mac OS X                                             | 10.12+                                            | x64          |                |
| Red Hat Enterprise Linux<br/>CentOS</br>Oracle Linux | 6, 7<br/>7<br/>7                                  | x64          | GTK+ 3.10+     |
| Fedora                                               | 26, 27                                            | x64          | GTK+ 3.10+     |
| Debian<br/>Ubuntu</br>Linux Mint                     | 8.7+, 9<br/>14.04, 16.04, 17.10, 18.04<br/>17, 18 | x64          | GTK+ 3.10+     |
| openSUSE<br/>SUSE Enterprise Linux (SLES)            | 42.3+<br/>12 SP2+                                 | x64          | GTK+ 3.10+     |

## Obtaining the Library

LibUISharp is almost up-to-par with libui and is now available on NuGet!

Just add this line to you project file:

```
<PackageReference Include="LibUISharp" Version="0.4.0-build-*" />
```

## Building From Source

LibUISharp is built with .NET Core, so you can build LibUISharp with either Visual Studio, Visual Studio Code,
or just by running a couple simple commands. Use the steps below to get started!

### Prerequisites

| Operating System | Prerequisites                                                                                                    |
| :--------------- | :--------------------------------------------------------------------------------------------------------------- |
| Windows 7/8.1/10 | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio 2017 (v15.6.x)<br/>Visual Studio Code (With the C# extension) |
| Mac OS X         | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio Code (With the C# extension)                          |
| Linux            | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio Code (With the C# extension)                          |

### Build Using Visual Studio (Windows)

*Ensure you have the latest version of Visual Studio 2017 installed with the .NET Core workload.*

1. Open the `LibUISharp.sln` file.
2. Then, navigate to the `Build>Build Solution` menu item.

### Build Using Visual Studio Code (Windows/MacOS/Linux)

***This section is to-be-written. For now, refer to the next section.***

### Build Using a CLI

Run the following command in a command-line interface in the root directory of this repository:

1. `dotnet build LibUISharp.sln'

## Contributing

Contributing is as easy as filing an issue, fixing a bug, or suggesting a new feature.

Please see the [CONTRIBUTING.md](https://github.com/tom-corwin/LibUISharp/blob/master/CONTRIBUTING.md) file for more information.
