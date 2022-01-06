---
lab:
    title: 'Lab 03: Canvas app'
---

> [!NOTE]
> Effective November 2020:
> - Common Data Service has been renamed to Microsoft Dataverse. [Learn more](https://aka.ms/PAuAppBlog)
> - Some terminology in Microsoft Dataverse has been updated. For example, *entity* is now *table* and *Column* is now *column*. [Learn more](https://go.microsoft.com/fwlink/?linkid=2147247)
>
> This content will be updated soon to reflect the latest terminology.


## Lab 03 – Canvas app

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course you will build applications and automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

As we continue to build our solution, we will now design a Power Apps canvas app that the inspectors will use in the Column on their mobile devices. Canvas apps are low code apps that can be designed for a tablet or mobile phone layouts. You will build a two-screen canvas app that allows inspectors quickly access and process the inspections.

# High-level lab steps

We will follow the below schema to design the canvas app:

- Create the app using the tablet form factor

- Connect to Microsoft Dataverse as a data source

- Configure a gallery control to show the pending inspections

- Use a Microsoft Dataverse view to populate the gallery

- Configure a detail page with inspection info

- Handle saving the inspection results to Microsoft Dataverse

- Export the solution with the data model and apps and import it to the “Production” environment

This is the first screen in the application to show all Pending Inspections for the logged in Inspector.

![Screen one of the application - screenshot](../L03/Static/Mod_03_Canvas_App_image1.png)

This second screen lets the inspector update the selected Inspection.

![Second screen of the application - screenshot ](../L03/Static/Mod_03_Canvas_App_image2.png)

## Things to consider before you begin

- What would an inspector need quick access to while in the field?

- How do we move our solution from the development to the production environment?

- Remember to continue working in your DEVELOPMENT environment. We’ll move everything to production in Exercise 2 of this lab.

 

  
‎ 

# Exercise #1: Create Canvas App

**Objective:** In this exercise, you will create a canvas app.

## Task #1: Create Canvas App

1. Open the Permit Management solution.

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select your **Dev environment.**

	- Select **Solutions**.

	- Click to open the **Permit Management** solution. 

2. Create new canvas application

	- Click **+ New** and select **App | Canvas**.
	
	- Select **Tablet Form Factor** from canvas app window.

    ![Create new canvas application - screenshot](../L03/Static/Mod_03_Canvas_App_image3.png)

    If you are creating your first app, this will ask you to set the Country/region for the app. Click **Get Started.**

    ![Get started popup - screenshot](../L03/Static/Mod_03_Canvas_App_image4.png)
        
	- Enter **Inspector** for App Name, select Table format and click **Create**.
	
	- On the Welcome to Power Apps Studio popup, click **Skip**
	
	- Click **File** and select **Save As**.

	- Select **The Cloud**,This will make sure that the changes are not removed if the app closes unexpectedly.

    ![Save application](../L03/Static/Mod_03_Canvas_App_image5.png)

	- Click on the app designer button.

    ![Back to app designer - screenshot](../L03/Static/Mod_03_Canvas_App_image6.png)

3. Rename Screen1.

	- Go to the **Tree View** and double click on **Screen1**.

	- Rename it **Main Screen** and press **Enter.**

    ![Rename screen - screenshot](../L03/Static/Mod_03_Canvas_App_image7.png)

4. Import Component.

**NOTE: Follow the workaround as listed at the beginning of the lab.**

	- Select the **Components** tab.

	- Click on the **… (Component Options)** button and select Import **Components**.

    ![Import components - screenshot](../L03/Static/Mod_03_Canvas_App_image8.png)

	- Click **Upload File**. 

	- Browser to the lab resources folder (F:\temp\Instructions\L03\Resources), select the **Components** file and click **Open**.

    ![Select components to upload - screenshot](../L03/Static/Mod_03_Canvas_App_image9.png)

5. Add the Header component to the MainScreen.

	- Select the **Screens** tab.

	- Click **+** Insert.

    ![Select insert - screenshot](../L03/Static/Mod_03_Canvas_App_image10.png)

	- Click to expand **Library components** and select **Header**.

    ![Select header - screenshot](../L03/Static/Mod_03_Canvas_App_image11.png)

	- Select **Tree View**.

	- Rename **Header_1** to **Main Header** by double click on Header_1.

6. Change the Main Header properties

	- Select **Main Header**.

	- Change the **Text** Column of the **Main Header** to **My Pending Inspections**. This can be done by selecting “Text” property in the dropdown below top menu. Make sure that you have selected the Main Header control while doing this step.

    ![Change text value - screenshot](../L03/Static/Mod_03_Canvas_App_image12.png)

	- Change the **Width** vale of the **Main Header** to the formula below.

            Parent.Width

    ![Change width value - screenshot](../L03/Static/Mod_03_Canvas_App_image13.png)

## Task #2: Add Data Source

1. Add Permit and Inspection as data source.

	- Select the **Data Sources** tab.

    ![Select data sources = screenshot](../L03/Static/Mod_03_Canvas_App_image14.png)

	- Search for **Permit** and select **Permits**.

    ![Select permits - screenshot](../L03/Static/Mod_03_Canvas_App_image15.png)

	- Search for **Inspection** and select **Inspections**.

    ![Select Inspections - screenshot](../L03/Static/Mod_03_Canvas_App_image16.png)

	- You should now have both **Permits** and **Inspections** in your app.

    ![Data sources in your app - screenshot](../L03/Static/Mod_03_Canvas_App_image17.png)

 

## Task #3: Add Inspection Gallery

1. Add Gallery

	- Click **+ Insert** and select **Vertical Gallery**. Vertical Gallery will be added to the MainScreen.

    ![Insert vertical gallery - screenshot ](../L03/Static/Mod_03_Canvas_App_image18.png)

	- Select **Inspections** for **Data Source**. When Inspection is selected, this will automatically pick the Columns and show them in the gallery items.

    ![Select gallery data source - screenshot](../L03/Static/Mod_03_Canvas_App_image19.png)

	- Select the **Tree View** tab.

	- Rename **Gallery_1** to **Inspection List** by double click on Gallery_1.

2. Select the inspector view

	- Make sure you have the **Inspection List** control selected.

	- Go to the **Properties** pane and select **Inspector View** for **View**.

    ![Select view - screenshot](../L03/Static/Mod_03_Canvas_App_image20.png)

3. Change the **Inspection List** control layout

	- Go to the **Properties** pane and click on the **Layout** dropdown.

    ![Gallery layout - screenshot](../L03/Static/Mod_03_Canvas_App_image21.png)

	- Select **Title and Subtitle**.

4. Verify the selected Columns.

	- Go to the **Properties** pane and click on the **Edit Columns**.

    ![Gallery Columns - screenshot](../L03/Static/Mod_03_Canvas_App_image22.png)

	- Confirm that **Scheduled Date** is selected for **Subtitle** and **Name** is selected for **Title**. Close the **Data** pane. 

    ![Edit Column pane - screenshot](../L03/Static/Mod_03_Canvas_App_image23.png)

5. Change date time to date only.

	- Expand the **Inspection List** and select **Subtitle**.

    ![Select subtitle - screenshot](../L03/Static/Mod_03_Canvas_App_image24.png)

	- Change the **Text** property of the control to the formula below.

            DateValue(Text(ThisItem.'Scheduled Date'),"en")

6. Resize the Gallery

	- Select the **Inspection List** gallery.

	- Select **Width** property from the formula dropdown and enter the formula below.

            Parent.Width

	- Select **Height** property and set it to the formula below.

            Parent.Height - ('Main Header'.Height*2)

	- Select the Y property from the dropdown and set it to formula below.

            'Main Header'.Height

	- Select the X property from the dropdown and set it to formula below.

            'Main Header'.X

![Gallery - screenshot](../L03/Static/Mod_03_Canvas_App_image25.png)

 

## Task #4: Add Inspection Details Screen

1. Add new screen named Details Screen

	- Click **New Screen** and select **Blank**.

    ![Add blank screen - screenshot](../L03/Static/Mod_03_Canvas_App_image26.png)

	- Rename the new screen **Details Screen** by double clicking on the control in Tree View.

2. Add Header to the Details Screen and edit it

	- Go to the **Main Screen** and copy the **Main Header**.

    ![Copy component - screenshot](../L03/Static/Mod_03_Canvas_App_image27.png)

	- Go to the **Details Screen** and paste the **Header**.

    ![Paste component - screenshot](../L03/Static/Mod_03_Canvas_App_image28.png)

	- Rename the Header you **Details Header** by double clicking on the control in Tree View.

    ![Rename header - screenshot](../L03/Static/Mod_03_Canvas_App_image29.png)

	- Select te **Y** property of the **Details Header** and set to **0**.

	- Select the **Text** property of the **Details Header** and set it to formula below.

            'Inspection List'.Selected.Name

    ![Change text value - screenshot](../L03/Static/Mod_03_Canvas_App_image30.png)

3. Add Form to the Details Screen.

	- Select the **Details Screen**.

	- Click **+ Insert** and select **Edit Form**.

    ![Edit form - screenshot](../L03/Static/Mod_03_Canvas_App_image31.png)

	- Select the **Tree View** tab.

	- Rename the form **Inspection Form**.

	- Resize the Edit form as:

		- Select the **InspectionForm**.

		- Select **Width** property from the formula dropdown and enter the formula below.

                Parent.Width

	- Select **Height** property and set it to the formula below.

            Parent.Height - ('Details Header'.Height*2)

	- Select the Y property from the dropdown and set it to formula below.

            'Details Header'.Height

- Select the X property from the dropdown and set it to formula below.

        'Details Header'.X

- The form should now look like the image below.

    ![Form - screenshot](../L03/Static/Mod_03_Canvas_App_image32.png)

4. Set the **Inspection Form** data source

	- Select the **Inspection Form** and select the DataSource as **Inspections** Table.

    ![Set form data source - screenshot](../L03/Static/Mod_03_Canvas_App_image33.png)

	- Set the Item value to the formula below.

            'Inspection List'.Selected

    ![Set form item value - screenshot](../L03/Static/Mod_03_Canvas_App_image34.png)

5. Edit Inspection Form Columns. This adds the data cards for Columns by default, but you can add/remove the data cards as:

	- Select the **Inspection Form**.

	- Go to the **Properties** pane and click **Edit Fields**.

    ![Edit form Columns - screenshot](../L03/Static/Mod_03_Canvas_App_image35.png)

	- Click **+ Add Field**.

	- Select **Status Reason**, **Scheduled Date**, **Name** and **Comments**.

	- Click **Add**.

	- The Columns should be ordered as shown in the image below. You can drag/drop to rearrange the Columns.

    ![Form Columns - screenshot](../L03/Static/Mod_03_Canvas_App_image36.png)

6. Change the Scheduled Date to show date only.

	- Go to the **Tree View** and expand the **Inspection Form**.

	- Select the **Scheduled Date** data card.

	- Go to the **Properties** pane and select the **Advanced** tab.

	- Click **Unlock to change Properties**.

    ![Unlock properties - screenshot](../L03/Static/Mod_03_Canvas_App_image37.png)

	- Expand the **Scheduled Date** card.

	- Select **StarVisible**, **ErrorMesage**, **MinuteValue**, **Separator**, and **HourValue**.

    ![Select card components - screenshot](../L03/Static/Mod_03_Canvas_App_image38.png)

	- Delete the selected controls. When the controls are deleted, you will see an error message.

    ![Delete card components - screenshot](../L03/Static/Mod_03_Canvas_App_image39.png)

	- Select the **Scheduled Date** DataCard.

	- Go to formula bar and select **Update**.

    ![Select update property - screenshot](../L03/Static/Mod_03_Canvas_App_image40.png)

	- Remove everything after the **SelectedDate**. This should remove the error message from the app.

    ![Edit formula - screenshot](../L03/Static/Mod_03_Canvas_App_image41.png)

7. Make the Name and Scheduled Date Columns read-only

	- Select the **Inspection Form**.

	- Go to the **Properties** pane and click **Edit Fields**.

	- Expand the **Name** Column.

    ![Expand Column - screenshot](../L03/Static/Mod_03_Canvas_App_image42.png)

	- Click on the **Control Type** dropdown and select **View Text**.

    ![Change control type - screenshot](../L03/Static/Mod_03_Canvas_App_image43.png)

	- Expand the **Scheduled Date** Column. Observe the change.

	- Notice we cannot change this the same way because we’ve customized it. From the Tree View select **DateValue** control inside the **Scheduled Date** Datacard and go to the **Advanced tab** of the **Properties pane**.

    ![Advanced properties - screenshot](../L03/Static/Mod_03_Canvas_App_image44.png)

	- Search for **DisplayMode** property and remove the existing formula and replace it with the following:  


            DisplayMode.View
    
![Display mode - screenshot](../L03/Static/Mod_03_Canvas_App_image45.png)

8. Change the Status Reason label.

	- Select the **Status Reason data card**.

	- Go to the **Properties** pane and the Advanced tab, click **Unlock to Change properties.**

	- Change the **DisplayName** to **Inspection** **Result**.

    ![Change display name - screenshot](../L03/Static/Mod_03_Canvas_App_image46.png)

9. Resize the Comments data card.

	- Select the **Comments** data card.

	- Click and drag the right edge to the far right of the screen.

    ![Change data card width - screenshot](../L03/Static/Mod_03_Canvas_App_image47.png)

	- Go to the **Advanced** tab of **Properties** pane and click **Unlock to change properties**.

	- Set the **Height** value to **300**.

	- Select the **DataCardValue** control.

    ![Select data card - screenshot](../L03/Static/Mod_03_Canvas_App_image48.png)

	- Set the **Height** value to **300**.

	- Change the **Mode** to the formula below.

            TextMode.MultiLine

    ![Change mode - screenshot](../L03/Static/Mod_03_Canvas_App_image49.png)

10. Make sure your form looks like the image below. Save your work.

    ![Form layout - screenshot](../L03/Static/Mod_03_Canvas_App_image50.png)

 

## Task #5: Submit the Inspection Result

1. Add submit button to the details screen.

	- Select the **Details Screen**. Make sure that you have selected the screen and not selected the Edit Form.

	- Go to the **Insert** tab and click **Button**.

    ![Add button - screenshot](../L03/Static/Mod_03_Canvas_App_image51.png)

	- Rename the button **Submit Button**.

	- Change the Text value of the button to **Submit**.

	- Place the button below the form through drag and drop.

    ![Form layout - screenshot](../L03/Static/Mod_03_Canvas_App_image52.png)

2. Submit the inspection result.

	- Select the **Submit Button.**

	- Set the **OnSelect** value of the submit button to the formula below. Remove the false expression and update it. This formula will submit the form and then navigate back to the MainScreen.

    SubmitForm('Inspection Form');Back(ScreenTransition.UnCoverRight)

    ![submit formula - screenshot](../L03/Static/Mod_03_Canvas_App_image53.png)

3. Add navigation from the main screen to the details screen.

	- Go to the **Main Screen** and select the **Inspection List**.

	- Set the **OnSelect** property of the **Inspection List** to the formula below. Remove the already existing false expression.

            Navigate('Details Screen', ScreenTransition.Cover)

 

 

## Task #6: Test Application

1. Start the application

	- Select the **Main Screen** and click **Preview the App**.

    ![Preview application - screenshot](../L03/Static/Mod_03_Canvas_App_image54.png)

	- The application should load and show at least one inspection. Click on the inspection.

    ![Select a record - screenshot](../L03/Static/Mod_03_Canvas_App_image55.png)

	- The application should navigate to the details screen. Change the **Inspection Result** to **Passed**, provide a comment in the textbox as “Framing inspection was completed.”, and click **Submit**.

    ![Submit changes - screenshot](../L03/Static/Mod_03_Canvas_App_image56.png)

	- The inspection should be submitted, and the application should navigate back to the MainScreen. Click Close.

     ![Close preview - screenshot](../L03/Static/Mod_03_Canvas_App_image57.png)

 

2. Save and publish the application

	- Click **File** and then click **Save**.

	- Click **Publish**.

    ![Publish application - screenshot](../L03/Static/Mod_03_Canvas_App_image58.png)

	- Click **Publish this Version**.

	- Click **Close**.

    ![Close button - screenshot](../L03/Static/Mod_03_Canvas_App_image59.png)

	- Close the **Designer** browser window or tab.

	- Click **Leave** if prompted when trying to close the browser window.

 

3. Confirm the inspection record was updated

	- Navigate to [Power Apps maker portal](https://make.powerapps.com/)

	- Select your **Dev environment.**

	- Select **Apps** and click to open the **Permit Management Application**.

    ![Open application - screenshot](../L03/Static/Mod_03_Canvas_App_image60.png)

	- Select **Inspections** and click to open the **Framing Inspection**.

    ![Open record - screenshot](../L03/Static/Mod_03_Canvas_App_image61.png)

	- The **Status Reason** of the inspection should be **Passed,** and the comment should be updated to the comment you provided.

    ![Updated record - screenshot](../L03/Static/Mod_03_Canvas_App_image62.png)

	- Close the **Permit Management** application.

  
‎ 

# Exercise #2: Export/Import Solution

**Objective:** In this exercise, you will export the solution you created in the development environment and import it to the production environment.

## Task #1: Export solution.

1. Select the Permit Management solution.

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) 

	- Make sure you have your **Dev** environment selected.

	- Select **Solutions** and select the **Permit Management** solution.

    ![Select solution - screenshot](../L03/Static/Mod_03_Canvas_App_image63.png)

2. Run solution checker.

	- Click **Solution Checker** and select **Run**.

    ![Run solution checker - screenshot](../L03/Static/Mod_03_Canvas_App_image64.png)

	- Wait for the run to complete.

    **Note:** At the creation of this lab, the solution checker did not complete successfully. If you get an error with the message “Couldn’t be complete” skip to step 3.

    ![Solution checker status - screenshot](../L03/Static/Mod_03_Canvas_App_image65.png)

	- Click on the More **Commands** of the **Permit Management** solution.

    ![More commands - screenshot](../L03/Static/Mod_03_Canvas_App_image66.png)

	- Click Solution Checker and select View Results.

    ![View check result - screenshot](../L03/Static/Mod_03_Canvas_App_image67.png)

- You will see several issues reported

    ![Solution checker results - screenshot](../L03/Static/Mod_03_Canvas_App_image68.png)

- To resolve the issues, follow these steps:

	- Select **Apps**

	- Click … next to **Inspector** app and select **Edit**

	- Click **App checked** icon on the toolbar 

    ![Solution checker icon - screenshot](../L03/Static/Mod_03_Canvas_App_image69.png)

- Select **Recheck All**

- Expand **Missing accessible label** node

- Select an issue. This will open the screen with the control and prompt to enter **AccessibleLabel** property.

- Enter text value as appropriate

    ![Accessibility label - screenshot](../L03/Static/Mod_03_Canvas_App_image70.png)

	- Repeat the process for all controls with missing accessible labels

	- Expand **Missing tab stop** node

	- Select control, enter a value for the **TabIndex**, e.g. 0

	- **Tips** node may contain the following message  
‎“Use another method instead of HTML, or remove the HTML from this element.”

	- This message is related to Map component we imported as part of the component bundle. This component can be safely deleted as it’s not used by the app.

	- Fix other app issues as appropriate.

- Click **File** and then click **Save**.

- Click **Publish**.

- Switch to [Power Apps maker portal](https://make.powerapps.com/) 

- Select **Solutions** then select **Permit Management** solution 

- Click **Solution checker** then select **Run** and wait for the run to complete.

- There should be zero issues.

    ![Solution checker with zero issues result - screenshot](../L03/Static/Mod_03_Canvas_App_image71.png)

3. Export managed solution

	- Select **Solutions** and click to open the **Permit Management** solution.

	- Click **Export**.

    ![Export solution - screenshot](../L03/Static/Mod_03_Canvas_App_image72.png)

	- Click **Publish** and wait for the publishing to complete.

    ![Publish solution - screenshot](../L03/Static/Mod_03_Canvas_App_image73.png)

	- Click **Next**.

	- Select **Managed** and click **Export**.

    ![Export solution - screenshot](../L03/Static/Mod_03_Canvas_App_image74.png)

	- Save the solution on your machine.

4. Export unmanaged solution

	- Click **Export** again.

	- Click **Next**.

	- Edit the version number to match the Managed solution you just exported, select **Unmanaged** and click **Export**.  
‎

    ![Export unmanaged solution - screenshot](../L03/Static/Mod_03_Canvas_App_image75.png)

	- Save the unmanaged solution on your machine.

 

## Task #2: Import solution.

1. Open the Permit Management solution.

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) 

	- Make sure you have your **Prod** environment selected.
    **Note** If you are using the community plan environment as instructed (e.g: [username]'s Environment), you may need to create a data base before you proceed to the next step.

2. Import solution

	- Select **Solutions** and click **Import**.

    ![Import solution - screenshot](../L03/Static/Mod_03_Canvas_App_image76.png)

	- Click **Browse**.

	- Select the **Managed** solution you exported and click **Open**.

    ![Select solution file - screenshot](../L03/Static/Mod_03_Canvas_App_image77.png)

	- Click **Next**.

	- Click **Import** and this will open a new window to track the import status.

	- Wait for import to complete and click **Close**.

	- Navigate to both the model driven and canvas apps you’ve created and add a few records, test the apps.

 

 

 

 

 
