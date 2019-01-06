# Simple Web Stress Analysis Tool
## Overview

This is a simple tool to check if the website satisfies the Availability principle of CIA triad i.e. how much web traffic can  a website handle. This tool is available for both Windows Operating Systems and Linux Operating Systems.

- **Windows:** You can download this tool as Console App as well as Windows GUI App
    - **Windows Console App**: [Download Zip File](https://sudeshkumar.me/SimpleWebStressAnalysisTool(WindowsConsole).zip)
    - **Windows GUI App**: [Download Zip File](https://sudeshkumar.me/SimpleWebStressAnalysisTool(WindowsGUI).zip)

- **Linux:** You can download this tool as Console App only for Linux operating systems
    - **Linux Console App (64 bit)**: [Download Zip File](https://sudeshkumar.me/SimpleWebStressAnalysisTool(LinuxConsole-64bit).zip)

## Prerequisites and Installation

Depending on the Operating System, following runtimes are required by the tool to work:

- **Windows:** .NET Framework 4.6.1 runtime is needed for this app to work.This is installed by default in Windows. If not installed, you can install it by following instructions from [here](https://dotnet.microsoft.com/download/thank-you/net472).

- **Linux:** .NET Core SDK is needed to be installed for this app to work. If not installed, depending on your linux distro , you can install it from [here](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-current).

For installing, follow the instructions included in the setup zip files.

## Performance

This tool uses Multithreading and async-await programming concepts of C# language. All Console apps are made in .NET Core 2.1 and Windows GUI app is made in .NET Framework 4.6.1 Windows Forms app. This tool tries to utilise as much as CPU as possible. Since the number of threads that can be executed simultaneously depends on the CPU and number of cores available, therefore, more powerful CPUs will give better results.

Different Operating Systems implement Multithreading differently, therefore, perdormance of this tool also dependens on the underlying operating system. Generally, Operating systems based on Linux Kernel give better performance.
