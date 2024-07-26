---
demo:
    title: 'Demo Setup 10: Create canvas app'
    module: '3: Create canvas apps'
---

# Demo setup instructions 10 - Create canvas app

## Task 10.1 - Create an app with a gallery of Pets

**Objective:** In this demo, you will show how to create a canvas app and display a list of records from a Dataverse table.

1. In the demo solution, create a blank tablet canvas app named, `Pet Training`.

1. Rename Screen1 to `MainScreen`.
1. Add a header.
   - Add a rectangle control
   - Rename to `MainHeaderRect
   - Set Fill Color to Color.Green
   - Set X=0 and Y=0
   - Set Width=Parent.Width
   - Set Height = Parent.Height / 10
1. Add label for App title.
   - Add a text label control
   - Rename to `MainHeaderLabel`
   - Set Text to `"Pet Training"`
   - Set Color to Color.White
   - Set X=0 and Y=0
   - Set Width=Parent.Width
   - Set Height = Parent.Height / 10
   - Align Center
   - Set Size to 28
1. Group rectangle and label and rename as `MainHeader`.
1. Add the Pets, Skills, and Pet Tricks Dataverse tables to the app.
1. Add a gallery.
   - Add a vertical gallery control
   - Select the Pets table
   - Select the Active Pets view
   - Rename the gallery to `PetList`
   - Change layout to Title and Subtitle
   - Change fields to Pet Name and Species
   - Set X to MainHeaderRect.X
   - Set Y to MainHeaderRect.Height
   - Set Width to Parent.Width / 6
   - Set Height = Parent.Height - MainHeaderRect.Height

## Task 10.2 - Add screen and navigation

**Objective:** In this demo, you will show how to add navigation between screens in a canvas app.

1. In the demo solution, edit the Pet Training canvas app.

1. Add a Blank Screen.
1. Rename to `DetailScreen`.
1. Copy and Paste MainHeader from MainScreen to DetailScreen and rename as `DetailHeader` and change Text to `PetList.Selected.'Pet Name'`.
1. In the PetList gallery, set OnSelect to `Navigate(DetailScreen)`.
1. Add Left icon to top left of DetailScreen and set OnSelect to `Back()`.
1. Demonstrate selecting a Pet and using the Back button.

## Task 10.3 - OnStart property

**Objective:** In this demo, you will show how to use formulas, collections, and variables in a canvas app.

1. In the demo solution, edit the Pet Training canvas app.

1. In the App's OnStart property enter `Set (userprofile, User()); Clear(selectedRecords);`.
1. Add a Text label and move to top right of screen.
1. Set the label's Text property to `userprofile.FullName`.

## Task 10.4 - Collection

1. In the OnSelect property for the PetList gallery replace with `Collect(selectedRecords, ThisItem);Navigate(DetailScreen);`

1. Run App.OnStart.
1. Preview the app.
1. Select a row from the gallery.
1. Select Back and select another row.
1. Close the Preview
1. Show the Collection
