---
lab:
    title: 'Lab 08: Publishing Events Externally'
---

> [!NOTE]
> Effective November 2020:
> - Common Data Service has been renamed to Microsoft Dataverse. [Learn more](https://aka.ms/PAuAppBlog)
> - Some terminology in Microsoft Dataverse has been updated. For example, *entity* is now *table* and *field* is now *column*. [Learn more](https://go.microsoft.com/fwlink/?linkid=2147247)
>
> This content be updated soon to reflect the latest terminology.


## Lab 08 – Publishing Events Externally

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course you will build applications and automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

In this lab you will use the event publishing capability of the Common Data Service. When a permit results in changing the size of the build site, an external taxing authority needs to be notified so they can evaluate if additional taxing is required. You will configure Common Data Service to publish permits with size changes using the web hook option. To simulate the taxing authority receiving the information you will create a simple Azure function to receive the post. 

# High-level lab steps

As part of configuring the event publishing, you will complete the following:

- Create an Azure Function to receive the web hook post

- Configure Common Data Service to publish events using a web hook

- Test publishing of events

## Things to consider before you begin

- Do we know what events will trigger our web hook?

- Could what we are doing with the web hook, be done using Power Automate?

- Remember to continue working in your DEVELOPMENT environment. We’ll move everything to production soon.

  
‎ 

# Exercise #1: Create an Azure Function

**Objective:** In this exercise, you will create an Azure Function that will be the endpoint to accept and log incoming web requests.

 

## Task #1: Create Azure Function App

1. Create new function application

	- Sign in to [Azure portal](Azure%20portal) and login.

	- Click **Show portal menu** and select + **Create a Resource**.

    ![Create new resource - screenshot](../L08/Static/Mod_01_Web_Hook_image1.png)

	- Search for Function App and select it.

    ![New function app - screenshot](../L08/Static/Mod_01_Web_Hook_image2.png)

	- Click **Create**.

    ![Create function app - screenshot](../L08/Static/Mod_01_Web_Hook_image3.png)

	- Enter your initials plus today’s date for **App Name**, select your **Subscription**, select **Create New** for **Resource Group**, select **.NET Core** for Runtime Stack, select location in the same region as **CDS**, and click **Review + Create**.

    ![Review/create function app - screenshot](../L08/Static/Mod_01_Web_Hook_image4.png)

	- Click **Create** and wait for the deployment to complete.

## Task #2: Create an Azure Function

1. Create a new function

	- Click **Go to resource**.

    ![Go to resource - screenshot](../L08/Static/Mod_01_Web_Hook_image5.png)

	- Select **Functions** and click **+ Add**.

    ![Add function - screenshot](../L08/Static/Mod_01_Web_Hook_image6.png)

	- Select **HTTP trigger**.

    ![HTTP trigger - screenshot](../L08/Static/Mod_01_Web_Hook_image7.png)

	- Click **Create Function** and wait for the function to be created.

2. Test the function

	- Select **Code + Test**.

    ![Code + Test - screenshot](../L08/Static/Mod_01_Web_Hook_image8.png)

	- Click **Test**/**Run**.

    ![Test/run - screenshot](../L08/Static/Mod_01_Web_Hook_image9.png)

	- Click **Run**.

	- You should see **Hello, Azure** in the output.

    ![Function output - screenshot](../L08/Static/Mod_01_Web_Hook_image10.png)

	- Close the test pane.

 

3. Edit the function

	- Replace the Run method with the method below.

            public static async void Run(HttpRequest req, ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                string indentedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                log.LogInformation(indentedJson);
            }

	- Save your changes.

    ![Save function - screenshot](../L08/Static/Mod_01_Web_Hook_image11.png)

4. Remove HTTP output

	- Select **Integration**.

    ![Integration - screenshot](../L08/Static/Mod_01_Web_Hook_image12.png)

	- Select the **HTTP Output**.

    ![Outputs - screenshot](../L08/Static/Mod_01_Web_Hook_image13.png)

	- Click **Delete**.

    ![Delete output - screenshot](../L08/Static/Mod_01_Web_Hook_image14.png)

	- Click **OK**.

5. Get the function URL

	- Select **Overview** and click **Get Function URL**.

    ![Get function URL - screenshot](../L08/Static/Mod_01_Web_Hook_image15.png)

	- Click **Copy** and click OK to close the popup.

    ![Copy function URL - screenshot](../L08/Static/Mod_01_Web_Hook_image16.png)

	- Save the **URL**, you will need it in the next exercise.

# Exercise #2: Configure Web Hook

## Task #1: Configure publishing to a web hook

1. Download the SDK Toolkit. If you already have the Plugin Registration tool from the previous lab you can proceed to step three of this task.

	- Navigate to [https://xrm.tools/SDK](https://xrm.tools/SDK) 

	- Click **Download SDK Zip File**.

    ![Download SDK - screenshot](../L08/Static/Mod_01_Web_Hook_image17.png)

	- Save the zip file on your machine.

	- Right click on the downloaded **sdk.zip** file and select **Properties**.

    ![File properties - screenshot](../L08/Static/Mod_01_Web_Hook_image18.png)

	- Check the **Unblock** checkbox and click Apply.

    ![Unblock file - screenshot](../L08/Static/Mod_01_Web_Hook_image19.png)

	- Click **OK**.

	- Right click on the **sdk.zip** file again and select **Extract All**.

	- Complete extracting.

2. Start the Plugin Registration Tool

	- Open the **sdk** folder you extracted and click to open the **PluginRegistration** folder.

    ![Plugin registration - screenshot](../L08/Static/Mod_01_Web_Hook_image20.png)

	- Locate and double click PluginRegistration.exe.

    ![Start plugin registration tool - screenshot ](../L08/Static/Mod_01_Web_Hook_image21.png)

3. Create new connection

	- Click **Create New Connection**.

    ![New connection - screenshot ](../L08/Static/Mod_01_Web_Hook_image22.png)

	- Select **Office 365** and check the **Display List of available organization** and **Show Advanced** checkboxes. Select **Online Region** where your organization is located. If you are unsure what region to select, select **Don’t Know**.

	- Provide your **CDS** credentials and click **Login**.  
‎    ![Login - screenshot](../L08/Static/Mod_01_Web_Hook_image23.png)

	- Select the **Dev** environment and click **Login**.

    ![Select environment - screenshot](../L08/Static/Mod_01_Web_Hook_image24.png)

4. Register new Web Hook

	- Click **Register** and select **Register New Web Hook**.

    ![Register new web hook - screenshot](../L08/Static/Mod_01_Web_Hook_image25.png)

	- Enter **NewSize** for **Name**.

	- Go to the notepad where you saved the function URL and copy everything before the **‘?’**.

    ![Copy URL - screenshot](../L08/Static/Mod_01_Web_Hook_image26.png)

	- Go back to the **Plugin Registration** tool and paste the **URL** you copied in the **Endpoint URL** field.

    ![Paste URL - screenshot ](../L08/Static/Mod_01_Web_Hook_image27.png)

	- Select **WebhookKey** for **Authentication**.

	- Go back to the notepad and copy the key.

    ![Copy key - screenshot](../L08/Static/Mod_01_Web_Hook_image28.png)

	- Go back to the **Plugin Registration** tool, paste the key you copied in the **Value** field and click **Save**.

    ![Paste key value and save - screenshot](../L08/Static/Mod_01_Web_Hook_image29.png)

5. Register new step

	- Select the **Web Hook** you registered, click **Register** and select **Register New Step**.

    ![Register new step - screenshot](../L08/Static/Mod_01_Web_Hook_image30.png)

	- Select **Update** for **Message**, **contoso_permit** for **Primary Entity**, and click **Filtering Attributes.**

    ![Filtering attributes - screenshot](../L08/Static/Mod_01_Web_Hook_image31.png)

	- Select only **New Size** and click **OK**.

    ![Select attribute - screenshot](../L08/Static/Mod_01_Web_Hook_image32.png)

	- Select **Asynchronous** for **Execution Mode** and click **Register New Step**.

    ![Register new step - screenshot](../L08/Static/Mod_01_Web_Hook_image33.png)

## Task #2: Test the Web Hook

1. Start the Permit Management application

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Dev** environment selected.

	- Select Apps and click to open the Permit Management application.

    ![Start application - screenshot](../L08/Static/Mod_01_Web_Hook_image34.png)

	- Select **Permits** and open one of the permit records. Create new if you don’t have a Permit record.

    ![Open permit record - screenshot](../L08/Static/Mod_01_Web_Hook_image35.png)

	- Change the **New Size** to **5000** and **Save**.

    ![Change size and save - screenshot](../L08/Static/Mod_01_Web_Hook_image36.png)

2. Check Azure Output

	- Go back to your **Azure Function**.

	- Select **Code + Test**.

	- Show **Logs**.

    ![Show logs - screenshot](../L08/Static/Mod_01_Web_Hook_image37.png)

	- You should see logs like the image below. The Output is a serialized **RemoteExecutionContextobject** object

    ![Function output - screenshot](../L08/Static/Mod_01_Web_Hook_image38.png)

**Hint**: If the log is not showing in the console (sometimes this happens), click **Monitor** on the left and check execution log. Select entry, details will be on the right (this could be delayed up to a few minutes).

6. Confirm the function executes only when the New Size value changes

	- Go back to the **Permit Management** application.

	- Change the **Start Date** to tomorrow’s date and click **Save**.

    ![Update record and save - screenshot](../L08/Static/Mod_01_Web_Hook_image39.png)

Go back to the Azure Function and make sure the function did not execute.

## Task #3: Configure an entity image 

This step allows you to avoid unnecessarily querying CDS and make a request only when you need information from the primary entity. It can also be used to get the prior value of a field before an update operation.

1. Register New Image

	- Go back to the **Plugin Registration** tool.

	- Select the **NewSize** step you created, click **Register** and select **Register New Image**.

    ![Register new image - screenshot](../L08/Static/Mod_01_Web_Hook_image40.png)

	- Check both **Pre** and **Post** images checkboxes.

	- Enter **Permit Image** for **Name**, **PermitImage** for **Entity Alias**, and click on the **Parameters** button.

    ![Image type information - screenshot](../L08/Static/Mod_01_Web_Hook_image41.png)

	- Select **Build Site**, **Contact**, **Name**, **New Size**, **Permit Type**, and **Start Date**, and then click **OK**.

    ![Select attributes - screenshot](../L08/Static/Mod_01_Web_Hook_image42.png)

	- Click **Register Image**.

    ![Register image - screenshot](../L08/Static/Mod_01_Web_Hook_image43.png)

2. Clear Azure log

	- Go back to the **Azure Function.**

	- Clear **Logs**.

    ![Clear logs - screenshot](../L08/Static/Mod_01_Web_Hook_image44.png)

3. Update Permit record

	- Go to the **Permit Management** application.

	- Select **Permits** and open one of the **Permit** records.

	- Change the New Size to **4000** and click **Save**

4. Check Azure logs

	- Go back to the **Azure Function**.

	- Maximize the log pane.

    ![Maximize log pane - screenshot](../L08/Static/Mod_01_Web_Hook_image45.png)

	- The logs should now show both **Pre** and **Post** entity images. In this case you should see the old value **5000** in **Pre** image and the new value **4000** in the **Post** image

    ![Post and pre entity image values - screenshot](../L08/Static/Mod_01_Web_Hook_image46.png)

**Note:** Technically, we have the data in the target object already. However, if there are plugins modifying the data, PostImage will contain the copy as recorded in CDS while Target contains the data as submitted on Save. In addition to that, preimage contains data before the save operation took place.
