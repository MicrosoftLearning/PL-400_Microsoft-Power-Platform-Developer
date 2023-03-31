---
lab:
    title: 'Lab 04: Client Scripting'
---


## Lab 04 – Client Scripting

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course, you will build applications and automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

In this lab, you will implement client-side logic that will use the web API to evaluate the permit type associated with the permit record and use the client scripting API to manipulate the form controls. 

You will also customize the command bar to introduce a new lock permit button that will invoke a custom API to perform the lock permit logic. The server-side logic for the lock permit custom API will be implemented later in the course. Right now, you will just add the button and the logic to invoke the custom API.

## High-level lab steps

As part of building the client-side logic, you will complete the following:

- Setup a folder to contain your client script

- Upload and register the client script on the form

- Build logic to use the web API to retrieve the permit type record associated with the permit

- Build logic based on the permit type settings to hide and show the inspections tab on the form

- Build logic to set columns as required/not required based on the permit type settings

- Modify the command bar

- Build logic to invoke the lock permit custom API when the command bar button is selected

## Things to consider before you begin

- Are there alternative designs that would be viable and not require code?

- Remember to continue working in your DEVELOPMENT environment. We will move everything to production soon.

  
‎ 

# Exercise #1: Prepare and Load Resources

**Objective:** In this exercise, you will create, organize, and load your JavaScript web resources.

## Task #1: Use Visual Studio Code to Create Resources

In this task, you will set up a folder to contain the JavaScript web resource files in this course. 

1. If you do not already have Visual Studio Code, download it from here [Visual Studio Code](https://code.visualstudio.com/docs/?dv=win) and install it.

2. Start **Visual Studio Code**. 

3. Create resources

	- Select Explorer from left menu or press Ctrl + Shift + E.

    ![Select Explorer - screenshot](../L04/Static/mod-01-client-scripting-01.png)

	- Select **Open Folder**.

	- Create a new folder and name it **ContosoClientScripts**.
  
  	**Note:** This is the name and structure used for this lab, the platform does not require a specific structure or content organization. Many projects check these assets into a source control system to keep track of all the changes over the life of the client script.

	- Select the new folder you just created and select **Select Folder**.

    ![Select folder - screenshot](../L04/Static/mod-01-client-scripting-02.png)

4. Create **Form Scripts** folder

	- Hover over the folder and select **New Folder**.

    ![New folder - screenshot](../L04/Static/mod-01-client-scripting-03.png)

	- Name the new folder as **FormScripts** and **Enter**.

    ![Form scripts folder - screenshot](../L04/Static/mod-01-client-scripting-04.png)

5. Create the **Permit Form Functions** file

	- Right click on the **FormScripts** folder and select **New File**.

    ![New file - screenshot](../L04/Static/mod-01-client-scripting-05.png)


	- Name the new file as **PermitFormFuntions.js** and **Enter**.


    ![permit form functions JavaScript file - screenshot](../L04/Static/mod-01-client-scripting-06.png)

	- Add the below mentioned namespaces to the newly created **PermitFormFunctions** file.

            if (typeof (ContosoPermit) == "undefined")
            {var ContosoPermit = {__namespace: true};}
            if (typeof (ContosoPermit.Scripts) == "undefined")
            {ContosoPermit.Scripts = {__namespace: true};}

     ![Namespaces - screenshot](../L04/Static/mod-01-client-scripting-07.png)

    - Add the function mentioned below after adding the namespaces.

            ContosoPermit.Scripts.PermitForm = {
            __namespace: true
            }

    ![Add function - screenshot](../L04/Static/mod-01-client-scripting-08.png)  
‎

## Task #2: Add Event Handlers

In this task, you will create functions for the logic that you will be implementing. This will allow you to register the event handlers in the next tasks for calling these functions and performing few basic tests in the upcoming tasks.

1. Add a function to OnLoad event

	- Add the function mentioned below to the **PermitFormFuntions** file inside the function created in Step 1(d).

            handleOnLoad: function (executionContext) {
        console.log('on load - permit form');
    },

    ![handle on load event - screenshot](../L04/Static/mod-01-client-scripting-09.png)

2. Add a function to OnChange permit type event

	- Add the function mentioned below to the **PermitFormFuntions** file inside the function created in Step 1(d). Once this is done, select **File** and **Save All**.

            handleOnChangePermitType: function (executionContext) {
        console.log('on change - permit type');
    },

    ![Handle on change permit type - screenshot](../L04/Static/mod-01-client-scripting-10.png)

 

## Task #3: Load Web Resources 

In this task, you will upload the JavaScript files as web resources.You will also edit the Permit table main form and associate the new web resource with its form. Finally, you will register your functions to be called on specific form events.

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/).

	- Select your **Dev** environment.

	- Select **Solutions**.

	- Open the **Permit Management** solution.

2. Add web resource to the solution

	- Select **+ New**.

	- Select **More | Web Resources**.

    ![Add web resource - screenshot](../L04/Static/mod-01-client-scripting-12.png)

	- Enter **Permit Form Scripts** for **Display name**.

	- Enter **PermitFormScripts.js** for **Name**.

	- Select **JavaScript (JS)** for **Type**.

	- Select **Upload file**.

    ![New web resource form - screenshot](../L04/Static/mod-01-client-scripting-13.png)

	- Select the **PermitFormFunctions.js** file and select **Open**.

    ![Select file - screenshot](../L04/Static/mod-01-client-scripting-14.png)

	- Select **Save** and wait until the changes are saved.

	- Select **Publish all customizations** and wait for the publishing to complete.


3. Open the Permit main form.

	- Make sure you are still in the solution.

	- Open the **Permit** table.

	- Select the **Forms** tab and open the **Main** form.

4. Add the script to the permit form

	- Go to the **Properties** pane and select the **Events** tab.

    ![Form properties - screenshot](../L04/Static/mod-01-client-scripting-16.png)

	- Select **+ Add library**.

	- Search for **contoso**, select **Permit Form Scripts** and select **Add**.

    ![Add script file - screenshot](../L04/Static/mod-01-client-scripting-18.png)

5. Add OnLoad event handler.

	- Expand the **OnLoad** section and select **+ Event Handler**.

    ![Add event - screenshot](../L04/Static/mod-01-client-scripting-19.png)

	- Select **Contoso_****PermitFormScripts.js** in the dropdown for **Library**.

	- Enter **ContosoPermit.Scripts.PermitForm.handleOnLoad** in the textbox for **Function**.

	- Check the **Pass execution context as first parameter** checkbox.

	- Select **Done**.

    ![Event details - screenshot](../L04/Static/mod-01-client-scripting-20.png)



6. Add Permit Type OnChange event handler.

	- Select **Permit Type** field on the form.

    ![Permit type field - screenshot](../L04/Static/mod-01-client-scripting-15.png)

	- Go to the **Properties** pane and select the **Events** tab.
  
	- Expend the On Change section and select **+ Event Handler**

    ![Add event - screenshot](../L04/Static/mod-01-client-scripting-21.png)

	- Select **Contoso_****PermitFormScripts****.js** for **Library**.

	- Enter **ContosoPermit.Scripts.PermitForm.handleOnChangePermitType** in the textbox for **Function**.

	- Check the **Pass execution context as first parameter** checkbox.

	- Select **Done**.

    ![Event details - screenshot](../L04/Static/mod-01-client-scripting-22.png)

7. Save and publish your changes

	- Select **Save** and wait for changes to be saved.

	- Select **Publish** and wait for the publishing to complete.

	- Go back to the Permit table by selecting on the **<- Back** button.

     ![Back to table - screenshot](../L04/Static/mod-01-client-scripting-24.png)

	- Go back to the main maker portal by selecting the **<-** back button again.
  
	- Select **Publish all customizations** and wait for the publishing to complete.

**DO NOT** navigate away from this page


## Task #4: Test Event Handlers 

In this task, you will test the event handlers.

1. Start the Permit Management application

	- Select **Apps**.

	- Launch the **Permit Management** application.

    ![Start application - screenshot](../L04/Static/mod-01-client-scripting-27.png)

2. Open a Permit record

	- Select **Permits** from the Site Map.

	- Select to open a permit record.

    ![Open record - screenshot](../L04/Static/mod-01-client-scripting-28.png)

3. Open Edge Dev Tools

	- Press **F12** or right click and select **Inspect**.

	- Select the **Console** from top menu and clear console.

    ![Clear console - screenshot](../L04/Static/mod-01-client-scripting-29.png)

4. Refresh and confirm the OnLoad event handler function runs

	- Go to the **Permit** record and select **Refresh**.

	- Go to the **Dev Tools** and you should now be able to see the **on load – permit form** message.

    ![On load event message - screenshot](../L04/Static/mod-01-client-scripting-31.png)

5. Remove Permit Type and confirm the OnChange Permit Type event handler function runs

	- Go to the **Permit** record and remove the **Permit Type**.

    ![Remove permit type - screenshot](../L04/Static/mod-01-client-scripting-32.png)

	- Go to the **Dev Tools** and you should now be able to see the **on change – permit type** message.

    ![On change permit message - screenshot](../L04/Static/mod-01-client-scripting-33.png)

	- Close the **Dev Tools**.

  
‎ 

# Exercise #2: Show and Hide Tabs

**Objective:** In this exercise, you will create a script that will show and hide the inspections tab based on the permit type table’s “required inspections” column value.

## Task #1: Create Function   

1. Create a function that will run when the Permit form loads and when the Permit Type value changes

	- Go back to **Visual Studio Code**.

	- Add the function mentioned below to **PermitFormFuntions** inside the PermitForm function.

            _handlePermitTypeSettings: function (executionContext) {

            },

    ![handle permit type settings function - screenshot](../L04/Static/mod-01-client-scripting-34.png)

2. Get form context from the execution context

	- Add the script mentioned below inside _**handlePermitTypeSettings** function.

            var formContext = executionContext.getFormContext(); 

3. Get the Permit Type value from the form.

	- Add the script mentioned below inside the _**handlePermitTypeSettings** function. contoso_permittype is the logical name of the Permit Type column. You can verify this in the table metadata.

            var permitType = formContext.getAttribute("contoso_permittype").getValue();

4. Check if the Permit Type has value.

	- Add the script mentioned below inside the _**handlePermitTypeSettings** function.

            if (permitType == null) {

            } else {
            
            }

    ![Handle permit type settings function - screenshot](../L04/Static/mod-01-client-scripting-35.png)

5. Hide the Inspections tab and return if Permit type is null.

	- Add the script mentioned below inside the _**handlePermitTypeSettings** function. inspectionsTab is the name of the Inspections tab (This is configured while creating the Model Driven App in a previous lab in this course).

            formContext.ui.tabs.get("inspectionsTab").setVisible(false);
            return;

    ![Handle permit type settings function progress - screenshot](../L04/Static/mod-01-client-scripting-36.png)

 

## Task #2: Get Inspection Type Record   

In this task, you will use the web API to retrieve the permit type lookup record associated with the current permit record that is currently displayed in the form.

1. Get the Permit Type ID

	- Add the script mentioned below in the else statement of the _**handlePermitTypeSettings** function.

            var permitTypeID = permitType[0].id;

2. Retrieve the Permit Type record and show alert if there are errors

	- Add the script mentioned below in the else statement of the _**handlePermitTypeSettings** function. contoso_pertmittype is the logical name of the Permit Type table.

            Xrm.WebApi.retrieveRecord("contoso_permittype", permitTypeID).then(function (result) {
            },

            function (error) { alert('Error:' + error.message) });

    ![Handle permit type settings function progress - screenshot](../L04/Static/mod-01-client-scripting-37.png)

3. Check if “**Require Inspections**” column value is true

	- Add the script mentioned below in the **retrieveRecord** function call. contoso_requireinspections is the logical name of the Require Inspections column of the Permit Type table.

            if (result.contoso_requireinspections) {

            } else {

            }

4. Make the Inspections tab visible if Require Inspections is true

	- Add the script mentioned below in the if statement of the **retrieveRecord** call. 

            formContext.ui.tabs.get("inspectionsTab").setVisible(true);

5. Hide the Inspections tab if Require Inspections is not true

	- Add the script mentioned below in the else statement of the **retrieveRecord** call. 

            formContext.ui.tabs.get("inspectionsTab").setVisible(false);

    ![Handle permit type settings function progress - screenshot](../L04/Static/mod-01-client-scripting-38.png)

6. Call the _handlePermitTypeSettings function from the handleOnLoad function.

	- Go to the **handleOnLoad** function and add the script mentioned below.

            ContosoPermit.Scripts.PermitForm._handlePermitTypeSettings(executionContext);

7. Call the _handlePermitTypeSettings function from the handleOnChangePermitType function.

	- Go to the **handleOnChangePertmitType** function and add the script mentioned below.

            ContosoPermit.Scripts.PermitForm._handlePermitTypeSettings(executionContext);

    ![handle on load and handle in change functions - screenshot](../L04/Static/mod-01-client-scripting-39.png)

    - Select **File** and **Save All**.

## Task #3: Load Updated Script    

1. Open the Permit Form Script web resource.

	- Navigate to [Power Apps maker portal](https://make.powerapps.com/).

	- Select your **Dev** environment.

	- Select **Solutions**.

	- Open the **Permit Management** solution.

	- Select **Web resources** and open the **Permit Form Script** web resource.

    ![Open web resource - screenshot](../L04/Static/mod-01-client-scripting-41.png)

2. Load the updated version of permitFormFuntion.jsPermitFormFuntion.js

	- Select **Upload file**.

    ![Choose file - screenshot](../L04/Static/mod-01-client-scripting-42.png)

	- Select **PermitFormFunctions.js** and select **Open**.

3. Save and Publish your changes

	- Select **Save** and wait until the changes are saved.

	- Select **Publish** and wait for the publishing to complete.
  
	- Select the **<-** back button to go back to the main maker portal.
  
	- Do not navigate away from this page.



## Task #4: Test Your Changes    

1. Start the Permit Management application

	- Select **Apps**.

	- Launch the **Permit Management** application.

2. Open Permit record.

	- Select Permits from the Site Map.

	- Select to open a **Permit** record.

3. Check if the **Permit Type** column is empty and if it is, the **Inspections** tab is hidden. In this case, the Permit Type is null.

    ![Pert type column null - screenshot](../L04/Static/mod-01-client-scripting-46.png)

4. Select Permit Type.

	- Select the **Permit Type** lookup.

	- Select **New Construction**.

	- Check if the **Inspections** tab is still hidden. If so, in this case, the Require Inspections column value is false/No

    ![Pert type new construction with no inspection requirement - screenshot](../L04/Static/mod-01-client-scripting-47.png)

5. Set **Require Inspections** column value of the **Permit Type** to **Yes**.

	- Open the selected **Permit Type**.

    ![Open permit type - screenshot](../L04/Static/mod-01-client-scripting-48.png)

	- Set the **Require Inspections** to **Yes**.

    ![Change inspection requirement - screenshot](../L04/Static/mod-01-client-scripting-49.png)

	- Select **Save**.

	- Select the **<-** back button.

6. You should now be able to see the Inspections tab.

	- Select the **Inspections** tab.

    ![Select inspection tab - screenshot](../L04/Static/mod-01-client-scripting-50.png)

	- The user should now be able to view/add inspections to the sub-grid.

    ![Inspections sub-grid - screenshot](../L04/Static/mod-01-client-scripting-51.png)

 

# Exercise #3: Toggle required property on the columns

**Objective:** In this exercise, you will create a script that will make the “New Size” column required when the “Require Size” column value is set to Yes. If the “Require Size” column value is set to No, remove the requirement. You will also hide the “New Size” column. This logic will be driven by a column on the permit type record that was retrieved using web API in the previous exercise.

## Task #1: Create Function

1. Locate the _handlePermitTypeSettings function

	- Go back to **Visual Studio Code**.

	- Locate the _**handlePermitTypeSettings** function.

2. If permitType is null, remove the requirement and hide the “New Size” column. 

	- Add the script below in the **if** **permitType == null** statement. contoso_newsize is the logical name of the New Size column.

            formContext.getAttribute("contoso_newsize").setRequiredLevel("none");

            formContext.ui.controls.get("contoso_newsize").setVisible(false);

    ![Remove requirement script - screenshot](../L04/Static/mod-01-client-scripting-52.png)

3. Check if “Require Size” column value of the Permit Type is set to Yes

	- Add the script mentioned below inside the retrieveRecord function.

            if (result.contoso_requiresize) {

            } else {

            }

    ![Check requirement script - screenshot](../L04/Static/mod-01-client-scripting-53.png)

4. If “Require Size” column value of the Permit Type is set to Yes, make the “New Size” column visible and required.

	- Add the script mentioned below in the **if** **result.contoso_requiresize** statement. contoso_requiresize is the logical name of the Require Size column.

            formContext.ui.controls.get("contoso_newsize").setVisible(true);

            formContext.getAttribute("contoso_newsize").setRequiredLevel("required");

    ![Show column and make it required script - screenshot](../L04/Static/mod-01-client-scripting-54.png)

5. If Require Size column value of the Permit Type is not set to Yes, make the “New Size” column not required and hide it.

	- Add the script mentioned below inside the else statement.

            formContext.getAttribute("contoso_newsize").setRequiredLevel("none");

            formContext.ui.controls.get("contoso_newsize").setVisible(false);

    ![Remove requirement and hide column script - screenshot](../L04/Static/mod-01-client-scripting-55.png)

6. The _handlePermitTypeSettings function should now look like the image below.

    ![Completed handle permit type settings function - screenshot](../L04/Static/mod-01-client-scripting-56.png)

7. Select **File** and then **Save All**.

## Task #2: Load Updated Script    

1. Update the Permit Form Script web resource.

	- Go to the maker portal and select **Solutions**.

	- Open the **Permit Management** solution.
  
	- Select **Web resources** and open the **Permit Form Scripts** web resource.

	- Select **Upload File**.

	- Select the **PermitFormFunctions.js** you updated and then select **Open**.

2. Save and Publish your changes

	- Select **Save** and wait until the changes are saved.

	- Select **Publish** and wait for the publishing to complete.

	- Select the **<-** back button.
  
3. Do not navigate away from this page.

## Task #3: Test Your Changes    

1. Start the Permit Management application

	- Select **Apps**.

	- Launch the **Permit Management** application.

2. Open Permit record.

	- Select Permits.

	- Select to open a **Permit** record.

3. Check if the **New Size** column is hidden. If so, then it is because the “Require Size” column of the Permit Type is set to NO.

    ![Hidden column - screenshot](../L04/Static/mod-01-client-scripting-60.png)

4. Set **Require Size** column value of the **Permit Type** to **Yes**.

	- Open the **Permit Type**.

    ![Open permit type - screenshot](../L04/Static/mod-01-client-scripting-61.png)

	- Set the **Require Size** to **Yes**.

    ![Change require size to yes - screenshot](../L04/Static/mod-01-client-scripting-62.png)

	- Select **Save** on the bottom right of the screen.

	- Select the **<-** back button.

5. Check if the “New Size” column is visible and it is marked as required.

	- You should now be able to see **New Size”** column on the form and it is a required field.

    ![Required column- screenshot](../L04/Static/mod-01-client-scripting-63.png)

	- Remove **Permit Type**.

    ![Remove permit type - screenshot](../L04/Static/mod-01-client-scripting-64.png)

	- Check if both the **Inspections** tab and **New Size** column are now hidden. They should be removed as soon as the “Permit Type” is removed.

    ![Removed tab and size column - screenshot](../L04/Static/mod-01-client-scripting-65.png)

 
# Exercise #4: Command Button Function

**Objective:** In this exercise, you will you will create custom API, create a function that will lock permits, add a button to the permit table and call the lock permit function when the button is selected.


## Task #1: Create Custom API

In this task, you will create a custom API that will be called to lock the permit. You will not be implementing the business logic that will lock the permit in this lab. It will be completed later in the class when you build the plug-in that registers on the custom api you are defining here.

1. Open the Permit Management Solution.

	- Navigate to [Power Apps makes portal](https://make.powerapps.com/) and make sure you have the **Dev** environment selected.

	- Select **Solutions** and open the **Permit Management** solution.
  
2. Create new custom API

	- Select **+ New** and then select **More | Other | Custom API**.

    ![Create new process - screenshot](../L04/Static/mod-01-client-scripting-76.png)

	- Enter **contoso_LockPermit** for Unique name, enter **Lock Permit** for Name, **Lock Permit** for Display name, enter **Lock Permit** for Description, select **Entity** for Binding type, enter **contoso_permit** for Bound entity logical name, and select **Save and Close**.

    ![New process form - screenshot](../L04/Static/mod-01-client-scripting-77.png)
  
    - Select **Done**
  
3. Create custom API request parameter

	- Select **+ New** and then select **More | Other | Custom API Request Parameter**.

    ![Add process argument - screenshot](../L04/Static/mod-01-client-scripting-78.png)

	- Select **Lock Permit** for Custom API, enter **Reason** for Unique name, enter **Reason** for Name, enter **Reason** Display name, **Reason** for Description, select **String** for Type, and select **Save and Close**.

    ![Add string input argument - screenshot](../L04/Static/mod-01-client-scripting-79.png)

	- Select **Done**

4. Create Custom API Response Property 

	> **NOTE:** Previously the 'Custom API Response Property' was called 'Custom API response parameter'.

	- Select **+ New** and then select **More | Other | Custom API Response Property**.

	- Select **Lock Permit** for Custom API, enter **CanceledInspectionsCount** for Unique name, enter **Canceled Inspections Count** for Name, enter **Canceled Inspections Count** Display name, **Canceled Inspections Count** for Description, select **Integer** for Type. set **Yes** for Is Optional, and select **Save and Close**.

    ![Process arguments - screenshot](../L04/Static/mod-01-client-scripting-80.png)

    - Select **Done**

5. Publish your changes

	- Select **Publish all customizations** and wait for the publishing to complete.
 

## Task #2: Create the Function

In this task, you will create the logic to invoke that will call the custom API.

1. Start Visual Studio Code and open the resources you create in Exercise One

	- Start **Visual Studio Code**.

	- Select **File** and select **Open Folder**.

	- Select the **ContosoClientScripts** folder you created in exercise one and select **Select Folder**.

    ![Select folder - screenshot](../L04/Static/mod-01-client-scripting-84.png)

2. Add a function that will build the request

	- Open the **PermitFormFunctions.js** file.

    ![Permit dorm function file - screenshot](../L04/Static/mod-01-client-scripting-85.png)

	- Add the function below after the _handlePermitTypeSettings function.

            _lockPermitRequest : function (permitID, reason) {

            },

    ![Add lock permit request function - screenshot](../L04/Static/mod-01-client-scripting-86.png)

3. Build entity and set reason.

	- Add the script mentioned below inside the **_lockPermitRequest** function.

            this.entity = { entityType: "contoso_permit", id: permitID };

            this.Reason = reason;

4. Build and return the request

	- Add the script mentioned below in the **_lockPermitRequest** function.

            this.getMetadata = function () {
                return {
                    boundParameter: "entity", parameterTypes: {
                        "entity": {
                            typeName: "mscrm.contoso_permit",
                            structuralProperty: 5
                        },
                        "Reason": {
                            "typeName": "Edm.String",
                            "structuralProperty": 1 // Primitive Type
                        }
                    },
                    operationType: 0, // This is an action. Use '1' for functions and '2' for CRUD
                    operationName: "contoso_LockPermit",
                };
            };

    ![Add lock permit request function progress- screenshot](../L04/Static/mod-01-client-scripting-87.png)

5. Add the function that will be called from the action button.

	- Add the function mentioned below after the **_lockPermitRequest** function.

            lockPermit: function (primaryControl) {

            },

    ![Lock permit function - screenshot](../L04/Static/mod-01-client-scripting-88.png)

6. Get Permit ID and call **_lockPermitRequest**

	- Get the id by adding the script mentioned below inside the **lockPermit** function.

            formContext = primaryControl;
            var PermitID = formContext.data.entity.getId().replace('{', '').replace('}', '');

	- Call **_lockPermitRequest**. We are hard-coding the reason “Admin Lock”

            var lockPermitRequest = new ContosoPermit.Scripts.PermitForm._lockPermitRequest(PermitID, "Admin Lock");

7. Execute the request.

	- Add the script mentioned below inside the lockPermit function.

            // Use the request object to execute the function
                Xrm.WebApi.online.execute(lockPermitRequest).then(
                    function (result) {
                        if (result.ok) {
                            console.log("Status: %s %s", result.status, result.statusText);
                            // perform other operations as required;
                            formContext.ui.setFormNotification("Status " + result.status, "INFORMATION");
                        }
                    },
                    function (error) {
                        console.log(error.message);
                        // handle error conditions
                    }
                );


    ![Lock permit function screenshot](../L04/Static/mod-01-client-scripting-89.png)

	- Select **File** and then **Save All**.

8. Load the update resource and publish.

	- Log on to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Dev** environment selected.

	- Select **Solutions** and open the **Permit Management** solution.

	- Select **Web resources** and open the **Permit Form Scripts** web resource.

	- Select **Upload File**.

	- Select the **PermitFormFunctions.js** you updated and select **Open**.

	- Select **Save** and wait until the changes are saved.

	- Select **Publish** and wait for the publishing to complete.


## Task #3: Add Button to Ribbon

1. Open the Permit Management application for edit 

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Dev** environment selected.

	- Select **Solutions** and select to open the **Permit Management** solution.

	- Select **Apps** and select the **Permit Management** application.
  ![Select application - screenshot](../L04/Static/mod-01-client-scripting-92.png)

	- Select the chevron button next to the **Edit** button and select **Edit in preview**.
  ![Edit application - screenshot](../L04/Static/mod-01-client-scripting-93.png)

2. Edit the Permit table command bar.

	- Select the **Pages** tab, Hover over the **Permit** table and select the **...** button.
  ![Select permit management solution - screenshot](../L04/Static/mod-01-client-scripting-94.png)

	- Select **Edit command bar**.
  ![Adit command bar - screenshot](../L04/Static/mod-01-client-scripting-95.png)

    - Select **Main form** and then select **Edit**.

3. Add command to permit table

	- Select **+ New command**.

    ![Add command - screenshot](../L04/Static/mod-01-client-scripting-96.png)

	- Select **JavaScript** and then select **Continue**.

4. Configure command bar button

	- Enter **Lock Permit** for Label, Select **Use Icon**, select **Lock** for Icon, and enter **Lock Permit** for Tooltip, 

    ![Command properties- screenshot](../L04/Static/mod-01-client-scripting-97.png)

	- Scroll down and select **+ Add library**

    ![Add library - screenshot](../L04/Static/mod-01-client-scripting-98.png)

	- Search for **contoso**, select **Permit Form Scripts**, and then select **Add**.

    ![Select library - screenshot](../L04/Static/mod-01-client-scripting-99.png)

	- Enter **ContosoPermit.Scripts.PermitForm.lockPermit** in the textbox for **Function Name**.

    ![Function name - screenshot](../L04/Static/mod-01-client-scripting-100.png)

5. Add parameter

	- Select **+ Add Parameter** .

    ![Add parameter - screenshot](../L04/Static/mod-01-client-scripting-101.png)

	- Select **PrimaryControl** for Parameter 1.

    ![Select primary control as parameter - screenshot](../L04/Static/mod-01-client-scripting-102.png)

6. Publish your changes.
    - Select **Save and Publish**.

 

## Task #5: Test Command Button

1. Start the Permit Management application.

	- Log on to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have your **Dev** environment selected.

	- Select **Apps** and launch the **Permit Management** application.

2. Open a permit record

	- Select** Permits**.

	- Select to open a permit.

	- You should be able to see the button you just added.

    ![Lock permit button - screenshot](../L04/Static/mod-01-client-scripting-107.png)

3. Test the Command

	- Select the **Lock Permit** button.

	- The script should trigger the action and you should be able to see the Status 200 notification.

    ![Status notification - screenshot](../L04/Static/mod-01-client-scripting-108.png)
