---
lab:
    title: 'Lab 00: Validate lab environment'
---


## Practice Lab – Validate my lab environment

Attention to MCTs: Please make sure you are familiar with the [TrainerPrepGuide](../PL-400T00A-ENU-TrainerPrepGuide.pdf) for this course, especially the teaching tips and recommendations.

Scenario
--------

In this Module 0 lab, you will acquire a Power Platform trial tenant, access the Power Platform admin center and setup your Azure DevOps account. In the admin center, we will create an individual environment for configuration during the course.

Exercise 1 – Acquire your Power Platform trial tenant 
------------------------------------------

1.  Copy your **Microsoft 365 credentials** from the Authorized Lab Hoster.

2.  Navigate to [https://powerapps.microsoft.com](https://powerapps.microsoft.com) and select **Start free**. 

3.  Enter the email address from your Microsoft 365 credentials.

4.  You will see a prompt that you have an existing account with Microsoft. Select **Sign in**.

5.  Enter the password provided by the Authorized Lab Hoster. 

6.  Select **Yes** to stay signed in.

7.  You will be redirected to `https://make.powerapps.com/`


Exercise 2 - Create your environment 
------------------------------------------

In this exercise, you will create your **Development** environment that you will do the majority of your lab work in.

### Task 1 – Create environment

1.  In a new tab, navigate to the Power Platform admin center `https://aka.ms/ppac` and if prompted, sign in with your Microsoft 365 credentials.

2.  Select **Environments** and select **+ New**.

    - For **Name**, enter **[my initials] Dev** (Example: AJ Dev)
    
    - For **Type**, select **Trial**.
    
    - Change the toggle on **Create a Dataverse data store?** to **Yes**.
    
3.  Leave all other selections as default and select **Next**.
    
4.  On the **Add Dataverse** tab, leave all selections as default and select **Save**. 

5.  Verify your **Dev** environment now shows in the list of environments. 

6.  Your environment may take a few minutes to provision. Refresh the page if needed. 

7.  When the environment is **Ready**, select the **Dev** environment and select **Settings**. 

8.  Explore the different areas in **Settings** that you are interested in but do not make any changes yet. 


Exercise 3 - Azure DevOps account setup
------------------------------------------

In this exercise, you will create your Azure DevOps account that you will be using in Lab 10.

1.  Get a new Azure Pass (valid for 30-days) from the instructor or other source. 

2.  Use a private browser session, go to `microsoftazurepass.com` to redeem your Azure Pass using your Microsoft 365 credentials. 

    [Redeem a Microsoft Azure Pass](https://www.microsoftazurepass.com/Home/HowTo?Length=5) Follow the instructions for redemption. 

3.  Using the same browser session, go to `portal.azure.com`, then search for `Azure DevOps`. From the results, select **Azure DevOps Organizations**. 

4.  Next, select the “My Azure DevOps Organizations” link, or navigate to `https://aex.dev.azure.com/` 

5.  Confirm your account details. 

6.  Select the **Create a new organization** button. 

7.  Provide a unique Azure DevOps Organization name like FL-PermitManagement (replace FL with your initials) and select **Continue**. 

8.  Select **Organization settings** on the left-hand side of the screen. 

9.  Navigate to **General > Billing > Setup billing > Select an Azure subscription**, then select the Azure Pass subscription, then select **Save**. 

10. Under **MS Hosted CI/CD**, set the field **Paid parallel jobs** to 1 and select **Save**. 

11. Wait at least 3 hours before using the CI/CD capabilities so that new settings are reflected in the back end. Otherwise you will still see the message “This agent is not running because you have reached the maximum number of requests…”. 

12. As an optional step, you can validate this by creating a new pre-defined project using the newly created org with billing enabled, using `https://azuredevopsdemogenerator.azurewebsites.net` Wait for some time before trying, then run a test build. 

