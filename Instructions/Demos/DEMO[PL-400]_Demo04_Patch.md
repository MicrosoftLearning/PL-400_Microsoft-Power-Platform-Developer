---
demo:
    title: 'Demo 4: Use patch in canvas app'
    module: '1: Advanced techniques in canvas apps'
---

# Demo 4 - Use formulas in canvas app

**Objective:** In this demo, you will show how to use the Patch formula in a canvas app to create and update a Pet Trick.

## Task 4.1 - Add controls to form

1. In the demo solution, edit the Pet Training canvas app.

1. Select the DetailScreen.

1. Add list for Tricks.

   - Add a Drop down control.
   - Rename to `TrickDD`.
   - Set Items to `Tricks`.

1. Add list for Level.

   - Add a Drop down control.
   - Rename to `LevelDD`.
   - Set Items to `Choices('Skill level')`.

1. Add field for Points.
   - Add a Text input control.
   - Rename to `Points`.
   - Set Default to `"10"`.

## Task 4.2 - Patch formulas

1. Add a button to Create a new Pet Trick.
   - Add a button.
   - Rename to `CreateButton`.
   - Set Text to `Create`.
   - Set OnSelect to `Set(varId,Patch('Pet Tricks',Defaults('Pet Tricks'),{Pet:PetList.Selected,Name:"New Trick",Level:LevelDD.Selected.Value,Trick:TrickDD.Selected,Points:Int(Points.Text)}))`.

1. Add a button to Update a Pet Trick.
   - Add a button.
   - Rename to `UpdateButton`.
   - Set Text to `Training`.
   - Set OnSelect to `Patch('Pet Tricks',varId,{ 'Status Reason': 'Status Reason (Pet Tricks)'.Training})`.
