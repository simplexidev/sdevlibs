***This project will be renamed from `libuisharp` to `sdfx` once pull request #39 is merged. It will contain the renamed files, as well as the new API for .NET 6.***

<small>**This README is being rewritten, and may contain outdated, inaccurate, and/or be missing information.**</small>

[![Repo.Size.Badge]][Repo.Link]
[![Repo.TopLang.Badge]][Repo.Link]
[![Repo.Contributors.Badge]][Repo.Contributors.Link]
[![Gitter.Badge]][Gitter.Link]

# LibUISharp

<!--TODO: Add 1-2 paragraphs summarizing LibUISharp. -->
 
LibUISharp is a library containing bindings for [andlabs/libui][andlabs.libui.Link].

## Contributing

[![Repo.Issues.Open.Badge]][Repo.Issues.Open.Link]
[![Repo.Issues.Closed.Badge]][Repo.Issues.Closed.Link]
[![Repo.Issues.GoodFirstIssue.Badge]][Repo.Issues.GoodFirstIssue.Link]

Contributing is as easy as filing an issue, fixing a bug, or suggesting a new feature. For more information about
contributing to this project, see the [CONTRIBUTING.md][Repo.Contributing.Link] file.

Please hold off on submitting pull requests until #39 is merged. If you would like to prepare that pull request anyways, please use the branch `feature/internal/new-infrastructre`.

## Project Status

[![Codacy.Badge]][Codacy.Link]
[![Dependabot.Badge]][Dependabot.Link]

LibUISharp should still be considered a work-in-progress and should not be used in a production environment. The API is
subject to change at anytime due to the [API remodeling in libui][andlabs.libui.remodel.Link].

### Build Status

We use [Azure Pipelines][AzurePipelines.Link] for our CI builds. Although we currently only run builds on the following
platforms, LibUISharp can be built and used on any [platform supported by .NET Core 3.0][DotNetCore.SupportedOS.Link].

| <big><sub>Platform</sub>&nbsp;<sup>Configuration</sup></big> | Debug                                            | Release                                            |
| :----------------------------------------------------------- | -----------------------------------------------: | -------------------------------------------------: |
| **Windows 8.1 (x86)**                                        | [![Build.Windows81x86.Debug.Badge]][Build.Link]  | [![Build.Windows81x86.Release.Badge]][Build.Link]  |
| **Windows 8.1 (x64)**                                        | [![Build.Windows81x64.Debug.Badge]][Build.Link]  | [![Build.Windows81x64.Release.Badge]][Build.Link]  |
| **Windows 10 (x86)**                                         | [![Build.Windows10x86.Debug.Badge]][Build.Link]  | [![Build.Windows10x86.Release.Badge]][Build.Link]  |
| **Windows 10 (x64)**                                         | [![Build.Windows10x64.Debug.Badge]][Build.Link]  | [![Build.Windows10x64.Release.Badge]][Build.Link]  |
| **Ubuntu 16.04 (x64)**                                       | [![Build.Ubuntu1604x64.Debug.Badge]][Build.Link] | [![Build.Ubuntu1604x64.Release.Badge]][Build.Link] |
| **Ubuntu 18.04 (x64)**                                       | [![Build.Ubuntu1804x64.Debug.Badge]][Build.Link] | [![Build.Ubuntu1804x64.Release.Badge]][Build.Link] |
| **macOS 10.13 (x64)**                                        | [![Build.macOS1013x64.Debug.Badge]][Build.Link]  | [![Build.macOS1013x64.Release.Badge]][Build.Link]  |
| **macOS 10.14 (x64)**                                        | [![Build.macOS1014x64.Debug.Badge]][Build.Link]  | [![Build.macOS1014x64.Release.Badge]][Build.Link]  |

### Current Packages

Stable and preview packages will be released onto NuGet (when they are released).

CI builds are are published to [GitHub][Repo.Packages].

<!--TODO: Package Badges/Links -->

## Using LibUISharp Packages

For examples, see the `examples\` directory.

### Runtime Prerequisites

| Operating System | Prerequisites                                  |
| :--------------- | :----------------------------------------------|
| Windows 7/8.1/10 | Microsoft .NET Core 3.0 Runtime                |
| Linux            | Microsoft .NET Core 3.0 Runtime<br/>GTK+ 3.10+ |
| macOS            | Microsoft .NET Core 3.0 Runtime                |

### Utilizing Pre-Built Packages

While following these instructions:

  * Replace `{PackageName}` with the package you want to use.  
  * Replace `{PackageVersion}` with the version of the package.

#### Install using .NET CLI

Run the following command in a command-line interface:

```
dotnet add {YourProject} package LibUISharp -v 1.0.0-build-{BuildNumber} -s https://nuget.pkg.github.com/tom-corwin/index.json
```

### Building From Source

You can build the packages just by installing the prerequisites and running a single. Use the steps below to get started!

#### Build Prerequisites

| Operating System | Prerequisites               |
| :--------------- | :---------------------------|
| Windows 7/8.1/10 | Microsoft .NET Core 3.0 SDK |
| Linux            | Microsoft .NET Core 3.0 SDK |
| macOS            | Microsoft .NET Core 3.0 SDK |

#### Build Using a CLI

Run the following command in a command-line interface in the root directory of this repository:

```
dotnet build dirs.proj
```

[Repo.Size.Badge]: https://img.shields.io/github/repo-size/tom-corwin/libuisharp.svg?color=grey&label=Size&logo=github
[Repo.Link]: https://github.com/tom-corwin/libuisharp
[Repo.TopLang.Badge]: https://img.shields.io/github/languages/top/tom-corwin/libuisharp.svg?color=grey&label=C%23&logo=github
[Repo.Contributors.Badge]: https://img.shields.io/github/contributors/tom-corwin/libuisharp.svg?color=grey&label=Contributors&logo=github
[Repo.Contributors.Link]: https://github.com/tom-corwin/libuisharp/graphs/contributors
[Repo.Issues.Open.Badge]: https://img.shields.io/github/issues-raw/tom-corwin/libuisharp.svg?color=grey&label=Open%20Issues&logo=github
[Repo.Issues.Open.Link]: https://github.com/tom-corwin/libuisharp/issues?&q=is%3Aissue+is%3Aopen
[Repo.Issues.Closed.Badge]: https://img.shields.io/github/issues-closed-raw/tom-corwin/libuisharp.svg?color=grey&label=Closed%20Issues&logo=github
[Repo.Issues.Closed.Link]: https://github.com/tom-corwin/libuisharp/issues?&q=is%3Aissue+is%3Aclosed
[Repo.Issues.HelpWanted.Badge]: https://img.shields.io/github/issues-raw/tom-corwin/libuisharp/HelpWanted.svg?color=grey&label=Help%20Wanted%20Issues&logo=github
[Repo.Issues.HelpWanted.Link]: https://github.com/tom-corwin/libuisharp/issues?q=is%3Aissue+is%3Aopen+label%3A%22HelpWanted%22
[Repo.Issues.GoodFirstIssue.Badge]: https://img.shields.io/github/issues-raw/tom-corwin/libuisharp/GoodFirstIssue.svg?color=grey&label=Good%20First%20Issues&logo=github
[Repo.Issues.GoodFirstIssue.Link]: https://github.com/tom-corwin/libuisharp/issues?q=is%3Aissue+is%3Aopen+label%3A%22GoodFirstIssue%22
[Repo.Contributing.Link]: https://github.com/tom-corwin/libuisharp/blob/CONTRIBUTING.md
[Repo.Packages]: https://github.com/tom-corwin/libuisharp/packages
[Codacy.Badge]: https://img.shields.io/codacy/grade/2140aa3a23a848a28391aa3c778b9526/master.svg?label=Codacy+Grade&logo=codacy
[Codacy.Link]: https://www.codacy.com/app/tom-corwin/libuisharp?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=tom-corwin/libuisharp&amp;utm_campaign=Badge_Grade
[Dependabot.Badge]: https://badgen.net/dependabot/tom-corwin/libuisharp?icon=dependabot
[Dependabot.Link]: https://api.dependabot.com/badges/status?host=github&repo=tom-corwin/libuisharp
[Gitter.Badge]: https://img.shields.io/gitter/room/tom-corwin/libuisharp.svg?label=Chat&logo=gitter
[Gitter.Link]: https://gitter.im/tom-corwin/libuisharp?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge
[tomcorwin.tcdfx.Link]: https://github.com/tom-corwin/tcdfx
[andlabs.libui.Link]: https://github.com/andlabs/libui
[andlabs.libui.remodel.Link]: https://github.com/andlabs/libui/tree/remodel
[AzurePipelines.Link]: https://azure.microsoft.com/en-us/services/devops/pipelines/
[DotNetCore.SupportedOS.Link]: https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md
[Build.Link]: https://dev.azure.com/tom-corwin/libuisharp/_build/latest?definitionId=15&branchName=master
[Build.Windows81x86.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows81x86_Debug
[Build.Windows81x86.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows81x86_Release
[Build.Windows81x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows81x64_Debug
[Build.Windows81x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows81x64_Release
[Build.Windows10x86.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows10x86_Debug
[Build.Windows10x86.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows10x86_Release
[Build.Windows10x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows10x64_Debug
[Build.Windows10x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Windows10x64_Release
[Build.Ubuntu1604x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Ubuntu1604x64_Debug
[Build.Ubuntu1604x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Ubuntu1604x64_Release
[Build.Ubuntu1804x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Ubuntu1804x64_Debug
[Build.Ubuntu1804x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=Ubuntu1804x64_Release
[Build.macOS1013x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=macOS1013x64_Debug
[Build.macOS1013x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=macOS1013x64_Release
[Build.macOS1014x64.Debug.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=macOS1014x64_Debug
[Build.macOS1014x64.Release.Badge]: https://dev.azure.com/tom-corwin/libuisharp/_apis/build/status/libuisharp?branchName=master&jobName=macOS1014x64_Release
