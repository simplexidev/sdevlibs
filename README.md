# LibUISharp ![License](https://img.shields.io/badge/License-MIT-blue.svg?style)
<!--TODO: Add build status buttons.-->

***This README file, as well as the rest of the repository, is a work in progress.***

LibUISharp is a library containing bindings for [libui](https://github/andlabs/libui), written in C# for .NET Core.

## Features

LibUISharp allows you to create a native GUI application running .NET Core. Please note that LibUI is in alpha development, so the native library, thus this C# library, is not stable. This library (LibUISharp) has not been tested, yet.

## Supported Platforms

This list is basically copied and reformatted from [here](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md).

| Operating System                                               | Version                                               | Architecture            | Prerequiusites |
| :------------------------------------------------------------- | :---------------------------------------------------- | :---------------------- | :------------- |
| Windows Client <br/> Windows Server                            | 7 SP1, 8.1, 10 Build 1607+ <br/> 2008 R2 SP1+         | x64, x86 <br/> x64, x86 |                |
| Mac OS X                                                       | 10.12+                                                | x64                     |                |
| Red Hat Enterprise Linux\* <br/> CentOS\* </br> Oracle Linux\* | 7                                                     | x64                     | GTK+ 3.10+     |
| Fedora\*                                                       | 25, 26                                                | x64                     | GTK+ 3.10+     |
| Debian <br/> Ubuntu </br> Linux Mint                           | 8.7+, 9 <br/> 14.04, 16.04, 17.04, 17.10 <br/> 17, 18 | x64                     | GTK+ 3.10+     |
| openSUSE\* <br/> SUSE Enterprise Linux (SLES)\*                | 42.2+ <br/> 12 SP2+                                   | x64                     | GTK+ 3.10+     |

<sup>\* - Support is planned for this OS.</sup>

## Obtaining the Library

LibUISharp will be available as a NuGet package once finished.

## Building From Source

Please use the following steps to build LibUISharp and its dependency, libui.

### Prerequisites

Prerequisites may differ depending on platform and/or the library to be built.

| Operating System | Managed (C#) Prerequisites | Unmanaged (C/C++) Prerequisites                                              |
| :--------------- | :------------------------- | :--------------------------------------------------------------------------- |
| Windows 7/8.1/10 | .NET Core 2.0 SDK          | CMake 3.1.0+</br>Visual Studio 2013+                                         |
| Mac OS X         | .NET Core 2.0 SDK          | CMake 3.1.0+</br><sup>*You must also be able to build Cocoa programs.*</sup> |
| Linux            | .NET Core 2.0 SDK          | CMake 3.1.0+                                                                 |

### Building LibUISharp.Native

***This section is being written.***

### Building LibUISharp

***This section is being written.***