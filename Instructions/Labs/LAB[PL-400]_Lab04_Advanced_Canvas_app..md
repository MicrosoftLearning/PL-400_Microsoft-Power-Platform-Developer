---
lab:
    title: 'Lab 4: Advanced canvas app techniques'
    module: 'Module 3: Master advanced techniques and data options in canvas apps'
---

# Practice Lab 4 –  Advanced canvas app techniques

## Scenario

Customize the canvas app to use variables and the Patch formula.

## Exercise 1: Create Canvas App

**Objective:** In this exercise, you will connect to Office 365 Users and set a variable in OnStart.

### Task 1.1: Set variable in OnStart

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.
1. Make sure you are in the Development environment.
1. Select **Solutions**.
1. Open the **Permit Management** solution.
1. Edit the **Inspector** canvas app.
1. Select the **Data** tab.
1. Click **+ Add data**.
1. Expand **Connectors**.
1. Select **Office365Users**.
1. Click **Connect**.
1. Select **Tree view**.
1. Select the **App** object
1. In the property selector, select **OnStart**.
1. In the formula bar, enter

   ```powerappsfl
   Set(currentuser,Office365Users.MyProfile())
   ```

1. Select the ellipses (...) and select **Run OnStart**
1. Select the **+ Insert** tab.
1. Click on **Text label**.
1. Drag the label to the top right of the screen.
1. Set the **Text** property

   ```powerappsfl
   currentuser.Country
   ```

1. Save the app.

## Exercise 2: Patch

**Objective:** In this exercise, you use Patch to update the Status Reason on an inspection.

### Task 2.1: Update inspection row using Patch

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.
1. Make sure you are in the Development environment.
1. Select **Solutions**.
1. Open the **Permit Management** solution.
1. Edit the **Inspector** canvas app.
1. Select **Tree view**.
1. Select the **Details** screen.
1. Select the **+ Insert** tab.
1. Click on **Button**.
1. Drag the label to the bottom of the screen.
1. Set the **Text** property to **"Failed"**.
1. In the property selector, select **OnSelect**.
1. In the formula bar, enter

   ```powerappsfl
   Patch(Inspections, 'Inspection List'.Selected, {'Status Reason':'Status Reason (Inspections)'.Failed})
   ```

1. Save the app.
