---
lab:
    title: 'Lab 6: Power Platform tools'
    module: 'Module 5: Introduction to developing with Power Platform'
---

# Practice Lab 6 - Power Platform tools

## Scenario

- Install Power Platform CLI
- Copy reference data by using Configuration Migration tool from Development to Live
- Create a FetchXml query using XrmToolBox
- Install Postman

## Exercise 1: Power Platform CLI

**Objective:** In this exercise, you will install the Power Platform CLI.

### Task 1.1: Download and install Power Platform CLI

1. Download [Power Platform CLI](https://aka.ms/PowerAppsCLI).

1. Run the **powerapps-cli-1.0.msi** to start the installation.
  
1. Use the setup wizard to complete the setup and select **Finish**.

1. Open the Command Prompt.

1. Run the command **pac install latest**.

1. Run the command **pac tool list**.

## Exercise 2: Configuration Migration Tool

**Objective:** In this exercise, you will copy reference data between environments.

### Task 2.1: Export data

1. Open the Command Prompt.

1. Run the command **pac tool cmt**.

1. Select **Create schema** and select **Continue**.

1. Select **Office 365** for Deployment Type.

1. Check **Display list of available organizations**.

1. Check **Show Advanced**.

1. Enter you tenant credentials.

1. Click **Login**.

1. Select your **Development** environment and click **Login**.

1. Select the **Permit Management** solution.

1. Select **Build Site** table.

1. Select **Build Site, City, Country/Region, State/Province, Street Address, ZIP/Postal Code** columns.

1. Click **Add Fields**.

1. Select **Permit Type** table.

1. Select **Permit Type, Require Inspections, Require Size** columns.

1. Click **Add Fields**.

1. Click **Save and Export**.

1. Enter **permit.xml** and click **Save**.

1. Select **Yes** to export the data.

1. Click the ellipses (...) next to **Save to data file**.

1. Enter **permitdata.zip**.

1. Click **Save**.

1. Click **Export Data**.

1. Click **Exit**.

### Task 2.2: Import data

1. Open the Command Prompt.

1. Run the command **pac tool cmt**.

1. Select **Import data** and select **Continue**.

1. Select **Office 365** for Deployment Type.

1. Check **Display list of available organizations**.

1. Check **Show Advanced**.

1. Enter you tenant credentials.

1. Click **Login**.

1. Select your **Live** environment and click **Login**.

1. Click the ellipses (...) next to **Zip File**.

1. Select the **permitdata.zip** file you created in the previous task and click **Open**.

1. Click **Import Data**.

1. Click **Exit**.

1. Close the Configuration Migration Tool window.

## Exercise 3: Community tools

**Objective:** In this exercise, you will use FetchXmlBuilder in the XrmToolBox to find inspections with status reason New request or Pending.

### Task 3.1: Install XrmToolBox

1. Navigate to [XrmToolBox](https://www.xrmtoolbox.com).

1. Download **XrmToolBox** and extract the files.

1. Run **XrmToolBox.exe**

1. Select **Open Tool Library**.

1. Search for **fetchxml**, select **FetchXMLBuilder** and select **Install**.

### Task 3.2: FetchXML query

1. Select the **Tools** tab.

1. Search for **fetchxml** and select **FetchXMLBuilder**.

1. Select **Yes** to connect to an organization.

1. Select **New connection**.

1. Select **Microsoft Login Control**.

1. Click **Open Microsoft Login Control**.

1. Select **Office 365** for Deployment Type.

1. Check **Display list of available organizations**.

1. Check **Show Advanced**.

1. Enter you tenant credentials.

1. Click **Login**.

1. Select your **Development** environment and click **Login**.

1. Enter **Dev** and click **Finish**.

1. Click on the **(entity)** node.

1. Select **contoso_inspection** in the Entity name drop down.

1. Click on **filter**.

1. Select **statuscode** in the Attribute drop down.

1. Select **Equal** in the Operator drop down.

1. Select **New Request** in the Value drop down.

1. Click on **+condition**.

1. Select **statuscode** in the Attribute drop down.

1. Select **Equal** in the Operator drop down.

1. Select **Pending** in the Value drop down.

1. Click on the **filter** node.

1. Select **or** in the Filter type drop down.

1. Click **Execute (F5)**.

## Exercise 4: Postman

**Objective:** In this exercise, you will install Postman.

### Task 4.1: Register Azure AD Application

1. Download [Postman](https://www.postman.com/downloads)

1. Run the Postman installer.

1. Click **Skip and go to the app**.
