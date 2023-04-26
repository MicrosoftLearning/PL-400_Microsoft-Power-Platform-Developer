---
lab:
    title: 'Lab 5: Power Automate'
    module: 'Module 4: Automate a business process using Power Automate'
---

# Practice Lab 5 - Power Automate

## Scenario

Create Power Automate cloud flows.

## Exercise 1: Create a scheduled cloud flow

**Objective:** In this exercise, you will create a cloiud flow that resets all inspections to Pending.

### Task 1.1: Create scheduled flow

- Create a monthly scheduled cloud flow that retrieves all non-Pending Inspections
- Use Apply to each Loop 
- Update Inspection row and set Status Reason to Pending
- Run the flow

## Exercise 2: Create an instant cloud flow

**Objective:** In this exercise, you will create a cloud flow that is run from a canvas app.

### Task 2.1: Create instant flow for Power Apps

- Create an instant cloud flow using the Power Apps connector
- Add Update a row action for Inspections table
- Add Ask in PowerApps to Row ID
- Add a text input parameter for Inspection ID GUID
- Clear the comments column of the Inspection row using null Expression
- Add Get a row by ID action and retrieve the Permit row using Permit (Value)
- Add PowerApps Respond to a PowerApp or flow action
- Pass back the Permit’s Start Date as an output parameter

### Task 2.2: Call flow from the canvas app

- Edit the Inspections canvas app and add the flow to the app
- Add a button to the Details screen in the canvas app
- In the OnSelect property of the button, Run the cloud flow passing in the GUID of the Inspection
- Set a variable to the Permit Start Date from the response

      Set(ScheduledDate, ClearInspectionComments.Run('Inspection List'.Selected.Inspection).startdate)

## Exercise 3: Business process flow

**Objective:** In this exercise, you will create a business process flow.

### Task 3.1: Create business process flow for Build Site

Create a Business Process flow for the Build Site table with the following stages and steps

- Stage 1: New Build Site with data steps for Street Address, City, State, Postal Code, Country
- Stage 2: Initial Permit on Permit table with data steps Build Site, Name, Contact, Start Date, Permit Type
- Stage 3: Initial Inspection on Inspection Table with data steps Permit, Name, Inspection Type, Scheduled Date

> [!NOTE]
> All data steps should be required
