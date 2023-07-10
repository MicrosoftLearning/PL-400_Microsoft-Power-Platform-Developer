---
lab:
    title: 'Lab 12: Publishing events externally'
    module: 'Module 10: Integrate Dataverse and Azure'
---

# Practice Lab 12 – Publishing Events Externally

## Scenario

In this lab you will use the event publishing capability of Microsoft Dataverse. When a permit results in changing the size of the build site, an external taxing authority needs to be notified so they can evaluate if additional taxing is required. You will configure Microsoft Dataverse to publish permits with size changes using the Webhook. To simulate the taxing authority receiving the information you will create a simple Azure function to receive the post.

## High-level lab steps

As part of configuring the event publishing, you will complete the following:

- Create an Azure Function to receive the Webhook post
- Configure Microsoft Dataverse to publish events using a Webhook
- Test publishing of events

## Things to consider before you begin

- Do we know what events will trigger our Webhook?
- Could what we are doing with the Webhook, be done using Power Automate?
- Remember to continue working in your DEVELOPMENT environment. We’ll move everything to production soon.

## Starter solution

A starter solution file for this lab can be found in the  C:\Labfiles\L12\Starter folder.

## Completed solution

Completed solution files for this lab can be found in the  C:\Labfiles\L12\Completed folder.

## Resources

Complete source code files for this lab can be found in the  C:\Labfiles\L12\Resources folder.

## Exercise 1: Create an Azure Function

**Objective:** In this exercise, you will create an Azure Function that will be the endpoint to accept and log incoming web requests.

### Task 1.1: Create a Function App in the Azure Portal

1. Create function app.

   - Sign in to the [Azure portal](https://portal.azure.com).

   - Select **Show portal menu** and then select **+ Create a resource**.

   - Search for `function app` and select **Function App** by Microsoft.

   ![New function app - screenshot](../images/L12/Mod_01_Web_Hook_image2.png)

   - Click on the **Function App** tile.

   - Select **Create**.

   ![Create function app - screenshot](../images/L12/Mod_01_Web_Hook_image3.png)

   - Select **Create**.

   - Select your **Azure Pass - Sponsorship** subscription.

   - Select the **PL400** for resource group.

   - Enter `pl400wh` followed by your initials and a unique number for Function App name.

     > Note: Function app name must be unique across Azure. Wait until you see a green tick to confirm the name is unique.

   - Select **.NET** for Runtime stack

   - Select **6 (LTS)** for Version

   - Select **Consumption** for Hosting options and plans.

   - Select **Review + create**.

   - Select **Create**.

### Task 1.1: Create an Azure Function in the Azure Portal

1. Create a new function

   - Select **Go to resource**.

     ![Go to resource - screenshot](../images/L12/azure-portal-go-to-resource.png)

   - Select **Functions**.

     ![Add function - screenshot](../images/L12/Mod_01_Web_Hook_image6.png)

   - Select **+ Create**.

   - Select **HTTP trigger** for Template.

   - Enter `WebHookTrigger` for New Function.

   - Select **Function** for Authorization level.

     ![HTTP trigger - screenshot](../images/L12/azure-portal-create-function.png)

   - Select **Create**.

1. Test the function

   - Select **Code + Test**.

     ![Code + Test - screenshot](../images/L12/Mod_01_Web_Hook_image8.png)

   - Select **Test**/**Run**.

     ![Test/run - screenshot](../images/L12/Mod_01_Web_Hook_image9.png)

   - Select **Run**.

   - You should see **Hello, Azure** in the output.

     ![Function output - screenshot](../images/L12/Mod_01_Web_Hook_image10.png)

   - Close the test pane.

1. Edit the function

   - Replace the entire Task method with the method below.

     ```csharp
     public static async void Run(HttpRequest req, ILogger log)
     {
         log.LogInformation("C# HTTP trigger function processed a request.");

         string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
         dynamic data = JsonConvert.DeserializeObject(requestBody);
         string indentedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
         log.LogInformation(indentedJson);
     }   
     ```

   - Save your changes.

     ![Save function - screenshot](../images/L12/azure-portal-function-code.png)

1. Remove HTTP output

   - Select **Integration**.

     ![Integration - screenshot](../images/L12/Mod_01_Web_Hook_image12.png)

   - Select the **HTTP Output**.

     ![Outputs - screenshot](../images/L12/Mod_01_Web_Hook_image13.png)

   - Select **Delete**.

     ![Delete output - screenshot](../images/L12/Mod_01_Web_Hook_image14.png)

   - Select **OK**.

1. Get the function URL

   - Select **Overview** and then select **Get Function URL**.

     ![Get function URL - screenshot](../images/L12/azure-portal-function-url.png)

   - Select **Copy** and then select OK to close the popup.

     ![Copy function URL - screenshot](../images/L12/Mod_01_Web_Hook_image16.png)

   - Save the **URL** in a notepad, you will need it in the next exercise.

## Exercise 2: Configure Webhook

### Task 2.1: Configure publishing to a webhook

1. Start the Plug-in Registration Tool.

   - Start the developer command prompt tool.

   - Run the command below to launch the Plugin Registration Tool (PRT).

     ```dos
     pac tool prt
     ```

1. Connect to your Dataverse environment.

   - Select **+ CREATE NEW CONNECTION**.

     ![New connection - screenshot ](../images/L12/Mod_01_Web_Hook_image22.png)

   - Select **Office 365** for Deployment Type.
   - Check **Display list of available organizations**.
   - Check **Show Advanced**.
   - Enter your tenant credentials.

     ![Provide credentials - screenshot](../images/L10/Mod_01_Plugin_image18.png)

   - Select **Login**.

     ![Tools environments - screenshot](../images/L06/pac-tools-environments.png)

   - Select your **Development** environment and select **Login**.

1. Register webhook.

   - Select **Register** and then select **Register New Web Hook**.

     ![Register new Webhook - screenshot](../images/L12/Mod_01_Web_Hook_image25.png)

   - Enter `NewSize` for **Name**.

   - Go to the notepad where you saved the function URL and copy everything before the **?**.

     ![Copy URL - screenshot](../images/L12/webhook-url.png)

   - In the Plugin Registration Tool, paste the URL you copied in the **Endpoint URL** field.

      ![Paste URL - screenshot ](../images/L12/webhook-endpoint-url.png)

   - Select **WebhookKey** for **Authentication**.

   - Go back to the notepad and copy the key - everything after **code=**.

   - In the Plugin Registration Tool, paste the key you copied in the **Value** field.

      ![Paste key value - screenshot](../images/L12/webhook-value.png)

   - Select **Save**

1. Register new step on update of new size column.

   - Select the **Webhook** you registered, select **Register** and then select **Register New Step**.

     ![Register new step - screenshot](../images/L12/Mod_01_Web_Hook_image30.png)

   - Enter `Update` for **Message**.

   - Enter `contoso_permit` for **Primary Table**.

   - Select **Filtering Attributes.**

     ![Filtering attributes - screenshot](../images/L12/Mod_01_Web_Hook_image31.png)

   - Uncheck **Select All**.

   - Select **New Size**.

     ![Select attribute - screenshot](../images/L12/Mod_01_Web_Hook_image32.png)

   - Select **OK**.

   - Select **PostOperation** from dropdown for **Event Pipeline Stage of Execution**.

   - Select **Asynchronous** for Execution Mode

     ![Register new step - screenshot](../images/L12/webhook-register-step.png)

   - Select **Register New Step**.

   - Step should now be registered in the WebHook.

### Task 2.2: Test the Webhook

1. Configure formatted output when monitoring the function.

   - Go back to your **Azure Function**.

   - Select **Monitor**.

   - Select the **Logs** tab.

   - Select **App Insight Logs**

     ![Configure Monitor - screenshot](../images/L12/azure-function-monitor.png)

1. Update Permit record.

   - Navigate to the [Power Apps maker portal](https://make.powerapps.com).
   - Make sure you are in the Development environment.
   - Select **Apps**.
   - Select the **Permit Management** app, select the **ellipses (...)** and select **Play**.
   - Select **Permits**.
   - Open the **Test Permit** record.

     ![Open permit record - screenshot](../images/L09/mod-02-pcf-1-65.png)

   - Change the **New Size** to **5000**.

      ![Change size and save - screenshot](../images/L12/Mod_01_Web_Hook_image36.png)

   - Select **Save**.

1. Check Azure logs.

   - Go back to your **Azure Function**.

   - You should see logs like the image below. The Output is a serialized context object.

     ![Function output - screenshot](../images/L12/azure-function-result1.png)

   - Select **Clear**.

      ![Clear logs - screenshot](../images/L12/Mod_01_Web_Hook_image44.png)

1. Confirm the function executes only when the New Size value changes

   - Go back to the **Test Permit** record.

   - Change the **Start Date** to tomorrow’s date and select **Save**.

      ![Update record and save - screenshot](../images/L12/Mod_01_Web_Hook_image39.png)

   - Go back to your **Azure Function**.

   - The log is empty and the function did not execute.

### Task 2.3: Configure entity images

This step allows you to avoid unnecessarily querying Microsoft Dataverse and make a request only when you need information from the primary table. It can also be used to get the prior value of a column before an update operation.

1. Register images.

   - Go back to the **Plugin Registration** tool.

   - Select the **NewSize** step you created, select **Register** and then select **Register New Image**.

     ![Register new image - screenshot](../images/L12/Mod_01_Web_Hook_image40.png)

   - Check **Pre Image**.

   - Check **Post Image**.

   - Enter `Permit PreImage` for **Name**.

   - Enter `PermitImage` for **Entity Alias**.

   - Select the **Parameters** button.

     ![Image type information - screenshot](../images/L12/prt-image-parameters.png)

   - Uncheck **Select All**.

   - Select **Build Site**, **Contact**, **Name**, **New Size**, **Permit Type**, and **Start Date**.

     ![Select attributes - screenshot](../images/L12/Mod_01_Web_Hook_image42.png)

   - Select **OK**.

     ![Register image - screenshot](../images/L12/prt-register-image.png)

   - Select **Register Image**.

1. Update Permit record.

   - In the  **Permit Management** app, select **Permits**.

   - Open the **Test Permit** record.

   - Change the **New Size** to **4000**.

   - Select **Save**.

1. Check Azure logs.

   - Go back to your **Azure Function**.

   - The logs should now show both **Pre** and **Post** entity images. In this case you should see the old value **5000** in **Pre** image and the new value **4000** in the **Post** image

      ![Post and pre entity image values - screenshot](../images/L12/Mod_01_Web_Hook_image46.png)
