---
lab:
    title: 'Lab 00: Validate lab environment'
---

> [!NOTE]
> Effective November 2020:
> - Common Data Service has been renamed to Microsoft Dataverse. [Learn more](https://aka.ms/PAuAppBlog)
> - Some terminology in Microsoft Dataverse has been updated. For example, *entity* is now *table* and *field* is now *column*. [Learn more](https://go.microsoft.com/fwlink/?linkid=2147247)
>
> This content will be updated soon to reflect the latest terminology.


## Practice Lab – Validate lab environment

Attention to MCTs: Please make sure you are familiar with the [TrainerPrepGuide](../PL-400T00A-ENU-TrainerPrepGuide.pdf) for this course, especially the teaching tips and recommendations.

Scenario
--------

In this Module 0 lab, you will acquire a Power Platform trial tenant, access the Power Platform admin center and setup your Azure DevOps account. In the admin center, we will create an individual environment for configuration during the course.

Exercise 1 – Acquire your Power Platform trial tenant 
------------------------------------------

1. Copy your **Microsoft 365 credentials** from the Authorized Lab Hoster.

2. Navigate to <powerapps.microsoft.com> and click **Start free.**

3. Under **Work email**, enter the email address from your Microsoft 365 credentials.

4. You see a prompt that you have an existing account with Microsoft. Select **Sign in.**

5. Enter the password provided by the Authorized Lab Hoster. 

6. Select **Yes** to stay signed in.


Exercise 2 - Create your environment 
------------------------------------------

In this exercise, you will create your **Development** environment that you will do the majority of your lab work in.

### Task 1 – Create environment

1.  Access <https://admin.Powerplatform.microsoft.com> and log in with your Microsoft 365 credentials if prompted again.

2. Select **Environments** and click **+New.**

    - For **Name**, enter **[my initials] Dev** (Example: AJ Dev)
    
    - For **Type**, select **Trial.**
    
    - Change the toggle on **Create a database for this environment?** to **Yes.**
    
    - Leave all other selections as default and click **Next.**
    
    - On the next tab, leave all selections to default and click **Save**

3. Your **Dev** environment should now show in the list of Environments. 

4. Your environment may take a few minutes to provision. Refresh the page if needed. When your environment is prepared, select your **Dev** environment by clicking on the ellipses next to its name to expand the drop down menu and select **Settings.** 

3.  Explore the different areas in **Settings** that you are interested in but do not make any changes yet. 

Exercise 3 - Azure DevOps account setup
------------------------------------------

In this exercise, you will create your Azure DevOps account that you will be using in Lab10

1. Get a new Azure Pass (valid for 30-days) from the instructor or other source.

2. Use a private browser session, go to Microsoftazurepass.com to redeem your Azure Pass using the Dynamics 365 (or M365) credentials provided to you). [Redeem a Microsoft Azure Pass](https://www.microsoftazurepass.com/Home/HowTo?Length=5) Follow the instructions for redemption. 

3. Using the same browser session, go to portal.azure.com, then search for “Azure DevOps”. In the resulting page, click Azure DevOps Organizations. 

4. Next, click on the link called “My Azure DevOps Organizations” (or navigate to https://aex.dev.azure.com/).

5. In the drop down box on the left, choose Default, instead of “Microsoft Account”

6. Create a new organization (find blue box in upper right-hand corner of the screen) using the Default directory. Provide a unique Azure DevOps Organization name like FL-
PermitManagement (replace FL with your first and last initials), select your region and click Continue.

8. Choose the newly created organization, then choose Organization settings on the left-hand side of the screen

9. Navigate to Organization settings -> Billing -> Setup billing -> Select an Azure subscription, then select the Azure Pass subscription, then choose “MS Hosted CI/CD” and set the field “Paid parallel jobs” to 1. Then click SAVE in the blue box at the bottom. 

10. Wait at least 3 hours before using the CI/CD capabilities so that new settings are reflected in the back end. Otherwise you will still see the message “This agent is not running because you have reached the maximum number of requests…”.

11. As an optional step, you can validate this by creating a new pre-defined project using the newly created org with billing enabled, using https://azuredevopsdemogenerator.azurewebsites.net/. Wait for some time before trying, then run a test build.

