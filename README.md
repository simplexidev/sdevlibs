[![GitHubWatchers.Image]][GitHubWatchers.Link]
[![GitHubForks.Image]][GitHubForks.Link]
[![GitHubStars.Image]][GitHubStars.Link]
[![Gitter.Image]][Gitter.Link]

***NOTICE**: This project was just renamed from `LibUISharp` to `sdfx`.*  
***NOTICE**: This project is still a work-in-progress, and should not be used in a production environment.*  
***NOTICE**: The native dependency ['andlabs/libui'](https://github.com/andlabs.libui) is early-alpha software, and as such is unstable.*

# SimplexiDev Framework

SimplexiDev Framework, or `SDFx` for short, is a collection of .NET libraries to create robust desktop applications on Windows, macOS, and Linux.

## Contributing

[![GitHubOpenIssues.Image]][GitHubOpenIssues.Link]
[![GitHubClosedIssues.Image]][GitHubClosedIssues.Link]  
[![GitHubOpenPulls.Image]][GitHubOpenPulls.Link]
[![GitHubMergedPulls.Image]][GitHubMergedPulls.Link]
[![GitHubClosedPulls.Image]][GitHubClosedPulls.Link]

Contributing is as easy as filing an issue, fixing a bug, starting a discussion, or suggesting a new feature. For more
information about contributing to this project, see the [CONTRIBUTING.md][CONTRIBUTINGmd] file.

Please hold off on submitting pull requests until #39 is merged. If you *really* want to prepare a pull request until then, please use the branch `feature/internal/new-infrastructure`.

## Project Status

[![Codacy.Badge]][Codacy.Link]
[![Dependabot.Badge]][Dependabot.Link]

### Build Status

We currently use [Azure DevOps][Build.Link] for our automated build process. While we only build for a few platforms, our packages
*should* be able to be used on any platform [supported by .NET 6][NET6SupportedOS].

| Package                               | Status                                                                                                                                                                                                                                             |
| :------------------------------------ | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| SimplexiDev.Audio                      | [![Build.Audio.Windows2019]][Build.Link]<br/>[![Build.Audio.Windows2022]][Build.Link]<br/>[![Build.Audio.Ubuntu1804]][Build.Link]<br/>[![Build.Audio.Ubuntu2004]][Build.Link]<br/>[![Build.Audio.macOS1015]][Build.Link]<br/>[![Build.Audio.macOS11]][Build.Link]                                                                                                                         |
| SimplexiDev.Build.Annotations          | [![Build.BuildAnnotations.Windows2019]][Build.Link]<br/>[![Build.BuildAnnotations.Windows2022]][Build.Link]<br/>[![Build.BuildAnnotations.Ubuntu1804]][Build.Link]<br/>[![Build.BuildAnnotations.Ubuntu2004]][Build.Link]<br/>[![Build.BuildAnnotations.macOS1015]][Build.Link]<br/>[![Build.BuildAnnotations.macOS11]][Build.Link]                                                 |
| SimplexiDev.Build.NativeCallGenerator  | [![Build.BuildNativeCallGenerator.Windows2019]][Build.Link]<br/>[![Build.BuildNativeCallGenerator.Windows2022]][Build.Link]<br/>[![Build.BuildNativeCallGenerator.Ubuntu1804]][Build.Link]<br/>[![Build.BuildNativeCallGenerator.Ubuntu2004]][Build.Link]<br/>[![Build.BuildNativeCallGenerator.macOS1015]][Build.Link]<br/>[![Build.BuildNativeCallGenerator.macOS11]][Build.Link] |
| SimplexiDev.Core                       | [![Build.Core.Windows2019]][Build.Link]<br/>[![Build.Core.Windows2022]][Build.Link]<br/>[![Build.Core.Ubuntu1804]][Build.Link]<br/>[![Build.Core.Ubuntu2004]][Build.Link]<br/>[![Build.Core.macOS1015]][Build.Link]<br/>[![Build.Core.macOS11]][Build.Link] |
| SimplexiDev.IO.Compression             | [![Build.IOCompression.Windows2019]][Build.Link]<br/>[![Build.IOCompression.Windows2022]][Build.Link]<br/>[![Build.IOCompression.Ubuntu1804]][Build.Link]<br/>[![Build.IOCompression.Ubuntu2004]][Build.Link]<br/>[![Build.IOCompression.macOS1015]][Build.Link]<br/>[![Build.IOCompression.macOS11]][Build.Link] |
| SimplexiDev.Native.Libui               | [![Build.NativeLibui.Windows2019]][Build.Link]<br/>[![Build.NativeLibui.Windows2022]][Build.Link]<br/>[![Build.NativeLibui.Ubuntu1804]][Build.Link]<br/>[![Build.NativeLibui.Ubuntu2004]][Build.Link]<br/>[![Build.NativeLibui.macOS1015]][Build.Link]<br/>[![Build.NativeLibui.macOS11]][Build.Link] |
| SimplexiDev.Native.Miniaudio           | [![Build.NativeMiniaudio.Windows2019]][Build.Link]<br/>[![Build.NativeMiniaudio.Windows2022]][Build.Link]<br/>[![Build.NativeMiniaudio.Ubuntu1804]][Build.Link]<br/>[![Build.NativeMiniaudio.Ubuntu2004]][Build.Link]<br/>[![Build.NativeMiniaudio.macOS1015]][Build.Link]<br/>[![Build.NativeMiniaudio.macOS11]][Build.Link] |
| SimplexiDev.Native.Zstd                | [![Build.NativeZstd.Windows2019]][Build.Link]<br/>[![Build.NativeZstd.Windows2022]][Build.Link]<br/>[![Build.NativeZstd.Ubuntu1804]][Build.Link]<br/>[![Build.NativeZstd.Ubuntu2004]][Build.Link]<br/>[![Build.NativeZstd.macOS1015]][Build.Link]<br/>[![Build.NativeZstd.macOS11]][Build.Link] |
| SimplexiDev.UI                         | [![Build.UI.Windows2019]][Build.Link]<br/>[![Build.UI.Windows2022]][Build.Link]<br/>[![Build.UI.Ubuntu1804]][Build.Link]<br/>[![Build.UI.Ubuntu2004]][Build.Link]<br/>[![Build.UI.macOS1015]][Build.Link]<br/>[![Build.UI.macOS11]][Build.Link] |
| SimplexiDev.UI.Extras                  | [![Build.UIExtras.Windows2019]][Build.Link]<br/>[![Build.UIExtras.Windows2022]][Build.Link]<br/>[![Build.UIExtras.Ubuntu1804]][Build.Link]<br/>[![Build.UIExtras.Ubuntu2004]][Build.Link]<br/>[![Build.UIExtras.macOS1015]][Build.Link]<br/>[![Build.UIExtras.macOS11]][Build.Link] |

### Current Releases

Stable and preview packages are published on [NuGet][NuGetorg]. Our CI builds are published to [MyGet][MyGetorg].

<!--TODO: Table of release badges (stable, preview, other) -->

## Using SDFx Packages

For examples, see the `examples\` directory.

### Utilizing Pre-Built Packages

While following these instructions:

  * Replace `{YourProject}` with the the name of your project file.  
  * Replace `{PackageName}` with the package you want to use.  
  * Replace `{PackageVersion}` with the version of the package.

#### Install using .NET CLI

Run the following command in a command-line interface:

```
dotnet add {YourProject} package {PackageName} -v {PackageName}
```

### Building From Source

You can build the packages by installing the [.NET 6 SDK][NET6Sdk] and using the following command in the root of the repository:

```
dotnet build sdfx.sln
```

[SDFx]: https://github.com/simplexidev/sdfx
[CONTRIBUTINGmd]: https://github.com/simplexidev/sdfx/blob/main/CONTRIBUTING.md
[Gitter.Image]: https://img.shields.io/gitter/room/simplexidev/sdfx.svg?label=Chat&logo=gitter
[Gitter.Link]: https://gitter.im/simplexidev/sdfx?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge
[GitHubWatchers.Image]: https://badgen.net/github/watchers/simplexidev/sdfx?label=Watchers&icon=github&color=black
[GitHubWatchers.Link]: https://github.com/simplexidev/sdfx/watchers
[GitHubForks.Image]: https://badgen.net/github/forks/simplexidev/sdfx?label=Forks&icon=github&color=black
[GitHubForks.Link]: https://github.com/simplexidev/sdfx/network/members
[GitHubStars.Image]: https://badgen.net/github/stars/simplexidev/sdfx?label=Stars&icon=github&color=black
[GitHubStars.Link]: https://github.com/simplexidev/sdfx/stargazers
[GitHubOpenIssues.Image]: https://badgen.net/github/open-issues/simplexidev/sdfx?label=Open%20Issues&icon=github&color=green
[GitHubOpenIssues.Link]: https://github.com/simplexidev/sdfx/issues?q=is%3Aissue+is%3Aopen
[GitHubClosedIssues.Image]: https://badgen.net/github/closed-issues/simplexidev/sdfx?label=Open%20Issues&icon=github&color=red
[GitHubClosedIssues.Link]: https://github.com/simplexidev/sdfx/issues?q=is%3Aissue+is%3Aclosed
[GitHubOpenPulls.Image]: https://badgen.net/github/open-prs/simplexidev/sdfx?label=Open%20PRs&icon=github&color=green
[GitHubOpenPulls.Link]: https://github.com/simplexidev/sdfx/pulls?q=is%3Apr+is%3Aopen
[GitHubMergedPulls.Image]: https://badgen.net/github/merged-prs/simplexidev/sdfx?label=Merged%20PRs&icon=github&color=purple
[GitHubMergedPulls.Link]: https://github.com/simplexidev/sdfx/pulls?q=is%3Apr+is%3Amerged
[GitHubClosedPulls.Image]: https://badgen.net/github/closed-prs/simplexidev/sdfx?label=Closed%20PRs&icon=github&color=red
[GitHubClosedPulls.Link]: https://github.com/simplexidev/sdfx/pulls?q=is%3Apr+is%3Aclosed
[GitHubRepoSize.Image]: https://img.shields.io/github/repo-size/simplexidev/sdfx?color=black&label=Size&logo=github&style=flat-square
[GitHubDiscussions.Image]: https://img.shields.io/github/discussions/simplexidev/sdfx?color=black&label=Discussions&logo=github
[GitHubDiscussions.Link]: https://github.com/simplexidev/sdfx/discussions
[GitHubLanguages.Image]: https://img.shields.io/github/languages/count/simplexidev/sdfx?color=black&label=Languages&logo=github&style=flat-square
[GitHubSponsors.Image]: https://img.shields.io/github/sponsors/simplexidev?color=black&label=Sponsors&logo=github&style=flat-square
[Codacy.Badge]: https://img.shields.io/codacy/grade/2140aa3a23a848a28391aa3c778b9526/master.svg?label=Codacy+Grade&logo=codacy
[Codacy.Link]: https://www.codacy.com/app/simplexidev/sdfx?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=simplexidev/sdfx&amp;utm_campaign=Badge_Grade
[Dependabot.Badge]: https://badgen.net/dependabot/simplexidev/sdfx?icon=dependabot
[Dependabot.Link]: https://api.dependabot.com/badges/status?host=github&repo=simplexidev/sdfx
[NET6SupportedOS]: https://github.com/dotnet/core/blob/main/release-notes/6.0/supported-os.md
[NET6Sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
[NuGetorg]: https://nuget.org
[MyGetorg]: https://myget.org
[Build.Link]: https://dev.azure.com/simplexidev/sdfx/_build?definitionId=1
[Build.Audio.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.Audio.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.Audio.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.Audio.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.Audio.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.Audio.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Audio&jobName=Build_Audio_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.BuildAnnotations.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.BuildAnnotations.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.BuildAnnotations.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.BuildAnnotations.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.BuildAnnotations.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.BuildAnnotations.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildAnnotations&jobName=Build_BuildAnnotations_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.BuildNativeCallGenerator.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.BuildNativeCallGenerator.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.BuildNativeCallGenerator.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.BuildNativeCallGenerator.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.BuildNativeCallGenerator.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.BuildNativeCallGenerator.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_BuildNativeCallGenerator&jobName=Build_BuildNativeCallGenerator_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.Core.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.Core.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.Core.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.Core.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.Core.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.Core.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_Core&jobName=Build_Core_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.IOCompression.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.IOCompression.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.IOCompression.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.IOCompression.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.IOCompression.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.IOCompression.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_IOCompression&jobName=Build_IOCompression_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.NativeLibui.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeLibui.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeLibui.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.NativeLibui.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.NativeLibui.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.NativeLibui.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeLibui&jobName=Build_NativeLibui_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.NativeMiniaudio.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeMiniaudio.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeMiniaudio.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.NativeMiniaudio.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.NativeMiniaudio.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.NativeMiniaudio.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeMiniaudio&jobName=Build_NativeMiniaudio_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.NativeZstd.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeZstd.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.NativeZstd.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.NativeZstd.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.NativeZstd.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.NativeZstd.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_NativeZstd&jobName=Build_NativeZstd_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.UI.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.UI.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.UI.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.UI.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.UI.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.UI.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UI&jobName=Build_UI_macOS11&label=macOS%2011&logo=apple&logoColor=white
[Build.UIExtras.Windows2019]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.UIExtras.Windows2022]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_Windows2022&label=Windows%202022&logo=windows&logoColor=white
[Build.UIExtras.Ubuntu1804]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_Ubuntu1804&label=Ubuntu%2018.04&logo=ubuntu&logoColor=white
[Build.UIExtras.Ubuntu2004]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_Ubuntu2004&label=Ubuntu%2020.04&logo=ubuntu&logoColor=white
[Build.UIExtras.macOS1015]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_macOS1015&label=macOS%2010.15&logo=apple&logoColor=white
[Build.UIExtras.macOS11]: https://img.shields.io/azure-devops/build/simplexidev/be4f542d-f3e2-4d7f-a73e-59ec30ed86db/1/main?stageName=Build_UIExtras&jobName=Build_UIExtras_macOS11&label=macOS%2011&logo=apple&logoColor=white
