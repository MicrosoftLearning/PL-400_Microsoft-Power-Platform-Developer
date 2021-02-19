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

Attention to MCTs: Please make sure you are familiar with the [TrainerPrepGuide](PL-400T00A-ENU-TrainerPrepGuide.pdf) for this course, especially the teaching tips and recommendations.

Scenario
--------

In this Module 0 lab, you will acquire a Power Platform trial tenant and access the Power Platform admin center. In the admin center, we will create an individual environment for configuration during the course.

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

In this exercise, you will be create your **Development** environment that you will do the majority of your lab work in.

### Task 1 – Create environment

1.  Access <https://admin.Powerplatform.microsoft.com> and log in with your Microsoft 365 credentials if prompted again.

2. Select **Environments** and click **+New.**

    - For **Name**, enter **[my initials] Dev** (Example: AJ Dev)
    
    - For **Type**, select **Trial.**
    
    - Change the toggle on **Create a database for this environment?** to **Yes.**
    
    - Leave all other selections as default and click **Save.**
    
    - On the next tab, leave all selections to default and click **Save** again.

3. Your **Dev** environment should now show in the list of Environments. 

4. Your environment may take a few minutes to provision. Refresh the page if needed. When your environment is prepared, select your **Dev** environment by clicking on the ellipses next to its name to expand the drop down menu and select **Settings.** 

3.  Explore the different areas in **Settings** that you are interested in but do not make any changes yet. 
