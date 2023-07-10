---
lab:
    title: 'Lab 7: Power Platform APIs'
    module: 'Module 6: Introduction to developing with Power Platform'
---

# Practice Lab 7 - Power Platform APIs

## Scenario

As we continue to build our solution, we will now perform basic operations with the Dataverse APIs.

## High-level lab steps

We will use the following APIs

- Organization Service
- Web API

## Things to consider before you begin

- What endpoints do you need?
- Which IDE(s) do you require?

## Starter solution

A starter solution file for this lab can be found in the  C:\Labfiles\L07\Starter folder.

## Completed solution

Completed solution files for this lab can be found in the  C:\Labfiles\L07\Completed folder.

## Resources

Complete code files for this lab can be found in the  C:\Labfiles\L07\Resources folder.

## Exercise 1: Organization Service

**Objective:** In this exercise, you will use the Organization Service to access data in Dataverse.

### Task 1.1: Organization Service endpoint

1. Open the Permit Management solution.

   - Navigate to the [Power Apps maker portal](https://make.powerapps.com).
   - Make sure you are in the Development environment.
   - Select **Apps**.
   - Select the **Permit Management** app, select the **ellipses (...)** and select **Play**.
   - Copy the Dataverse URL before main.aspx excluding final /.

     ![Organization Service URL - screenshot](../images/L07/organization-service-endpoint.png)

### Task 1.2: Early-bound classes

1. Launch **XrmToolBox**.
1. Select the **Tools** tab in XRMToolBox.
1. Search for `early` and select **Early Bound Generator**.
1. Select **Yes** to connect to an organization.
1. Select your **Dev** connection and select **Connect**.

     ![Early Bound Generator - screenshot](../images/L07/early-bound-tool.png)

1. Configure early bound options

   - Under *Entities*, select the ellipses next to **Entities Whitelist** and add *Contact* and *User*.

     ![Early Bound Whitelist - screenshot](../images/L07/early-bound-entities-whitelist.png)

   - Select **Save**.
   - Under *Entities*, select the ellipses next to **Entities Prefix Whitelist**.
   - Enter `contoso` and select **OK**.

1. Generate early bound classes

   - Select **Create Entities**.
   - Check **Display list of available organizations**.
   - Check **Show Advanced**.
   - Enter your tenant credentials.
   - Select **Login**.
   - Select your **Development** environment and select **Login**.
   - Select **Create OptionSets**.
   - Check **Display list of available organizations**.
   - Check **Show Advanced**.
   - Enter your tenant credentials.
   - Select **Login**.
   - Select your **Development** environment and select **Login**.
   - Open Windows Explorer and change to the **C:\Users\Admin\AppData\Roaming\MscrmTools\XrmToolBox\Settings\EBG** folder. You should see Entities.cs and OptionSets.cs class files.

     ![Early bound classes - screenshot](../images/L07/early-bound-entity-classes.png)

### Task 1.3: Create Console app

> [!NOTE]
> The virtual machine used in the lab environment has Visual Studio 2019 Community Edition installed. The labs are have been verified against this version of Visual Studio. If you are using a different version or edition of Visual Studio, the steps may differ.

1. Start Visual Studio

   - Launch Visual Studio 2019.

     ![Visual Studio Welcome - screenshot](../images/L07/visual-studio-welcome.png)

   - Select **Sign in** and use your Tenant credentials.
   - Select **Start Visual Studio**.

1. Create a new .NET console app project.

   - Select **Create a new project**.
   - Search for `console`.

     ![Visual Studio create project - screenshot](../images/L07/visual-studio-create-project.png)

   - Select **Console App (.NET Framework)**.
   - Select **Next**.
   - Enter `Permit console` for Project Name.
   - Change the location to **C:\LabFiles\L07**.
   - Select **.NET Framework 4.7.2**.

     ![Visual Studio configure project - screenshot](../images/L07/visual-studio-configure-project.png)

   - Select **Create**.

1. Add Dataverse assemblies.

   - In Solution Explorer, right-click the *Permit console project* and select **Manage NuGet Packages...**.
   - Select the **Browse** tab.
   - Search for `CrmSdk` and select the **Microsoft.CrmSdk.CoreAssessmblies** NuGet package.
   - Select **Install**.
   - Select **OK**.
   - Select **I Accept**.
   - Search for `CrmSdk` and select the **Microsoft.CrmSdk.XrmTooling.CoreAssembly** NuGet package.
   - Select **Install**.
   - Select **OK**.
   - Select **I Accept**.
   - Close the **NuGet: Permit console** tab.

1. Replace the using statements at the top of Program.cs with the following.

   ```csharp
   using System;
   using System.ServiceModel;
   using Microsoft.Crm.Sdk.Messages;
   using Microsoft.Xrm.Sdk;
   using Microsoft.Xrm.Sdk.Metadata;
   using Microsoft.Xrm.Sdk.Query;
   using Microsoft.Xrm.Tooling.Connector;
   ```

   > [!IMPORTANT]
   > When copying and pasting code into Visual Studio in the Virtual Machine, Intellisense may add or replace code. You should open Notepad and paste into Notepad first, and then copy and paste into Visual Studio.

1. Remove the Program class in Program.cs.

1. Replace the code in Program.cs with the following code.

   ```csharp
   class Program
   {
       static public void Main(string[] args)
       {
           Console.Title = "PL400.Permit.Console";
           Console.WriteLine("Permit console : Start");

            string connectionString = "AuthType=OAuth;Username=<username>;Password=<password>;Url=<url>;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;LoginPrompt=Auto";

           try
           {
               Console.WriteLine("Connect using XRM Tooling");
               CrmServiceClient crmSvc = new CrmServiceClient(connectionString);
               if (crmSvc.IsReady)
                   Console.WriteLine("Connected");
               else
               {
                   throw new Exception("Failed to connect");
               }

               Console.WriteLine("Version={0}", crmSvc.ConnectedOrgVersion);
               Console.WriteLine("Organization={0}", crmSvc.ConnectedOrgUniqueName);

               Console.WriteLine("Retrieve current user");
               Guid currentuserid = ((WhoAmIResponse)crmSvc.Execute(new WhoAmIRequest())).UserId;
               Entity systemUser = (Entity)crmSvc.Retrieve("systemuser", currentuserid, new ColumnSet(new string[] { "firstname", "lastname" }));
               Console.WriteLine("Logged on user is {0} {1}.", systemUser["firstname"], systemUser["lastname"]);

               // Data Operations



               Console.WriteLine("Permit console : End");
               // Pause the console so it does not close.
               Console.WriteLine("Press the <Enter> key to exit.");
               Console.ReadLine();
           }
           catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
           {
               Console.WriteLine("Error: {0}", ex.Message);
           }
           catch (System.Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.Message);
           }
       }
   }
   ```

1. Add your tenant credentials in the connection string.
1. Add your Dataverse URL to the connection string.

   > [!NOTE]
   > The Dataverse URL should be similar to https://orgNNNaNNNN.crm.dynamics.com

   > [!IMPORTANT]
   > The URL should not have the / character as the end.

1. Build the project.

   - Select the **Save** icon.
   - In Solution Explorer, right-click the *Permit console project* and select **Build**.
   - The Build should succeed with 0 errors.

1. Run the app.

   - Click on the **Start** icon.
   - The output will look similar to the following:

     ![Console app output  - screenshot](../images/L07/console-whoami-output.png)

1. Press the **Enter** key.
1. Select **File** and **Exit**.

### Task 1.4: Data operations

1. Start Visual Studio.

   - Launch Visual Studio 2019.
   - Select **Permit console.sln** under Open recent.

1. Add early bound classes.

   - In Solution Explorer, right-click the *Permit console* project and select **Add**, and then select **Existing Item**.
   - Browse to **C:\Users\Admin\AppData\Roaming\MscrmTools\XrmToolBox\Settings\EBG**.
   - Select `Entities.cs` and select **Add**.
   - In Solution Explorer, right-click the *Permit console* project and select **Add**, and then select **Existing Item**.
   - Browse to **C:\Users\Admin\AppData\Roaming\MscrmTools\XrmToolBox\Settings\EBG**.
   - Select `OptionSets.cs` and select **Add**.

1. Add using statement at the top of Program.cs.

   ```csharp
   using CrmEarlyBound;
   ```

1. Create permit.

   - In program.cs, add the following code under the Data Operations comment.

     ```csharp
     Console.WriteLine("Create permit");
     contoso_Permit newPermit = new contoso_Permit();
     newPermit.contoso_Name = "Organization Service Permit";
     newPermit.contoso_NewSize = 1000;
     newPermit.contoso_StartDate = DateTime.Now;
     Guid permitid = crmSvc.Create(newPermit);
     Console.WriteLine("Permit={0}", permitid.ToString());
     ```

1. List inspections.

   - In program.cs, add the following code under the Data Operations comment.

     ```csharp
     Console.WriteLine("Retrieving inspections");
     QueryExpression inspectionsQuery = new QueryExpression
     {
         EntityName = contoso_Inspection.EntityLogicalName,
         ColumnSet = new ColumnSet(false)
     };
     inspectionsQuery.ColumnSet.AddColumn("contoso_permit");
     inspectionsQuery.ColumnSet.AddColumn("contoso_name");
     inspectionsQuery.Criteria.AddCondition("statuscode", ConditionOperator.Equal, (int)contoso_Inspection_StatusCode.Pending);
     inspectionsQuery.Distinct = true;
     EntityCollection inspections = crmSvc.RetrieveMultiple(inspectionsQuery);
     Console.WriteLine("Number of Pending Inspections=" + inspections.Entities.Count.ToString());
     foreach (contoso_Inspection inspection in inspections.Entities)
     {
         EntityReference permit = inspection.contoso_Permit;
         Console.WriteLine("Inspection {0} {1} {2}", permit.Id.ToString(), permit.Name, inspection.contoso_Name);
     }
     ```

1. Build the project.

   - Select the **Save** icon.
   - In Solution Explorer, right-click the *Permit console* project and select **Build**.
   - The Build should succeed with 0 errors.

1. Run the app.

   - Click on the **Start** icon.
   - The output will look similar to the following:

     ![Console app output  - screenshot](../images/L07/console-output.png)

1. Press the **Enter** key.
1. Select **File** and **Exit**.

## Exercise 2: Web API

**Objective:** In this exercise, you will use the Web API to access data in Dataverse using Postman.

### Task 2.1: Web API data operations

> [!NOTE]
> You must have installed and configured Postman in the previous lab to be able to perform this exercise.

1. Open **Postman**.

   - Launch **Postman**.

     ![Postman environment - screenshot](../images/L07/postman-environment.png)

   - Select the **MyNewEnvironment** environment you created in the previous lab.

   - Select **+** to open a new tab.

     ![Postman new tab - screenshot](../images/L07/postman-newtab.png)

1. Authorization.

   - Select the **Authorization** tab.
   - Select **OAuth 2.0** for **Type**.
   - Select **Request Headers** for **Add authorization data to**.
   - Under *Configure New Token*, set:
     - Grant Type to `Implicit`
     - Callback URL to `\{\{callback\}\}`
     - Auth URL to `\{\{authurl\}\}`
     - Client ID to `\{\{clientid\}\}`

     ![Postman authorization tab - screenshot](../images/L07/postman-authorization.png)

   - Select **Get New Access Token**.
   - Sign in with your tenant credentials.
   - Wait until the Manage Access Tokens dialog appears.
   - Select **Use Token**.

1. Headers.

   - Select the **Headers** tab.
   - Click in **Key** and select **Content-Type**.
   - Click in **Value** and select **application/json**.
   - Click in **Key** and select **Accept**.
   - Click in **Value** and select **application/json**.
   - Click in **Key** and enter `OData-Version`.
   - Click in **Value** and enter `4.0`.
   - Click in **Key** and enter `OData-MaxVersion`.
   - Click in **Value** and enter `4.0`.
   - Click in **Key** and select **If-None-Match**.
   - Click in **Value** and enter `null`.

     ![Postman headers tab - screenshot](../images/L07/postman-headers.png)

1. Retrieve inspections.

   - Select **GET**.
   - Enter the following in *Enter request URL*.

     ```odata
     {{webapiurl}}contoso_inspections?$select=contoso_Permit, contoso_name
     ```

   - Select **Send**.

   - You should see a status of 200 and the response pane will should the following records in JSON format.

     ```json
     {
      "@odata.context": "https://org823a9845.api.crm.dynamics.com/api/data/v9.2/$metadata#contoso_inspections(contoso_Permit,contoso_name)",
      "value": [
          {
            "@odata.etag": "W/\"1270113\"",
            "contoso_name": "Framing Inspection",
            "contoso_inspectionid": "86f6ffd7-f9ec-ed11-8848-0022481c5f83"
          },
          {
            "@odata.etag": "W/\"1270026\"",
            "contoso_name": "Electric Inspection",
            "contoso_inspectionid": "d7366402-82ed-ed11-8848-0022481c5f83"
          },
          {
            "@odata.etag": "W/\"1270027\"",
            "contoso_name": "Plumbing Inspection",
            "contoso_inspectionid": "18c39160-82ed-ed11-8848-0022481c5f83"
          },
          {
            "@odata.etag": "W/\"1270028\"",
            "contoso_name": "Mechanical Inspection",
            "contoso_inspectionid": "de46fb89-82ed-ed11-8848-0022481c5f83"
          },
          {
            "@odata.etag": "W/\"1273550\"",
            "contoso_name": "BPF Inspection",
            "contoso_inspectionid": "18a57080-97ed-ed11-8848-0022481c5f83"
        }
      ]
     }
     ```

1. Create permit.

   - Select **POST**.
   - Enter the following in *Enter request URL*.

     ```odata
     {{webapiurl}}contoso_permits
     ```

   - Select the **Body** tab.

   - Select **raw** and select **JSON**.

   - Add the following JSON.

     ```json
     {
       "contoso_name":"Web API Permit",
       "contoso_newsize":1000,
       "contoso_startdate":"2023-12-12"
     }
     ```

     ![Postman create permit operation - screenshot](../images/L07/postman-create-permit.png)

   - Select **Send**.

   - You should see a status of 204.

   - Select the **Headers** tab in the response pane, and find the **OData-EntityId** header. This will contain the GUID of the permit record.
