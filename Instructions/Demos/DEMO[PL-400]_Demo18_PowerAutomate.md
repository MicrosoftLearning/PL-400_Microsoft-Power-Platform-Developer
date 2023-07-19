---
demo:
    title: 'Demo 18: Automated cloud flow'
    module: '5: Automate a business process using Power Automate'
---

# Demo 18 - Automated cloud flow

**Objective:** In this demo, you will show how to create a simple Power Automate cloud flow.

## Task 18.1 - Create a cloud flow

1. In the demo solution, create a new automated cloud flow.

1. Enter `New Pet` for Flow name.
1. Select the When a row is added, modified or deleted Microsoft Dataverse trigger.
1. Selected Added for Change type.
1. Select Pets for Table name.
1. Select Organization for Scope.
1. Rename the Trigger step to `Add Pet`.

1. Select + New Step.
1. Select the Microsoft Dataverse connector.
1. Select the List rows action.
1. Select Tricks for Table name.
1. Rename the step to `Get Tricks`.
1. Show advanced options.
1. Enter `dem_trickname eq 'Sleep'` - use one of the tricks you have used in place of Sleep.

1. Select + New Step.
1. Select the Data Operation connector.
1. Select the Compose action.
1. Rename the step to Trick.
1. Using Expressions, enter `first(outputs('Get_Tricks')?['body/value'])['dem_trickid']`

1. Select + New Step.
1. Select the Microsoft Dataverse connector.
1. Select the Add a new row action.
1. Select Pet Tricks for Table name.
1. Rename the step to `Add Pet Trick`.
1. Show advanced options.
1. Select Beginner for Level.
1. Enter `First Trick` for Name.
1. Enter `dem_pets()` for Pet.
1. Move the cursor inside the () and use Dynamic content to select Pet.
1. Enter 0 for Points.
1. Select New Trick for Status Reason.
1. Enter `dem_tricks()` for Tricks.
1. Move the cursor inside the () and use Dynamic content to select the Outputs from the Trick step.

## Task 18.2 - Test the cloud flow

1. Create a Pet record in the model-driven app.

1. Show the test run history.
