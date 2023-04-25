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

- Edit the Inspector canvas app
- Add connection to Office365Users
- Set variable currentuser in App OnStart to Office365User.MyProfile()

```powerappsfl
  Set(currentuser,Office365Users.MyProfile())
```

- Run App OnStart
- Add a label to the Main Screen and set the Text property to currentuser.Country

## Exercise 2: Patch

**Objective:** In this exercise, you use Patch to update the Status Reason on an inspection.

### Task 2.1: Update inspection row using Patch

- Add a button to the Detail Screen
- Set the button’s text property to “Failed”
- In the button’s OnSelect property use Patch to update Inspection row and set Status Reason to Failed

```powerappsfl
   Patch(Inspections, 'Inspection List'.Selected, {'Status Reason':'Status Reason (Inspections)'.Failed})
```
