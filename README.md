# LibUISharp ![License](https://img.shields.io/badge/License-MIT-blue.svg?style)
<!--TODO: Add build status buttons.-->

*This README file, as well as the rest of the repository, is a work in progress.*

LibUISharp is a library containing bindings for [libui](https://github/andlabs/libui), written in C# for .NET Core.

## Features

LibUISharp allows you to create a native GUI application running .NET Core. Please note that LibUI is in alpha development, so the native library, thus this C# library, is not stable. This library (LibUISharp) has not been tested, yet, and may have build errors.

**Controls:**

* Window
* Button
* HPanel/VPanel
* CheckBox
* TextBox/PasswordBox/SearchBox/MultilineTextBox
* Label
* TabControl/TabPage
* GroupBox
* SpinBox
* Slider
* ProgressBar
* Separator
* ComboBox/EditableComboBox
* RadioButtonGroup
* DateTimePicker/DatePicker/TimePicker
* MenuStrip/MenuStripItem
* OpenFileDialog/SaveFileDialog
* MessageBox
* Surface/ScrollableSurface
* FontPicker
* ColorPicker
* Form
* Grid

## Supported Platforms

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

LibUISharp will be available as a NuGet package once I (somewhat) finish.

## Building From Source

LibUISharp is built with .NET Core, so you can build LibUISharp with either Visual Studio, Visual Studio Code,
or just by running a couple simple commands. Use the steps below to get started!

Any output is placed in the `build\` directory.

### Prerequisites

| Operating System | Prerequisites                                                                                                    |
| :--------------- | :--------------------------------------------------------------------------------------------------------------- |
| Windows 7/8.1/10 | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio 2017.5<br/>Visual Studio Code (With the C# extension) |
| Mac OS X         | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio Code                                                  |
| Linux            | .NET Core 2.0 SDK<br/><br/>**Optional:**<br/>Visual Studio Code                                                  |

### Build Using Visual Studio (Windows)

*Ensure you have the latest version of Visual Studio 2017 installed with the .NET Core workload.*

1. Open the `LibUISharp.sln` file.
2. Then, navigate to the `Build>Build Solution` menu item.

### Build Using Visual Studio Code (Windows/MacOS/Linux)

***This section is to-be-written.***

### Build Using a CLI

Run the following command in a command-line interface in the root directory of this repository:

1. `dotnet build LibUISharp.sln'