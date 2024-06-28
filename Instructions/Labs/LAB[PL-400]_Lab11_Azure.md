---
lab:
    title: 'Lab 11: Azure Functions (Optional)'
    module: 'Module 10: Integrate Dataverse and Azure'
---

# Practice Lab 11 – Azure Functions

## Scenario

In this lab you will create an Azure Function that will handle routing inspections. Every morning people call in to request inspections on their permits. They must call before 9:30 AM and once that period ends all the inspections for the day must be assigned and sequenced for the inspectors. To accomplish this, you will build an Azure Function that runs on a schedule, queries pending inspections and assigns them to inspectors. Given the limited time to complete the lab, we’ve simplified the routing and sequencing decisions.

## High-level lab steps

As part of building the Azure Function, you will complete the following:

- Configure an application user for the app along with a security role
- Build the function logic to route the requests
- Deploy the Azure Function

## Things to consider before you begin

- Could we have used Power Automate instead of custom code?
- Remember to continue working in your DEVELOPMENT environment. We'll move everything to production soon.

## Starter solution

A starter solution file for this lab can be found in the  C:\Labfiles\L11\Starter folder.

## Completed solution

Completed solution files for this lab can be found in the  C:\Labfiles\L11\Completed folder.

## Resources

Complete source code files for this lab can be found in the  C:\Labfiles\L11\Resources folder.

## Exercise 1: Configure an Microsoft Entra application user and add the user to Dataverse

**Objective:** In this exercise, you will configure an application user that will be used to connect the Azure Function back to Microsoft Dataverse.

### Task 1.1: Register Application in Microsoft Entra

1. Navigate to Microosft Entra portal

- Sign in to the [Microsoft Entra  portal](https://entra.microsoft.com/).

   > **Note:** You must be logged in with an organization account in the same tenant as your Microsoft Dataverse Environment. This does **NOT** have to be the account for your Azure subscription.

1. Expand **Applications** and select **App registrations**.

   ![App registrations - screenshot](../images/L11/aad-app-registrations.png)

1. Select **+ New registration**.

   ![New App registration - screenshot](../images/L11/aad-app-new-registration.png)

1. Enter `Inspection Router` for **Name**

1. Select **Accounts in this organizational directory only** for **Supported account types**.

   ![Register application - screenshot](../images/L11/Mod_02_Azure_Functions_image4.png)

1. Select **Register**.

### Task 1.2: Enable OAuth 2.0

1. Select **Manifest**.

1. Set **allowPublicClient** to **true**.

1. Set **oauth2AllowIdTokenImplicitFlow** to **true**.

1. Set **oauth2AllowImplicitFlow** to **true**.

   ![App registration manifest - screenshot](../images/L11/aad-app-registration-manifest.png)

1. Select **Save**.

### Task 1.3: API Permissions

1. Select **API permissions**.

1. Select **+Add a permission**.

   ![App registration Request API permissions - screenshot](../images/L11/aad-app-registration-api-permissions.png)

1. Select **Dynamics CRM**.

1. Select **Delegated permissions**.

1. Check **user_impersonation**.

   ![App registration Dataverse API permissions - screenshot](../images/L11/aad-app-registration-dataverse-api-permissions.png)

1. Select **Add permissions**.

### Task 1.4: Client secret

1. Select **Certificates &amp; secrets**.

1. Click **+ New client secret**.

   ![New client secret - screenshot](../images/L11/Mod_02_Azure_Functions_image6.png)

1. Enter `Inspection Routing` for **Description**, select **(365 days) 12 months** for **Expires**

   ![Add client secret - screenshot](../images/L11/Mod_02_Azure_Functions_image7.png)

1. Select **Add**.

1. Copy the **Value** and save it on a notepad. You will need this value in future tasks.

   ![Copy value - screenshot](../images/L11/Mod_02_Azure_Functions_image8.png)

1. Select **Overview**

   ![Copy app id - screenshot](../images/L11/aad-app-registration-overview.png)

1. Copy the **Application (client) ID.** and save it on a notepad. You will need this value in future tasks.

### Task 1.5: Dataverse security role

In this task, you will create the security role needed for the routing logic.

1. Open the Permit Management solution.

   - Navigate to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Development** environment selected.
   - Select **Solutions**.
   - Open the **Permit Management** solution.

1. Create security role.

   - Select **+ New** and then select **Security** and select **Security role**.

     ![New security role - screenshot](../images/L11/Mod_02_Azure_Functions_image12.png)

   - Enter `Inspection Router` for **Role Name**, select the root business unit.

   - Uncheck **Include App Opener privileges**.

     ![New security role pane - screenshot](../images/L11/create-new-role-pane.png)

   - Select **Save**.

   - Search for the **systemuser** table and set the **Read** and **Append To** privileges to **Organization**.

     ![User table privileges - screenshot](../images/L11/security-role-privileges-user.png)

   - Search for the **Inspection** table and set the **Read**, **Write**, **Append,** and **Assign** privileges to **Organization**.

     ![Inspection table privileges - screenshot](../images/L11/security-role-privileges-inspection.png)

   - Select **Save**.

   - Select **<- Back**.

### Task 1.6: Add Application user to Dataverse

In this task, you will create the application user in Dataverse and associate it with the Microsoft Entra app that you just registered.

1. Navigate to the [Power Platform admin center](https://admin.powerplatform.microsoft.com).

1. Select **Environments**.

1. Select your **Development** environment.

     ![Development environment details - screenshot](../images/L11/development-environment.png)

1. Select **See all** under **S2S apps**.

1. Select **+ New app user**.

1. Select **+ Add an app**.

   ![New application user - screenshot](../images/L11/Mod_02_Azure_Functions_image19.png)

1. Select the **Inspection Router** app registration and then select **Add**.

   ![Switch form - screenshot](../images/L11/Mod_02_Azure_Functions_image20.png)

1. Select your root Business Unit.

1. Select the edit icon under **Security roles**.

   ![Edit security roles- screenshot](../images/L11/Mod_02_Azure_Functions_image21.png)

1. Select the Inspection Router security role

   ![ Add security role - screenshot](../images/L11/Mod_02_Azure_Functions_image26.png)

1. Select **Save**.

   ![Create app user - screenshot](../images/L11/Mod_02_Azure_Functions_image27.png)

1. Select **Create**.

## Exercise 2: Create Azure Function for Inspection Routing

**Objective:** In this exercise, you will create the Azure function that will route the inspections.

### Task 2.1: Azure resources

1. Create Resource group.

   - Sign in to the Azure portal `https://portal.azure.com` and login with the credentials used when redeeming your Azure Pass..

   - Select **Show portal menu** and then select **+ Create a resource**.

     ![Create new resource - screenshot](../images/L12/Mod_01_Web_Hook_image1.png)

   - Search for `resource group` and select **Resource group**.

     ![Azure Marketplace resource group - screenshot](../images/L11/azure-marketplace-resource-group.png)

   - Click on the **Resource group** tile.

   - Select **Create**.

   - Select your **Azure Pass - Sponsorship** subscription.

   - Enter `PL400` for resource group.

     ![Create resource group - screenshot](../images/L11/azure-resource-group-create.png)

   - Select **Review + create**.

   - Select **Create**.

1. Create Storage account.

   - Select **Show portal menu** and then select **+ Create a resource**.

   - Search for `storage account` and select **Storage account** by Microsoft.

   - Click on the **Storage account** tile.

   - Select **Create**.

   - Select your **Azure Pass - Sponsorship** subscription.

   - Select the **PL400** for resource group.

   - Enter `pl400sa` followed by a unique number for Storage account name.

     > Note: Storage account name must be unique across Azure.

   - Select **Standard** for Performance.

   - Select **Locally-redundant storage (LRS)** for Redundancy.

     ![Create resource group - screenshot](../images/L11/azure-storage-account-create.png)

   - Select **Review + create**.

   - Select **Create**.

1. Create Function app.

   - Select **Show portal menu** and then select **+ Create a resource**.

   - Search for `function app` and select **Function App** by Microsoft.

   ![New function app - screenshot](../images/L12/Mod_01_Web_Hook_image2.png)

   - Select the **Function App** tile.

   ![Create function app - screenshot](../images/L12/Mod_01_Web_Hook_image3.png)

   - Select **Create**.

   - Select the **Consumption** tile.

   - Select **Select**.

   - Select your **Azure Pass - Sponsorship** subscription.

   - Select the **PL400** for resource group.

   - Enter `pl400fa` followed by your initials and a unique number for Function App name.

     > Note: Function app name must be unique across Azure. Wait until you see a green tick to confirm the name is unique.

   - Select **.NET** for Runtime stack

   - Select **6 (LTS), in-process model** for Version

   - Select **Next : Storage**.

   - Select the storage account you just created.

   - Select **Review + create**.

    ![Create function app - screenshot](../images/L11/azure-function-app-create.png)

   - Select **Create**.

   - Select **Go to resource**.

1. Configure settings

   - Select **Settings** -> **Configuration** and then select **General settings** tab.

   - Select **On** for **SCM Basic Auth Publishing Credentials**.

   - Select **Save**.

### Task 2.2: Create Function using Visual Studio

1. Create Azure Function project in Visual Studio.

   - Start **Visual Studio**.

     ![New visual studio project - screenshot](../images/L11/Mod_02_Azure_Functions_image28.png)

   - Select **Create a new project**.
   - Search for `functions`.

     ![Azure functions - screenshot](../images/L11/Mod_02_Azure_Functions_image29.png)

   - Select **Azure Functions** and then select **Next**.

   - Enter `InspectionRoutingApp` for **Name**.

   - Change the location to **C:\LabFiles\L11**.

     ![Visual Studio configure project - screenshot](../images/L11/visual-studio-configure-project.png)

   - Select **Next**.

   - Select **.NET Framework Isolated v4**.

   - Select **Timer Trigger**.

   - Change the Schedule to `0 0 0 * * *` (Midnight Every Day).

     ![Azure function application - screenshot](../images/L11/azure-function-configuration.png)

   - Select **Create**.

1. Rename and run the Function.

   - In Solution Explorer, right click on **Function1.cs** and select **Rename**.

     ![Rename class - screenshot](../images/L11/visual-studio-rename-function.png)

   - Rename the function file as `InspectionRouter.cs`.
  
     ![Rename function file - screenshot](../images/L11/visual-studio-renamed-function.png)

   - Select **Yes** to rename references.

   - Open **InspectionRouter.cs** file.

   - Rename the function **Function1** to `InspectionRouter`.

     ![Change function name - screenshot](../images/L11/Mod_02_Azure_Functions_image34.png)

1. Add NuGet packages.

   - In Solution Explorer, right-click the *InspectionRoutingApp project* and select **Manage NuGet Packages...**.

   - Select the **Browse** tab.

   - Search for `identitymodel` and select the **Microsoft.IdentityModel.Clients.ActiveDirectory** NuGet package.

     ![Install package - screenshot](../images/L11/Mod_02_Azure_Functions_image42.png)

   - Select **Install**.

   - Select **OK**.

   - Select **I Accept**.

   - Search for `newtonsoft` and select the **Newtonsoft.Json** NuGet package.

   - Select **InspectionRoutingApp**.

   - Select **Install**.

   - Select **OK**.

   - Select **I Accept**.

   - Search for `crmwebapi` and select the **Xrm.Tools.CrmWebAPI by David Yack** NuGet package.

     ![Install package - screenshot](../images/L11/Mod_02_Azure_Functions_image43.png)

     > Note: This is a community library designed to work with the Microsoft Dataverse Web API. When you are building this type of extension you can use any oData V4 library you prefer. Make sure you select the one developed by DavidYack.

   - Select **Install**.

   - Select **OK**.

   - Select **I Accept**.

   - Close the **NuGet: Permit console** tab.

1. Edit the local settings file.

   - Open the **local.settings.json** file.

     ![Local settings file - screenshot](../images/L11/Mod_02_Azure_Functions_image44.png)

   - Add the **Values** below to **local.settings**

     ```json
     ,
     "cdsurl": "",
     "cdsclientid": "",
     "cdsclientsecret": ""
     ```

     ![Add values - screenshot](../images/L11/Mod_02_Azure_Functions_image45.png)

   - Find the client secret you saved in the notepad and paste as the cdsclientsecret.

     ![Client secret - screenshot](../images/L11/Mod_02_Azure_Functions_image46.png)

   - Find the application (client) ID in the notepad and paste as the **cdsclientid**.

   - Find the Dataverse environment URL in the notepad and paste as the **cdsurl**.

     ![Paste URL - screenshot](../images/L11/Mod_02_Azure_Functions_image51.png)

   - Save and close the  **local.settings.json** file.

1. Add using statements to the function class.

   - Open the **InspectionRouter.cs** file

   - Add the using statements below

     ```csharp
     using System.Threading.Tasks;
     using Xrm.Tools.WebAPI;
     using Microsoft.IdentityModel.Clients.ActiveDirectory;
     using Xrm.Tools.WebAPI.Results;
     using System.Dynamic;
     using Xrm.Tools.WebAPI.Requests;
     using System.Collections.Generic;
     ```

1. Create a method that will create the Web API.

   - Add the method below inside the InspectionRouter class.

     ```csharp
     private static async Task<CRMWebAPI> GetCRMWebAPI(ILogger log)
     {

        return null;
     }
     ```

   - Add the local variables below before the return line on the **GetCRMWebAPI** method.

     ```csharp
     var clientID = Environment.GetEnvironmentVariable("cdsclientid", EnvironmentVariableTarget.Process);
     var clientSecret = Environment.GetEnvironmentVariable("cdsclientsecret", EnvironmentVariableTarget.Process);
     var crmBaseUrl = Environment.GetEnvironmentVariable("cdsurl", EnvironmentVariableTarget.Process);
     var crmurl = crmBaseUrl + "/api/data/v9.2/";
     ```

   - Create **Authentication Parameters**.

     ```csharp
     AuthenticationParameters ap = await AuthenticationParameters.CreateFromUrlAsync(new Uri(crmurl));
     ```

   - Create **Client Credential** passing your **Client Id** and **Client Secret**.

     ```csharp
     var clientcred = new ClientCredential(clientID, clientSecret);
     ```

   - Get **Authentication Context**.

     ```csharp
     // CreateFromUrlAsync returns endpoint while AuthenticationContext expects authority
     // workaround is to downgrade adal to v3.19 or to strip the tail
     var auth = ap.Authority.Replace("/oauth2/authorize", "");
     var authContext = new AuthenticationContext(auth);
     ```

   - Get **Token**.

     ```csharp
     var authenticationResult = await authContext.AcquireTokenAsync(crmBaseUrl, clientcred);
     ```

   - Return the **Web API**. Replace the **return null** line with the code below.

     ```csharp
     return new CRMWebAPI(crmurl, authenticationResult.AccessToken);
     ```

     ![Get CRM web API method - screenshot](../images/L11/azure-function-webapi-code.png)

1. Call the Web API.

   - Call the GetCRMWebAPI method and Execute **WhoAmI**.

     ```csharp
     CRMWebAPI api = GetCRMWebAPI(_logger).Result;
     dynamic whoami = api.ExecuteFunction("WhoAmI").Result;
     _logger.LogInformation($"UserID: {whoami.UserId}");
     ```

     ![Run method - screenshot](../images/L11/Mod_02_Azure_Functions_image53.png)

### Task 2.3: Get Inspections and Users and Assign Inspections

1. Create a method that will get all active inspections that are New Request or Pending, and schedule them for today

   - Add the method below inside the InspectionRouter class.

     ```csharp
     private static Task<CRMGetListResult<ExpandoObject>> GetInspections(CRMWebAPI api)
     {

        return null;
     }
     ```

   - Create **FetchXML** query. Add the code below before the return line of the GetInspections method.

     ```csharp
     var fetchxml = @"<fetch version=""1.0"" mapping=""logical"" >
        <entity name=""contoso_inspection"" >
           <attribute name=""contoso_inspectionid"" />
           <attribute name=""contoso_name"" />
           <attribute name=""ownerid"" />
           <attribute name=""contoso_inspectiontype"" />
           <attribute name=""contoso_sequence"" />
           <attribute name=""contoso_scheduleddate"" />
           <filter type=""and"" >
              <condition value=""0"" operator=""eq"" attribute=""statecode"" />
              <condition attribute=""contoso_scheduleddate"" operator=""today"" />
              <condition attribute=""statuscode"" operator=""in"" >
                 <value>1</value>
                 <value>330650001</value>
              </condition>
           </filter>
        </entity>
     </fetch>";
     ```

     > [!NOTE]
     >  1 is the value of the Inspection New Request status reason and 330650001 id the value of the Inspection Pending status reason. If the Pending status reason is different for your environment, change the code to match your value.

   - Get the list of Inspections.

     ```csharp
     var inspections = api.GetList<ExpandoObject>("contoso_inspections", QueryOptions: new CRMGetListOptions()
     {
        FetchXml = fetchxml
     });
     ```

   - Return the Inspections. Replace the **return = null** line with the code below.

     ```csharp
     return inspections;
     ```

     ![Get inspections method - screenshot](../images/L11/azure-function-inspections-code.png)

1. Call the GetInspections method from the Run method.

   - Go back to the **Run** method.

   - Call the **GetInspections** method.

     ```csharp
     var inspections = GetInspections(api).Result;
     ```

     ![Call get inspections method - screenshot](../images/L11/Mod_02_Azure_Functions_image58.png)

1. Create a method that will get all users.

   - Add the method below inside the class.

     ```csharp
     private static Task<CRMGetListResult<ExpandoObject>> GetUsers(CRMWebAPI api)
     {
        var users = api.GetList<ExpandoObject>("systemusers");
        return users;
     }
     ```

   - Call the **GetUsers** method from the **Run** method.

     ```csharp
     var users = GetUsers(api).Result;
     ```

     ![Call get users method - screenshot](../images/L11/Mod_02_Azure_Functions_image59.png)

1. Create a method that will assign inspections to users.

   - Add the method below to the class.

     ```csharp
     private static async Task<CRMUpdateResult> RouteInspection(CRMWebAPI api, dynamic inspection, string userId, int sequenceNumber)
     {
        dynamic updateObject = new ExpandoObject();
        ((IDictionary<string, object>)updateObject).Add
        ("ownerid@odata.bind", "/systemusers(" + userId + ")");
        updateObject.contoso_sequence = sequenceNumber.ToString();
        return await api.Update("contoso_inspections", new Guid(inspection.contoso_inspectionid), updateObject);
     }
     ```

1. Create two-digit random number.

   - Add the code below to the Run method.

     ```csharp
     Random rnd = new Random();
     int sequenceNumber = rnd.Next(10, 99);
     ```

1. Assign Inspections

   - Go through the **Inspections** and call the **RouteInspection** method.

     ```csharp
     int currentUserIndex = 0;
     foreach (dynamic inspection in inspections.List)
     {
        _logger.LogInformation($"Routing inspection {inspection.contoso_name}");
        var inspectionResult = new CRMUpdateResult();
        // Your record assignment would look like this. We will not assign records to different users in this lab
        // if (users.List.Count > (currentUserIndex))
        //{
        // dynamic currentUser = users.List[currentUserIndex];
        // inspectionResult = RouteInspection(api, inspection, currentUser.systemuserid.ToString(), sequenceNumber).Result;
        //currentUserIndex++;
        //}
     }
     ```

   - We will not assign inspection records to other users in this lab.

     ![Comment out code - screenshot](../images/L11/Mod_02_Azure_Functions_image60.png)

   - Assign inspections to the Inspection Router. Add the code below inside **foreach**.

     ```csharp
     // We will instead assign inspections to the user you are currently logged in as
     inspectionResult = RouteInspection(api, inspection, whoami.UserId.ToString(), sequenceNumber).Result;
     ```

     ![Assign inspections - screenshot](../images/L11/Mod_02_Azure_Functions_image61.png)

   - Select the **Save** icon.

   - In Solution Explorer, right-click on the project and select **Build**.

   - The Build should succeed with 0 errors.

## Exercise 3: Publish and test

**Objective:** In this exercise, you will publish the Azure function to Azure, update the app settings, and test the function.

### Task 3.1: Publish to Azure

1. Publish the function to Azure.

   - In Solution Explorer, right click on the project and select **Publish**.

     ![Publish project - screenshot](../images/L11/visual-studio-publish-project.png)

   - Select **Azure** and then select **Next**.

   - Select **Azure Function App (Windows)** and then select **Next**.

   - Sign in with user that has an Azure subscription.

   - Select your **Azure Pass - Sponsorship** subscription.

   - Expand the **PL400** resource group.

   - Select the function app you created in the earlier exercise.

     ![Publish Azure function app - screenshot](../images/L11/visual-studio-publish-azure.png)

   - Select **Finish**.

     ![Deploy Azure function app - screenshot](../images/L11/visual-studio-deploy-azure.png)

   - Select **Publish**.
  
   - If prompted, select **Update** to update the function app settings.

   - Select **Yes**.

     ![Publishing Azure function app - screenshot](../images/L11/visual-studio-publishing-azure.png)

   - Wait for the function application to be successfully published to Azure.

   - Select **File** and **Exit**.

1. Open function application settings.

   - Go back to you **Azure** portal.

   - Select **All Resources**, search for `pl400fa`, and open the function you published.

     ![Azure resources - screenshot](../images/L11/azure-portal-resources.png)

   - Scroll down to **Settings** and select **Environment variables**.

     ![Configuration - screenshot](../images/L11/azure-portal-configuration-settings.png)

1. Update function app settings.

   - Select **Advanced edit**.

   - Paste the json below at the top of the settings.

     ```json
       {
          "name": "cdsclientid",
          "value": "[clientid]",
          "slotSetting": false
       },
       {
          "name": "cdsclientsecret",
          "value": "[clientsecret]",
          "slotSetting": false
       },
       {
          "name": "cdsurl",
          "value": "[cdsurl]",
          "slotSetting": false
       },
     ```

     ![Edit settings - screenshot](../images/L11/Mod_02_Azure_Functions_image68.png)

   - Go back to **Visual Studio** and open the **local.settings.json** file.

    ![Copy URL - screenshot ](../images/L11/Mod_02_Azure_Functions_image69.png)

   - Copy the **cdsclientid**, **cdsclientsecret** and **cdsurl** values from the **local.settings.json** file and replace [**cdsclientid**], [**cdsclientsecret**] and [cdsurl].

     ![Paste id and secret - screenshot](../images/L11/Mod_02_Azure_Functions_image71.png)

   - Select **OK**.

   - Select **Apply**.

   - Select **Confirm**.

### Task 3.2: Test

1. Timezone.

   - Navigate to the Power Apps maker portal <https://make.powerapps.com>.
   - Make sure you are in the Development environment.
   - Select **Apps**.
   - Select the **Permit Management** app, select the **ellipses (...)** and select **Play**.

   - Select **Settings** and then select **Personalization and Settings**.

     ![Personal settings - screenshot](../images/L11/Mod_02_Azure_Functions_image77.png)

   - Change the **Time Zone** to **(GMT-11:00) Coordinated Universal Time-11** and then select **OK**. This will ensure the query results will produce the same results regardless of your time zone.

     ![Change time zone - screenshot](../images/L11/Mod_02_Azure_Functions_image78.png)

1. Reset inspections test data.

   - Navigate to [Power Apps maker portal](https://make.powerapps.com/) and make sure you have the **Development** environment selected.
   - Select **Solutions**.
   - Open the **Permit Management** solution.
   - Select **Cloud flows**.
   - Select the ellipses **...** for the **Reset Inspections** flow, select **Edit** and select **Edit in new tab**.

     ![Edit flow - screenshot](../images/L11/edit-flow.png)

   - Select the **Loop** step.

   - Select the **Update Inspection** step.

   - Click in **Scheduled Date**.

   - Select the **Expression** tab.

   - Enter `utcNow()`.

     ![UtcNow expression - screenshot](../images/L11/update-flow-step.png)

   - Select **OK**.

   - Select **Save**.

   - Select **Test**.

   - Select **Manually**.

   - Select **Test**.

   - Select **Run flow**.

   - Select **Done**.

   - Close the flow editor.

   - All inspections records should be set to Pending and scheduled for today.

1. Run the function.

   - Go to your **Azure** portal.

   - Select the **Overview** pane and select the function you published.

     ![Open function - screenshot](../images/L11/function-in-portal.png)

   - Select the **Code + Test** tab.

     ![Code + Test - screenshot](../images/L11/Mod_02_Azure_Functions_image74.png)

   - Select **Test/Run**.

     ![Run function - screenshot](../images/L11/Mod_02_Azure_Functions_image81.png)

   - Select **Run**.

   - The function should run and succeed.

     ![Run result - screenshot](../images/L11/azure-function-inspections-results.png)

1. Confirm record assignments.

   - Go back to the **Permit Management** application.

   - Select **Inspections**.

   - The **Owner** of the inspections should now be the **Inspection Router** and .

     ![Routed records - screenshot](../images/L11/assigned-inspections.png)
