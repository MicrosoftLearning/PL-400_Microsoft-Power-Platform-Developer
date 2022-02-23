---
lab:
    title: 'Lab 09: Custom Connector'
---

> [!NOTE]
> Effective November 2020:
> - Common Data Service has been renamed to Microsoft Dataverse. [Learn more](https://aka.ms/PAuAppBlog)
> - Some terminology in Microsoft Dataverse has been updated. For example, *Table* is now *table* and *Column* is now *column*. [Learn more](https://go.microsoft.com/fwlink/?linkid=2147247)
>
> This content will be updated soon to reflect the latest terminology.


## Lab 09 – Custom Connector

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course you will build applications and automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow. 

In this lab you will build a custom connector that can be used from Power Apps and Power Automate. Custom connectors describe existing APIs and allow them to be used easily. In this lab, you will build an API that has common calculations used by inspectors so that they can be used by applications. After building the API, you will create a custom connector definition to make it available to Power Apps and Power Automate.

The connector could have multiple actions defined on it. However, for our lab we will define a single action **Get Required CPM** – where CPM stands for Cubic <N> Per Minute. In some regions this would be Cubic Feet Per Minute, and in others it could be Cubic Meters Per Minute. The action we are building will take the dimensions of a room and the number of air exchanges required by policy. The action logic will calculate the required CPM for that configuration. If you want, you can add additional actions to support other inspection type scenarios to the API and the custom connector. 

After building the API and the custom connector you will modify the inspector app to add the user experience to use the connector. You will use the same connector and invoke an action from Power Automate.

# High-level lab steps

As part of configuring the custom connector, you will complete the following

- Create an Azure function that implements the CPM API

- Create a custom connector in a solution

- Configure the security and actions on the custom connector

- Test the custom connector

- Configure a Power Apps canvas app to use the connector

- Configure a Power Automate to use the connector

## Things to consider before you begin

- Is there a standard approved connector already available that can be used?

- What security will we use in our connector?

- What are possible triggers and actions of the connector? 

- Are there any API rate limits that could potentially affect the connector?

 

# Exercise #1: Create the Azure Function

**Objective:** In this exercise, you will create an Azure function app and the function that will calculate the CPM.

## Task #1: Create CPM Calculation Function

1. Create the function app

	- Sign in to [Azure portal](https://portal.azure.com/)

	- Click **Create a Resource**.

    ![Create new resource - screenshot](../L09/Static/Mod_2_Custom_Connector_image1.png)

	- Search for **Function** and select **Function App**.

    ![Select function app - screenshot](../L09/Static/Mod_2_Custom_Connector_image2.png)

	- Click **Create**.

    ![Create function app - screenshot](../L09/Static/Mod_2_Custom_Connector_image3.png)

	- Enter **CPMCalculator** for **App Name**. Provide a unique name, if CPMCalculator is not available.

	- Create **New Resource Group**. You may select an existing Resource Group if you already created one for this course.

	- Select **.NET Core** for **Runtime Stack**, select your **Region** and click **Review + Create**.

 

    ![Create review function application - screenshot](../L09/Static/Mod_2_Custom_Connector_image4.png)

	- Click **Create**. Wait for the function app to be created

2. Create function

	- Click **Go to Resource**.

    ![Go to resource - screenshot](../L09/Static/Mod_2_Custom_Connector_image5.png)

	- Select **Functions** and click **+ Add**.

    ![Add function - screenshot](../L09/Static/Mod_2_Custom_Connector_image6.png)

	- Select **HTTP trigger**.

	- Click **Create Function.**

3. Add the **Using Statements** and **CRMCalcRequest** class to the function.

	- Select **Code + Test**.

    ![Code and test - screenshot](../L09/Static/Mod_2_Custom_Connector_image7.png)

	- Add the Using Statements below to the function.

            using Microsoft.Extensions.Logging;
            using Newtonsoft.Json.Linq;

    ![Add using statements - screenshot](../L09/Static/Mod_2_Custom_Connector_image8.png)

	- Add the public class below to the function. This will describe the request that will be sent from the applications using the API.

            public class CPMCalcRequest
            {
                public int Width=0;
                public int Height=0;
                public int Length=0;
                public int AirChanges=0;
            }

    ![Add class - screenshot](../L09/Static/Mod_2_Custom_Connector_image9.png)

4. Clean up the Run method

	- Go to the **Run** method.

	- Remove everything but the log line from the **Run** method.

    ![Edit run method - screenshot](../L09/Static/Mod_2_Custom_Connector_image10.png)

5. Get the Request body and deserialize it as **CRMCalcRequest**

	- Get the request **Body** from the request argument. Add the code below inside the **Run** method.

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

	- Deserialize the request body. Add the code below inside the **Run** method.

            CPMCalcRequest calcReq = JsonConvert.DeserializeObject<CPMCalcRequest>(requestBody);

    ![Add code to run method - screenshot](../L09/Static/Mod_2_Custom_Connector_image11.png)

6. Calculate the CPM and return it form the Run method

	- Calculate the **CPM** and log the calculated value. Add the code below inside the **Run** method.

            var cpm = ((calcReq.Width*calcReq.Height*calcReq.Length) * calcReq.AirChanges) / 60;
            log.LogInformation("CPM " + cpm);

	- Return the calculated **CPM**. Add the code below inside the Run method.

            return (ActionResult)new OkObjectResult(new{
                CPM = cpm
            });

    ![Updated run method - screenshot](../L09/Static/Mod_2_Custom_Connector_image12.png)

7. Click **Save** to save your changes.

8. Copy the Function URL.

	- Click **Get Function URL**.

    ![Get function URL - screenshot](../L09/Static/Mod_2_Custom_Connector_image13.png)

	- Click **Copy**.

    ![Copy function URL - screenshot](../L09/Static/Mod_2_Custom_Connector_image14.png)

	- Keep the URL you copied on a notepad. You will need this URL while creating the custom connector.

# Exercise #2: Create the Custom Connector

**Objective:** In this exercise, you will create the Custom Connector. This same approach could be used to describe any existing API you create or that has been created by any 3<sup data-htmlnode="">rd</sup> parties and an existing connector for that service is unavailable. 

## Task #1: Create the Custom Connector

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you are in the **Dev** environment.

	- Select **Solutions**.

	- Click to open the **Permit Management** solution.

    ![Open solution - screenshot](../L09/Static/Mod_2_Custom_Connector_image15.png)

2. Create Custom Connector

	- Click **+ New**.

    ![Create new component - screenshot](../L09/Static/Mod_2_Custom_Connector_image16.png)

	- Select **Automation| Custom Connector**.

    ![Create new custom connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image17.png)

	- Change the **Connector** **Name** from **Untitled** to **CPM Calculator**.

    ![Rename custom connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image18.png)

	- Locate the **Host** Column and paste the **Function URL** you copied in Exercise 1.

	- Remove https:// and everything after .net. 

    ![Paste host URL - screenshot ](../L09/Static/Mod_2_Custom_Connector_image19.png)

3. Select API key for security and create the connector

	- Advance to **Security**.

    ![Select security - screenshot ](../L09/Static/Mod_2_Custom_Connector_image20.png)

	- Select **API Key**.

    ![Select API key - screenshot](../L09/Static/Mod_2_Custom_Connector_image21.png)

	- Enter **API Key** for **Parameter Label**, **code** for **Parameter Name**, and select **Query** for **Parameter Location**.

    ![API key - screenshot](../L09/Static/Mod_2_Custom_Connector_image22.png)

4. Create Connector

	- Advance to **Definition**.

    ![Definition - screenshot](../L09/Static/Mod_2_Custom_Connector_image23.png)

	- Click **Create Connector** and wait for the connector to be created.

    ![Create connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image24.png)

5. Create Action

	- Click **New Action**. The action describes each operation that the API has. These can be manually defined like we are doing here or can be imported from Open API or Postman collection files for larger APIs.

    ![Create new action - screenshot](../L09/Static/Mod_2_Custom_Connector_image25.png)

	- Enter **CPM Calculator** for **Summary**, **Calculates CPM** for **Description**, and **GetRequiredCPM** for **Operation ID**.

    ![Action information - screenshot](../L09/Static/Mod_2_Custom_Connector_image26.png)

6. Import request from sample

	- Click **+ Import from Sample**.

    ![Import request from sample - screenshot](../L09/Static/Mod_2_Custom_Connector_image27.png)

	- Select **Post** for **Verb**.

	- Paste the function **URL** from your notepad and remove everything after **HttpTrigger1**.

    ![Paste URL - screenshot](../L09/Static/Mod_2_Custom_Connector_image28.png)

	- Paste the json below in the **Body** field and click **Import**.

            {
                "Width": 15,
                "Height": 8,
                "Length":20,
                "AirChanges":8
            }

    ![Import sample - screenshot](../L09/Static/Mod_2_Custom_Connector_image29.png)

7. Add Default response

	- Scroll down to the **Response** section and click **+ Add Default Response**.

    ![Add default response - screenshot](../L09/Static/Mod_2_Custom_Connector_image30.png)

	- Paste the json below in the **Body** and click **Import**.

            {"cpm":200}

    ![Import response - screenshot](../L09/Static/Mod_2_Custom_Connector_image31.png)

	- Click **Update Connector**.

    ![Update connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image32.png)

8. Test the connector

	- Advance to Test.

    ![Select test - screenshot](../L09/Static/Mod_2_Custom_Connector_image33.png)

	- Click **New Connection**. This will open a New window.

    ![New connection - screenshot](../L09/Static/Mod_2_Custom_Connector_image34.png)

	- Go to your notepad and copy only the value of the **code**.

    ![Copy key - screenshot](../L09/Static/Mod_2_Custom_Connector_image35.png)

	- Go back to the connector, paste the value you copied, and click **Create Connection**.

    ![Create connection - screenshot](../L09/Static/Mod_2_Custom_Connector_image36.png)

	- Refresh the connections and select newly created connection.

	- Provide values for **Width**, **Height**, **Length**, and **AirChanges**.

	- Click **Test Operation**.

    ![Test operation - screenshot](../L09/Static/Mod_2_Custom_Connector_image37.png)

	- You should get a CPM value back.

    ![Response value - screenshot](../L09/Static/Mod_2_Custom_Connector_image38.png)

	- Close the window and go back to Solution window and click **Done.**

	- Click **Publish all Customizations.**

 

  
‎ 

# Exercise #3 Test Connector 

**Objective:** In this exercise, you will use the Custom Connector from a Power 9Apps canvas app and a Power Automate.

## Task #1: Test on Canvas App

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you are in the **Dev** environment.

	- Select **Solutions.**

	- Click to open the **Permit Management** solution.

2. Open the Inspector canvas application in edit mode

	- Locate the **Inspector Canvas App**.

	- Click on the **… More Commands** button and select **Edit**. This will open the app in a New window.

    ![Edit application - screenshot](../L09/Static/Mod_2_Custom_Connector_image39.png)

3. Add new screen to the application

	- Click **New Screen** and select **Blank**.

    ![New blank screen - screenshot ](../L09/Static/Mod_2_Custom_Connector_image40.png)

	- Rename the screen **CPM Calc Screen**

    ![Rename screen - screenshot](../L09/Static/Mod_2_Custom_Connector_image41.png)

4. Add Input Text to the new screen

	- Select the **CPM Calc Screen**.

	- Click **Insert**.

    ![Insert button screenshot](../L09/Static/Mod_2_Custom_Connector_image42.png)

	- Drag and drop **Text Input** to the screen.

    ![Add control to screens - screenshot ](../L09/Static/Mod_2_Custom_Connector_image43.png)

	- Select the **Tree View**.

    ![Select tree view - screenshot](../L09/Static/Mod_2_Custom_Connector_image44.png)

	- Rename the Text Input **Width Text**.

	- Remove the **Default** property of the **Width** text input.

    ![Remove default value - svreenshot](../L09/Static/Mod_2_Custom_Connector_image45.png)

	- Change the **HintText** property of the **Width** text input to **Provide Width**.

    ![Provide hint text - screenshot](../L09/Static/Mod_2_Custom_Connector_image46.png)

	- The **Width Text** input should now look like the image below.

    ![Width text - screenshot](../L09/Static/Mod_2_Custom_Connector_image47.png)

5. Add Height, Length, and Air Change Input Text controls

	- Copy the **Width Text**.

    ![Copy input text - screenshot](../L09/Static/Mod_2_Custom_Connector_image48.png)

	- Paste the text input you copied to the **CPM Calc Screen.**

    ![Paste text input - screenshot](../L09/Static/Mod_2_Custom_Connector_image49.png)

	- Paste the text input you copied to the **CPM Calc Screen** two more times.

	- The **CPMCalcScreen** should now have total of four text inputs.

    ![Text input controls - screenshot](../L09/Static/Mod_2_Custom_Connector_image50.png)

	- Rename the input text controls **Height Text**, **Length Text**, and **Air Change Text**.

    ![Rename controls - screenshot](../L09/Static/Mod_2_Custom_Connector_image51.png)

	- Change the **HintText** for the three text inputs you renamed to **Provide Height**, **Provide Length**, and **Provide Air Change**, respectively.

	- Resize and reposition the text inputs as shown in the image below.

    ![Input text control layout - screenshot](../L09/Static/Mod_2_Custom_Connector_image52.png)

6. Add button

	- Go to the **Insert** tab and click Button.

    ![Insert button - screenshot](../L09/Static/Mod_2_Custom_Connector_image53.png)

	- Rename the Button **Calculate Button**.

	- Change the **Calculate Button Text** value to **Submit**.

	- Resize and reposition the button as shown in the image below.

    ![Reposition button - screenshot](../L09/Static/Mod_2_Custom_Connector_image54.png)

7. Add the result label to the screen

	- Go to the **Insert** tab and click Label

	- Rename the Label **Result Label**.

	- Place the label to the right of the text inputs.

    ![Control layout - screenshot](../L09/Static/Mod_2_Custom_Connector_image55.png)

8. Add the Custom Connector to the application.

	- Select the **Data Sources** tab.

	- Expand **Connectors**.

	- Click the **CPM Connector**.

    ![CPM Calculator connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image56.png)

	- Click **CPM Calculator** again.

    ![Select CPM Calculator connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image57.png)

	- The **CPM Calculator** should now be listed in the **In your App** section.

    ![Added connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image58.png)

9. Get the calculated value when the button is clicked

	- Select the **Calculate Button**.

	- Set the **OnSelect** value of the **Calculate Button** to the formula below.

            Set(CalculatedValue, Concatenate("Calculated CPM ", Text(Defaulttitle.GetRequiredCPM({Width: 'Width Text'.Text, Height: 'Height Text'.Text, Length: 'Length Text'.Text, AirChanges: 'Air Change Text'.Text}).cpm)))

    ![On-Select formula - screenshot](../L09/Static/Mod_2_Custom_Connector_image59.png)

	- Select the **Result Label** and set the **Text** value to the **CalculatedValue** variable.

    ![Label text value - screenshot](../L09/Static/Mod_2_Custom_Connector_image60.png)

10. Add navigation button to the Main screen

	- Select the **Main Screen**.

	- Go to the **Insert** tab and click **Button**.

	- Rename the Button **CPM Button**.

	- Change the **CPM Button** **Text** value to **CPM Calculator**.

	- Place the button on the bottom right of the **Main Screen**.

 

11. Steps to navigate to the CPM Calc Screens

	- Select the **CPM Calculator**.

	- Set the **OnSelect** value of the **CPM Calculator** to the formula below.

            Set(CalculatedValue, ""); Navigate('CPM Calc Screen', ScreenTransition.None)

    ![On-Select formula - screenshot](../L09/Static/Mod_2_Custom_Connector_image61.png)

12. Run the Application

	- Select the **Main Screen** and click **Preview the App**.

    ![Preview app - screenshot](../L09/Static/Mod_2_Custom_Connector_image62.png)

	- Click on **CPM Calculator** button.

	- The CPM Calculator screen should load.

    ![Calculator page - screenshot](../L09/Static/Mod_2_Custom_Connector_image63.png)

	- Provide values and click **Submit**. You can notice the loading dots on top of the screen, which confirms that the request has been initiated.

    ![Submit form - screenshot](../L09/Static/Mod_2_Custom_Connector_image64.png)

	- The **Result Label** should show the calculated result from the Custom Connector.

    ![Calculation result - screenshot](../L09/Static/Mod_2_Custom_Connector_image65.png)

	- Close the Preview.

	- Click **File** and **Save**.

	- **Publish** the changes to the application.

	- Click **Close**.

Click **Done** on the other window for the solution.

 

## Task #2: Test on Flow

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/) and make sure you are in the **Dev** environment.

	- Select **Solutions**.

	- Click to open the **Permit Management** solution.

2. Create Flow and add trigger.

	- Click **New** and select **Flow**. This will open a New window.

    ![Create new flow - screenshot](../L09/Static/Mod_2_Custom_Connector_image66.png)

	- Search for **Manually** and select **Manually Trigger Flow**.

    ![Select trigger - screenshot](../L09/Static/Mod_2_Custom_Connector_image67.png)

3. Add a step that will use the Custom Connector

	- Click **+ New Step**.

    ![Add new step - screenshot](../L09/Static/Mod_2_Custom_Connector_image68.png)

	- Select the **Custom** tab and click **CPM Calculator**.

    ![Select custom connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image69.png)

	- Select **CPM Calculator** action.

    ![Select action - screenshot](../L09/Static/Mod_2_Custom_Connector_image70.png)

4. Provide values and save

	- Enter 18 for Width, 10 for Height, 18 for Length, 30 for AirChanges, and click **Save**.

    ![Save flow - screenshot](../L09/Static/Mod_2_Custom_Connector_image71.png)

5. Test the Flow

	- Click **Test**.

    ![Test connector - screenshot](../L09/Static/Mod_2_Custom_Connector_image72.png)

	- Select **I will Perform the Trigger** and click **Save &amp;** **Test**.

	- Click **Continue**.

    ![Continue with test - screenshot](../L09/Static/Mod_2_Custom_Connector_image73.png)

	- Click **Run Flow**.

	- Click **Done.** The Flow should run successfully. In the Flow run history, expand the CPM Calculator action. 

    ![Succeeded run - screenshot](../L09/Static/Mod_2_Custom_Connector_image74.png)

	- You should be able to see the calculated result from the custom connector in the output of the action.

    ![Result value - screenshot](../L09/Static/Mod_2_Custom_Connector_image75.png)

	- Close the window and go back to Solution window. Click **Done.** 

	- Click **Publish all Customizations.**

	- If you finish early, try adding input values to the Manual Button trigger for the room dimensions and use those to call the custom connector. You could also use the notification connector to send the user the required CPM. Finally, if you want to test this in a real device install the Power Automate mobile application.

    ![Flow using input values - screenshot](../L09/Static/Mod_2_Custom_Connector_image76.png)

 
