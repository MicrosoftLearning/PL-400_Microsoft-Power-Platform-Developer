---
lab:
    title: 'Lab 0: Validate lab environment'
    module: 'Module 0: Course Introduction'
---

# Practice Lab 0 - Validate lab environment

## WWL Tenants - Terms of Use

If you are being provided with a tenant as a part of an instructor-led training delivery, please note that the tenant is made available for the purpose of supporting the hands-on labs in the instructor-led training.

Tenants should not be shared or used for purposes outside of hands-on labs. The tenant used in this course is a trial tenant and cannot be used or accessed after the class is over and are not eligible for extension.

Tenants must not be converted to a paid subscription. Tenants obtained as a part of this course remain the property of Microsoft Corporation and we reserve the right to obtain access and repossess at any time.

> [!IMPORTANT]
> This lab provides you with a Microsoft 365 tenant and licenses for the Power Platform applications you will be using in this course. You will only be provided with one tenant for the practice labs in this course. The settings and actions you take within this tenant do not roll-back or reset, whereas the virtual machine you are provided with does reset each time you close the lab session. Please be aware that Microsoft 365 and Power Platform are evolving all the time. The instructions in this document may be different from what you experience in your actual tenant. It is also possible to experience a delay of several minutes before the virtual machine has network connectivity to begin the labs.

## Exercise 1 - Download lab files

1. From the lab virtual machine, click **Start** and search for **PowerShell** then open **PowerShell as Administrator**.

   ![Start Powershell as administrator.](../images/L00/start-powershell.png)

1. Select **Yes** if prompted.

1. Run the following commands to download the latest version of the lab files to the virtual machine.

   > [!NOTE]
   > If any of the commands fail run them again until they are successful.

1. Create folder for lab files.

   ```powershell
   New-Item -Path "C:\" -Name "LabFiles" -ItemType "directory"   
   ```

1. Download ZIP file from GitHub.

   ```powershell
   ([System.Net.WebClient]::new()).DownloadFile('https://github.com/MicrosoftLearning/PL-400_Microsoft-Power-Platform-Developer/archive/master.zip', 'C:\LabFiles\master.zip')
   ```

1. Expand ZIP file.

   ```powershell
   Expand-Archive -Path 'C:\LabFiles\master.zip' -DestinationPath 'C:\LabFiles'
   ```

1. Move files to C:\Labfiles

   ```powershell
   Move-item -Path "C:\LabFiles\PL-400_Microsoft-Power-Platform-Developer-master\Allfiles\Labs\*" -Destination "C:\LabFiles" -confirm: $false
   ```

    ![Powershell commands.](../images/L00/powershell-commands.png)

1. Delete files not required for labs.

   ```powershell
   Remove-item 'C:\LabFiles\PL-400_Microsoft-Power-Platform-Developer-master' -recurse -force
   ```

1. Delete zip file.

   ```powershell
   Remove-item 'C:\LabFiles\master.zip'
   ```

   > [!NOTE]
   > Please note, the files are copied to C:\Labfiles and whenever asked to navigate to a lab files, you should use this location.

    ![Labfiles folders.](../images/L00/labfiles-folder.png)

## Exercise 2 – Power Platform trial

In this exercise, you will add a Power Apps trial to the tenant and assign licenses to users.

### Task 2.1 – Sign up for a Power Apps per user trial

1. Navigate to <https://admin.microsoft.com>.

1. Enter the email address from your Microsoft 365 credentials in the text box that says **Email, phone, or Skype** .

1. Click **Next**.

1. Enter the password from your Microsoft 365 credentials.

1. Click **Sign in**.

1. Select **Yes** to stay signed in.

1. In the left-hand navigation, expand **Billing** and select **Purchase services**.

    ![Purchase services.](../images/L00/purchase-services.png)

1. In the search all product categories text box, enter `PowerApps` and press **Enter**.

1. Scroll down and locate the **Power Apps per user plan** and click on **Details**.

    ![Power Apps per user plan.](../images/L00/per-user-plan.png)

1. Click **Start free trial**.

1. Click **Try now**.

1. Click **Continue**.

### Task 2.2 – Assign Power Apps licenses to your user

1. In the left-hand navigation, expand **Users** and select **Active users**.

1. Click on your user, **MOD Administrator**, to open the user details panel and select the **Licenses and apps** tab. ![Mod Administrator licenses.](../images/L00/mod-administrator.png)

1. Check the box for **Power Apps per user plan**.

1. Select **Save changes**.

1. Click on **X** in the top right of the user details panel to close the panel.

### Task 2.3 – Assign Power Apps licenses to other users

1. In the left-hand navigation, expand **Users** and select **Active users**.

1. Check the boxes next to the other users, click on the **ellipses (...**) in the action bar, and select **Manage product licenses**.

    ![Select other users.](../images/L00/select-users.png)

1. Select **Assign more** and check the box for **Power Apps per user plan**.

    ![Add more licenses.](../images/L00/add-licenses.png)

1. Click **Save changes**.

1. Click **Done**.

## Exercise 3 - Create environments

In this exercise, you will create a *Development* environment that you will do the majority of your lab work in and a *Live* environment to use to deploy solutions.

> [!NOTE]
> Depending on the browser that you are using, it is suggested that you disable any pop-up blockers that maybe enabled. This will prevent popup screens from not appearing as they should.

### Task 3.1 – Create development environment

1. Navigate to the Power Platform admin center <https://admin.powerplatform.microsoft.com> and sign in with your Microsoft 365 credentials if prompted again.

1. Click **Get Started** if a Welcome to the Power Platform admin center popup is shown.

1. Select **Environments** from the left navigation pane. There should be a single environment, *Contoso (default)*.

1. Click **+ New**.

   ![Environment in the Power Platform admin center.](../images/L00/ppac-environments.png)

1. In the **Name** text box, enter `[my initials] Development`. (Example: PL Development).

1. In the **Type** drop down, select **Developer**.

1. Leave all other selections as default and select **Next**.

   ![New environment.](../images/L00/new-environment.png)

1. On the **Add Dataverse** tab, select **Save**.

1. Your **Development** environment should now show in the list of environments.

    ![Environment in the Power Platform admin center.](../images/L00/ppac-environments-dev.png)

1. Your Development environment may take a few minutes to provision. Use the refresh icon if needed. When your environment shows as Ready, select your **Development** environment by clicking on the ellipses (...) next to its name to expand the drop down menu and select **Settings**.

   ![Environment in the Power Platform admin center.](../images/L00/ellipses-settings-dev.png)

1. Explore the different areas in **Settings** that you may be interested in but do not make any changes yet.

### Task 3.2 – Create production environment

1. Navigate to environments in the Power Platform admin center <https://admin.powerplatform.microsoft.com/environments>.

1. Click **+ New**.

1. In the **Name** text box, enter `[my initials] Live`. (Example: PL Live).

1. In the **Type** drop down, select **Developer**.

1. Leave all other selections as default and select **Next**.

1. On the **Add Dataverse** tab, select **Save**.

1. You should now see three environments; Contoso (default), Development, and Live.

   ![Environments.](../images/L00/environments-all.png)

   > [!IMPORTANT]
   > You will use the *Development* environment for all customizations in the labs. The *Live* environment will act as your test/production environment.

## Exercise 4 - Azure subscription

In this exercise, you will create an Azure subscription that you will be using in later labs.

### Task 4.1 – Redeem Azure Pass

1. Obtain a new Azure Pass (valid for 30-days) from the instructor, lab provider, or other source.

1. Navigate to the Azure Pass redemption page <https://www.microsoftazurepass.com> and sign in with your Microsoft 365 credentials.

1. Follow these instructions to redeem your Azure Pass.

   [Redeem a Microsoft Azure Pass](https://www.microsoftazurepass.com/Home/HowTo?Length=5)

1. On the Your profile page, change *Last name* from *Administrator* to **Developers**.

1. On the Your profile page, you will need to enter a valid *Address line 1*, *City*, and *Postal Code* and agree to the subscription offer. Do not change any other details.

   > [!NOTE]
   > If you are prompted for a *Phone number* when using the Power Platform or Azure portals, enter `0123456789` and click on **Submit**.

1. Wait for the Azure subscription to be provisioned and select **Maybe later**.

1. Select **Subscriptions**. You should see **Azure Pass - Sponsorship**.

   ![Azure Pass subscription.](../images/L00/azure-subscription.png)
