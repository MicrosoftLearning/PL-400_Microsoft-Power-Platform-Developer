---
lab:
    title: 'Set up your own environment'
    module: 'Set up your own environment'
---

# Setup local lab environment

Ideally, you should complete these labs in a hosted lab environment. If you want to complete them on your own computer, you can do so by installing the following software.

- All setup and resource files can be [downloaded from GitHub](https://github.com/MicrosoftLearning/PL-400_Microsoft-Power-Platform-Developer/archive/master.zip).

***You may experience unexpected dialogs and behavior when using your own environment. Due to the wide range of possible local configurations, the course team cannot support issues you may encounter in your own environment.***

## Instructions using Windows 11

> &#128221; The instructions below are for a Windows 11 computer. Connecting from a different OS may not result in the same experience.

### Microsoft Edge

1. Install the latest version of [Microsoft Edge](https://microsoft.com/edge) to access the Power Platform online.

1. Apply updates to Edge from `edge://settings/help` ad restart Edge.

### Microsoft 365 tenant account

You will need to log into Power Platform with an organizational account. You can use your own, but if you don't have access, you can create a free [Microsoft 365 Developer account](https://developer.microsoft.com/en-us/microsoft-365/dev-program).

### .NET Framework 4.6.2 Developer Pack

1. Navigate to .NET Framework 4.6.2 Downloads `https://dotnet.microsoft.com/download/dotnet-framework/net462`.

1. Select the **Developer Pack**.

1. Open the downloaded file.

1. Follow the steps in setup wizard to omplete installing **Developer Pack.**

### Visual Studio 2022

1. If you do not have Visual Studio, you can use the community edition for training purposes.

1. Navigate to `https://visualstudio.microsoft.com/vs/community/`

1. Select **Download**.

1. Open the downloaded file, **VisualStudioSetup.exe**.

1. Follow the steps in setup wizard to complete installing **Visual Studio** with the following options selected:

   - ASP.NET and web development
       - Cloud tools for web development
   - Azure development
       - .NET Framework 4.6.2-4.7.1 development tools

### Visual Studio Code

1. Download [Visual Studio Code](https://code.visualstudio.com/docs/?dv=win).

1. Open the downloaded file.

1. Follow the steps in setup wizard to complete installing **Visual Studio Code.**

### Power Platform CLI

1. Download the Power Platform CLI `https://aka.ms/PowerAppsCLI`.

1. Run the **powerapps-cli-1.0.msi** to start the installation.

1. Use the setup wizard to complete the setup and select **Finish**.

1. Open a Command Prompt.

1. Verify Power Apps CLI is installed.

   ```dos
   pac install latest
   ```

### Power Platform Developer Plan

If you do not have a Power Platform license, you can sign up free for the Power Apps Developer Plan.

1. In a new browser tab, navigate to `https://powerapps.microsoft.com`.

1. Select **Try for free** and follow the wizard.
