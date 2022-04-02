---
lab:
    title: 'Lab 10: Application Lifecycle Management'
---



## Lab 10 – Application Lifecycle Management

# Scenario

A regional building department issues and tracks permits for new buildings and updates the remodeling of existing buildings. Throughout this course you will build applications and automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

In this lab you will use Azure DevOps for source control of your solution assets. As you have been building your app you have been tracking all the changes in a Permit Management solution. You have exported this solution, so you had a back up copy. You have also manually imported the managed version of the solution into your production environment. As part of this lab you will see how you can automate working with solutions and use the Power Apps Azure DevOps tasks to check the changes into an Azure DevOps repository. This is the start of an overall ALM process that you would put in place to automate the complete lifecycle form development to production using Azure DevOps automation. In this lab, you will be completing the first phase of that automation.

# High-level lab steps

As part of configuring Azure DevOps ALM automation, you will complete the following

- Sign in to your Azure DevOps account

- Create an Azure DevOps project

- Configure the Power Platform ALM tasks

- Build an export solution pipeline

- Test the export from dev to Azure DevOps

## Things to consider before you begin

- How often are you planning to run the build process?

- Is it going to be fully automated or run manually?

- How many users will be committing changes into the repositories and how often?

- How many instances are you planning to control? 

- Are there any other build tasks you should consider?


‎


**Requirement**

To avoid abuse Azure Pipelines now requires approval in free accounts to run pipelines. If you completed Lab 0 Exercise 3 and applied an Azure pass you are ready to proceed. Alternatively, you can use the following form to request the free grant of parallel jobs in Azure Pipelines. Please fill out [this form](https://aka.ms/azpipelines-parallelism-request)  This must be approved before you can complete the steps in this lab.


You will receive an email when your approval request is completed.

‎

# Exercise #1: Initialize Azure DevOps

**Objective:** In this exercise, you will use your Azure DevOps account to track the solution assets of the Permit Management app.

## Task #1: Sign in for Azure DevOps

1. Sign in for Azure DevOps

	- Navigate to [Azure DevOps](https://dev.azure.com/)

	- Provide your admin credentials and sign in.

2. Create the Azure DevOps project

	- Enter **Permit Management** for Project Name, select **Private**, and then select **+ Create project**.

    ![Azure DevOps project - screenshot](../L10/Static/Mod_3_ALM_image4.png)

3. Initialize Repository

	- Select **Repos**.

    ![Select repos - screenshot](../L10/Static/Mod_3_ALM_image5.png)

	- Scroll down to the bottom, make sure the **Add a Readme** checkbox is checked, and select **Initialize**.

    ![Initialize readme - screenshot](../L10/Static/Mod_3_ALM_image6.png)

## Task #2: Configure Power Platform ALM Tasks

1. Get Power Platform Build Tools

	- Sign in to [Visual Studio marketplace](https://marketplace.visualstudio.com/azuredevops) 

	- Search for **Power Platform Build Tools**.

	- Select **Power Platform Build Tools**.

    ![Power Platform build tools - screenshot](../L10/Static/Mod_3_ALM_image7.png)

	- Select **Get it Free**.

    ![Get free Power Platform build tools - screenshot](../L10/Static/Mod_3_ALM_image8.png)

	- Select the **Azure DevOps** organization you created and then select **Install**.

    ![Install Power Platform build tools - screenshot](../L10/Static/Mod_3_ALM_image9.png)

	- Select **Proceed to Organization**.

    ![Proceed to organization - screenshot](../L10/Static/Mod_3_ALM_image10.png)

2. Go to Git repositories security

	- Open the **Permit Management** project you created.

    ![Open project - screenshot](../L10/Static/Mod_3_ALM_image11.png)

	- Select **Project Settings**.

    ![Project settings - screenshot](../L10/Static/Mod_3_ALM_image12.png)

	- Select **Repositories**.

    ![Repositories - screenshot](../L10/Static/Mod_3_ALM_image13.png)

3. Add permissions to allow the build account to check in solution assets

	- Select the **Permit Management** project.

    ![Select project - screenshot](../L10/Static/Mod_3_ALM_image14.png)

	- Select the **Security** tab.

	- Search for **Project Collection Build Service** and select the one without the accounts **Project Collection.**

    ![Project collection build service - screenshot](../L10/Static/Mod_3_ALM_image15.png)

4. Set Contribute permission for the Service Accounts

	- Select the **Project Collection Build Service**.

	- Locate the **Contribute** permission and select **Allow**.

    ![Allow contribute - screenshot](../L10/Static/Mod_3_ALM_image16.png)

	- Select **Show More** to expand the menu.

    ![Show more - screenshot](../L10/Static/Mod_3_ALM_image17.png)

 

  
‎ 

# Exercise #2: Build Export Pipeline

**Objective:** In this exercise, you will build an Azure DevOps pipeline that will export the solution from the development Microsoft Dataverse environment, unpack the solution file to individual files and then check those files into the repository.

## Task #1: Export the Solution

1. Create Build Pipeline

	- Expand **Pipelines**.

    ![Pipelines - screenshot](../L10/Static/Mod_3_ALM_image18.png)

	- Select **New Pipeline**.

    ![Create new pipeline - screenshot](../L10/Static/Mod_3_ALM_image19.png)

	- Select **Use the Classic Editor.**

    ![Use the classic editor - screenshot](../L10/Static/Mod_3_ALM_image20.png)

	- Don’t change the default values. Select **Continue**.

    ![Select source - screenshot](../L10/Static/Mod_3_ALM_image21.png)

	- Select **Empty Job**.

    ![Empty job - screenshot ](../L10/Static/Mod_3_ALM_image22.png)

	- Select **Save and Queue** and then select **Save**.

    ![Save pipeline - screenshot](../L10/Static/Mod_3_ALM_image23.png)

	- Select **Save**.

    ![Save build pipeline - screenshot](../L10/Static/Mod_3_ALM_image24.png)

2. Add Power Platform Tool Installer task   
‎Note: The Power Platform Tool Installer needs to be run before any other Power Platform ALM tasks.

	- Select **+** icon to add task to **Agent Job 1**.

    ![Add task - screenshot ](../L10/Static/Mod_3_ALM_image25.png)

	- Search for **Power Platform Tool**,  hover over select **Power Platform Tool Installer** and select **Add**.

    ![Power Platform tool installer - screenshot](../L10/Static/Mod_3_ALM_image26.png)

3. Add Power Platform Export Solution task

	- Search for **Export.**

	- Hover over **Power Platform Export Solution** and select **Add**.

    ![Power Platform export solution - screenshot](../L10/Static/Mod_3_ALM_image27.png)

4. Open Power Platform Export Solution

	- Select the **Power Platform Export Solution** task.

    ![Select Power Platform export solution - screenshot](../L10/Static/Mod_3_ALM_image28.png)

5. Get your Dev Environment URL

	- Start a new browser window or tab and sign in to [Power Platform admin center](https://admin.powerplatform.microsoft.com/support) 

	- Select **Environments** and open the **Dev** environment.

	- Copy the **Environment URL** and keep it in your clipboard.

    ![Copy environment URL - screenshot](../L10/Static/Mod_3_ALM_image29.png)

	- Close the **Power Platform Admin** browser window or tab.

6. Create Generic Service Connection

	- Go back to the **Pipeline**.

	- Make sure you still have the **Power Platform Export Solution** task selected.

	- Select **Manage** service sonnection. This will open a new window.

    ![Manage service connection - screenshot](../L10/Static/Mod_3_ALM_image30.png)

	- Select **Create Service Connection**.

    ![New service connection - screenshot](../L10/Static/Mod_3_ALM_image31.png)

	- Select **Generic** and then select **Next**.

    ![Generic service connection - screenshot](../L10/Static/Mod_3_ALM_image32.png)

	- Paste the **Environment URL** you copied in Server URL, provide your admin credentials, provide a connection name, and select **Save**.

    ![Save service connection - screenshot](../L10/Static/Mod_3_ALM_image33.png)

	- Close the **Service Connections** browser window or tab.

7. Select the Generic Service Connection you created as the Service connection

	- Go back to the **Build Pipeline** tasks and make sure you still have Power Platform Export Solution task selected.

	- Locate the **Service connection** column and select **Refresh**.

    ![Refresh service connection - screenshot](../L10/Static/Mod_3_ALM_image34.png)

	- Select the **Generic Service Connection** you created.

    ![Select service connection - screenshot](../L10/Static/Mod_3_ALM_image35.png)


	- Enter $(SolutionName) for Solution Name, $(Build.ArtifactStagingDirectory)\$(SolutionName).zip for Solution Output File.


    ![Solution name and solution output file - screenshot](../L10/Static/Mod_3_ALM_image36.png)

	- Select **Save and Queue** and then select **Save**.

    ![Save tasks - screenshot](../L10/Static/Mod_3_ALM_image37.png)

	- Select **Save** again.

8. Add Unpack task.
This task will take the solution zip file and expand it into a file for each solution component.

	- Select **Add Task**.

    ![New task - screenshot](../L10/Static/Mod_3_ALM_image38.png)

	- Search for **Unpack**.

	- Hover over **Power Platform Unpack Solution** and select **Add**.

    ![Power Platform unpack solution task - screenshot](../L10/Static/Mod_3_ALM_image39.png)

9. Provide Unpack settings information

	- Select the **Unpack** task.

	- Enter $(Build.ArtifactStagingDirectory)\$(SolutionName).zip for Solution Input File, $(Build.SourcesDirectory)\$(SolutionName) for **Target Folder**.  
    ![Unpack solution task properties - screenshot](../L10/Static/Mod_3_ALM_image40.png)

	- Select **Save and Queue** and then select **Save**.

	- Select **Save** again.

10. Allow scripts to access the OAuth Token.

	- Select **Agent Job 1**.

    ![Select job - screenshot](../L10/Static/Mod_3_ALM_image41.png)

	- Scroll down and check the **Allow Scripts to Access the OAuth Token** checkbox.

    ![Allow scripts to access OAuth Token - screenshot](../L10/Static/Mod_3_ALM_image42.png)

11. Add Command Line task

	- Select **+ Add a Task**.

    ![Add new task - screenshot](../L10/Static/Mod_3_ALM_image43.png)

	- Search for **Command Line**.

	- Hover over **Command Line** and select **Add**.

    ![Command line task - screenshot](../L10/Static/Mod_3_ALM_image44.png)

12. Add Scripts to the Command Line task. This task will be used to check in the solution file changes to the repo.

	- Select the **Command Line** task.

	- Paste the script below in the **Script** text area. Replace **user@myorg.onmicrosoft.com** with your admin username.

            echo commit all changes
            git config user.email "user@myorg.onmicrosoft.com"
            git config user.name "Automatic Build"
            git checkout main
            git add --all
            git commit -m "solution init"
            echo push code to new repo
            git -c http.extraheader="AUTHORIZATION: bearer $(System.AccessToken)" push origin main

    ![Command line script - screenshot](../L10/Static/Mod_3_ALM_image45.png)

13. Add Solution Name variable

	- Select the **Variables** tab.

	- Select **+ Add.**

    ![Add variable - screenshot](../L10/Static/Mod_3_ALM_image46.png)

	- Enter **SolutionName** for **Name** and **PermitManagement** for **Value**.

    ![New variable - screenshot](../L10/Static/Mod_3_ALM_image47.png)

	- Select **Save and Queue** and then select **Save**.

	- Select **Save** again.

 

 
‎ 

# Exercise #3: Test the Pipeline

**Objective:** In this exercise, you will test the build pipeline you created.

## Task #1: Run the Pipeline

1. Open the build pipeline

	- Sign in to [Azure DevOps](https://dev.azure.com/) and open the **Permit Management** project.

    ![Open project - screenshot](../L10/Static/Mod_3_ALM_image48.png)

	- Select **Project Settings**.

    ![Project settings - screenshot](../L10/Static/Mod_3_ALM_image49.png)

	- Select **Repositories**.

    ![Repositories - screenshot ](../L10/Static/Mod_3_ALM_image50.png)

	- Select the **Permit Management** repository.

	- Select the **Security** tab.

	- Select **Permit Management Build Service** and **Allow** Contribute.

    ![Allow contribute - screenshot](../L10/Static/Mod_3_ALM_image51.png)

	- Select **Pipelines | Pipelines**.

    ![Select pipelines - screenshot](../L10/Static/Mod_3_ALM_image52.png)

	- Select **Permit Management-CI**.

	- Select **Run Pipeline**.

    ![Run pipeline - screenshot ](../L10/Static/Mod_3_ALM_image53.png)

	- Select **Run** again and wait.

    ![Run pipeline pane - screenshot ](../L10/Static/Mod_3_ALM_image54.png)

	- Wait until the job completed and then open it.

    ![Open run results - screenshot](../L10/Static/Mod_3_ALM_image55.png)

	- The Build tasks should run and succeed

    ![Job tasks - screenshot](../L10/Static/Mod_3_ALM_image56.png)

2. Review the Repository

	- Select Repos.

    ![Select repos - screenshot](../L10/Static/Mod_3_ALM_image57.png)

	- You should see **PermitManagement** folder. Open the folder.

    ![Open folder - screenshot](../L10/Static/Mod_3_ALM_image58.png)

	- The content of the folder should look like the image below.

    ![Folder content - screenshot](../L10/Static/Mod_3_ALM_image59.png)

You may examine the content of each folder.

## Task #2: Modify Solution

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Dev** environment selected.

	- Select **Solutions**.

	- Open the **Permit Management** solution.

2. Open the Permit table form for edit

	- Select **Tables** and open the **Permit** table.

    ![Open table - screenshot](../L10/Static/Mod_3_ALM_image61.png)

	- Select the **Forms** tab and open the **Main** form.

    ![Open form - screenshot ](../L10/Static/Mod_3_ALM_image62.png)

3. Move the Contact lookup column

	- Drag the **Contact** lookup column and drop it between the **Start Date** and **New Size** columns.

    ![Move column - screenshot](../L10/Static/Mod_3_ALM_image63.png)

	- Select **Save**.

	- Select **Publish** and wait for the publishing to complete.

## Task #3: Run Build Pipeline  

1. Open Permit Management DevOps project

	- Sign in to [Azure DevOps](https://dev.azure.com/) 

	- Open the **Permit Management** project

2. Run the build pipeline again

	- Select **Pipelines**.

    ![Select pipelines - screenshot](../L10/Static/Mod_3_ALM_image66.png)

	- Select **Permit Management-CI**.

	- Select **Run Pipeline**.

    ![Run pipeline - screenshot](../L10/Static/Mod_3_ALM_image67.png)

	- Select **Run** and wait for the run to complete.

	- Open the job after it completes.

    ![Open job results - screenshot](../L10/Static/Mod_3_ALM_image68.png)

	- All the tasks should succeed again.

    ![Run results - screenshot](../L10/Static/Mod_3_ALM_image69.png)

3. Check the Repository for the new changes

	- Select **Repos**.

    ![Select repos - screenshot](../L10/Static/Mod_3_ALM_image70.png)

	- Select **Commits**.

    ![Select commits - screenshot ](../L10/Static/Mod_3_ALM_image71.png)

	- Open the topmost commit.

    ![Open commit - screenshot](../L10/Static/Mod_3_ALM_image72.png)

	- The changeset should look like the image below.

    ![Changeset - screenshot](../L10/Static/Mod_3_ALM_image73.png)

4. View side-by-side.

	- Select **View**.

    ![View side-by-side - screenshot](../L10/Static/Mod_3_ALM_image74.png)

	- Side-by-side view should load.

    ![Side-by-side view - screenshot ](../L10/Static/Mod_3_ALM_image75.png)
