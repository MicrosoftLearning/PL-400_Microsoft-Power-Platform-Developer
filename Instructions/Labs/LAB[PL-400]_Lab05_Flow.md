---
lab:
    title: 'Lab 5: Power Automate'
    module: 'Module 4: Automate a business process using Power Automate'
---

# Practice Lab 5 - Power Automate

## Scenario

Create Power Automate cloud flows.

## Exercise 1: Create a scheduled cloud flow

**Objective:** In this exercise, you will create a cloud flow that resets all inspections to Pending.

### Task 1.1: Create scheduled flow

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.
1. Make sure you are in the Development environment.
1. Select **Solutions**.
1. Open the **Permit Management** solution.

1. Click **+New** and then select **Automation** > **Cloud flow** > **Scheduled**.
1. Enter Flow name as ***Reset Inspections**.
1. Change Minute drop-down to **Month**.
1. Click **Create**.
1. Click **+New step**.
1. Select the **Microsoft Dataverse** connector.
1. Select the **List rows** action.
1. Select the **Inspections** table.
1. Click **Show advanced options**.
1. In **Filter rows**, enter

   ```odata
   statuscode ne 330650000
   ```

1. Click **+ New step**.
1. Select the **Control** connector.
1. Select the **Apply to each** action.
1. Click in **Select an output from previous steps**.
1. Using **Dynamic content**, select **value**.

1. Click **+ Add an action**.
1. Select the **Microsoft Dataverse** connector.
1. Select the **Update a row** action.
1. Select the **Inspections** table.
1. Click in **Row ID**.
1. Using **Dynamic content**, select **Inspection**.
1. Click **Show advanced options**.
1. In **Status Reason**, select **Pending**.
1. Click **Save**.

### Task 1.2: Run flow

1. Click **Test**.
1. Select **Manually**.
1. Click **Test**.
1. Click **Run flow**.
1. Click **Done**.

## Exercise 2: Create an instant cloud flow

**Objective:** In this exercise, you will create a cloud flow that is run from a canvas app.

### Task 2.1: Create instant flow

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.
1. Make sure you are in the Development environment.
1. Select **Solutions**.
1. Open the **Permit Management** solution.

1. Click **+New** and then select **Automation** > **Cloud flow** > **Instant**.
1. Enter Flow name as ***ClearInspectionComments**.
1. Select **PowerApps**.
1. Click **Create**.

1. Click **+ New step**.
1. Select the **Microsoft Dataverse** connector.
1. Select the **Update a row** action.
1. Select the **Inspections** table.
1. Rename the step as **CancelComments**.
1. Click in **Row ID**.
1. Select **Ask in PowerApps**.
1. Click **Show advanced options**.
1. Click in **Comments**.
1. Select the **Expression** tab.
1. Enter **null** and click **OK**.

1. Click **+ New step**.
1. Select the **Microsoft Dataverse** connector.
1. Select the **Get a row by ID** action.
1. Select the **Permits** table.
1. Click in **Row ID**.
1. Using **Dynamic content**, select **Permit (Value)**.

1. Click **+N ew step**.
1. Select the **PowerApps** connector.
1. Select the **PowerApps Respond to a PowerApp or flow** action.
1. Select **+ Add an output**.
1. Select **Date**.
1. Click in Enter title and enter **startdate**.
1. Click in Enter a value to respond.
1. Using **Dynamic content**, select **Start Date**.
1. Click **Save**.

### Task 2.2: Call flow from the canvas app

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.
1. Make sure you are in the Development environment.
1. Select **Solutions**.
1. Open the **Permit Management** solution.
1. Edit the **Inspector** canvas app.

1. Select the **Power Automate** tab.
1. Click **+ Add flow**.
1. Select **ClearInspectionComments**.

1. Select **Tree view**.
1. Select the **Details** screen.
1. Select the **+ Insert** tab.
1. Click on **Button**.
1. Drag the label to the bottom of the screen.
1. Set the **Text** property to **"Clear Comments"**.
1. In the property selector, select **OnSelect**.
1. In the formula bar, enter

   ```powerappsfl
   Set(ScheduledDate, ClearInspectionComments.Run('Inspection List'.Selected.Inspection).startdate)
   ```

1. Select the **+ Insert** tab.
1. Click on **Text label**.
1. Drag the label to the top right of the screen.
1. Set the **Text** property to

   ```powerappsfl
   ScheduledDate
   ```

1. Save the app.

## Exercise 3: Business process flow (Optional)

**Objective:** In this exercise, you will create a business process flow.

### Task 3.1: Create business process flow for Build Site

Create a Business process flow for the Build Site table with the following stages and steps

- Stage 1: New Build Site with data steps for Street Address, City, State, Postal Code, Country
- Stage 2: Initial Permit on Permit table with data steps Build Site, Name, Contact, Start Date, Permit Type
- Stage 3: Initial Inspection on Inspection Table with data steps Permit, Name, Inspection Type, Scheduled Date

> [!NOTE]
> All data steps should be required

> [!IMPORTANT]
> You will need to add the Business process flow table to the solution
