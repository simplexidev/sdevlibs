# LibUISharp ![License](https://img.shields.io/badge/License-MIT-blue.svg?style) [![Build status](https://ci.appveyor.com/api/projects/status/o2y9fu126dqmi4pv?svg=true)](https://ci.appveyor.com/project/tom-corwin/libuisharp)

LibUISharp is a library containing bindings for [libui](https://github.com/andlabs/libui), written in C# for .NET Core (and in the future, .NET Framework and Mono).

## Features

LibUISharp allows you to create a native GUI application running .NET Core. Please note that LibUI is in alpha development, so the native library, thus this C# library, is not stable. This library (LibUISharp) has not really been tested, yet, and may have some bugs. Check out the demos in the `demos\` folder for examples.

**Controls and Drawing Features**:

* *AttributedText (TODO)*
* Button
* CheckBox
* ColorPicker
* ComboBox
  * EditableComboBox
* DateTimePicker
  * DatePicker
  * TimePicker
* FileDialog
  * OpenFileDialog
  * SaveFileDialog 
* FontFeatures
* FontPicker
* Form
* Grid
* GroupBox
* Label
* MenuStrip
* MenuStripItem
  * MenuStripAboutItem
  * MenuStripCheckItem
  * MenuStripPreferencesItem
  * MenuStripQuitItem
* MessageBox
* Panel
  * HPanel
  * VPanel
* ProgressBar
* RadioButtonGroup
* Separator
  * HSeparator
  * VSeparator
* Slider
* SpinBox
* Surface
  * ScrollableSurface
* TextAttribute
  * FontFamilyAttribute
  * FontFeaturesAttribute
  * FontSizeAttribute
  * FontWeightAttribute
  * FontStretchAttribute
  * ForegroundColorAttribute
  * BackgroundColorAttribute
  * UnderlineStyleAttribute
  * UnderlineColorAttribute
* TextBox
  * MultilineTextBox
  * PasswordBox
  * SearchBox
* TabControl
* TabPage
* Window

### Supported Platforms

This list is basically copied and reformatted from [here](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md).

| Operating System                                     | Version                                           | Architecture | Prerequiusites |
| :--------------------------------------------------- | :------------------------------------------------ | :----------- | :------------- |
| Windows Client<br/>Windows Server                    | 7 SP1, 8.1, 10 Build 1607+<br/>2008 R2 SP1+       | x64<br/>x64  |                |
| Mac OS X                                             | 10.12+                                            | x64          |                |
| Red Hat Enterprise Linux<br/>CentOS</br>Oracle Linux | 7                                                 | x64          | GTK+ 3.10+     |
| Fedora                                               | 25, 26                                            | x64          | GTK+ 3.10+     |
| Debian<br/>Ubuntu</br>Linux Mint                     | 8.7+, 9<br/>14.04, 16.04, 17.04, 17.10<br/>17, 18 | x64          | GTK+ 3.10+     |
| openSUSE<br/>SUSE Enterprise Linux (SLES)            | 42.2+<br/>12 SP2+                                 | x64          | GTK+ 3.10+     |

## Obtaining the Library

LibUISharp is almost up-to-par with libui and doesn't have a package on nuget.org.

Add our CI package feed for bleeding-edge packages:  
```
https://ci.appveyor.com/nuget/libuisharp
```


## Building From Source

LibUISharp is built with .NET Core, so you can build LibUISharp with either Visual Studio, Visual Studio Code,
or just by running a couple simple commands. Use the steps below to get started!

Any output is placed in the `build\` directory.

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

***This section is to-be-written.***

### Build Using a CLI

Run the following command in a command-line interface in the root directory of this repository:

1. `dotnet build LibUISharp.sln'

## Contributing

Contributing is as easy as filing an issue, fixing a bug, or suggesting a new feature.

Please see the [CONTRIBUTING.md](https://github.com/tom-corwin/LibUISharp/blob/master/CONTRIBUTING.md) file for more information.