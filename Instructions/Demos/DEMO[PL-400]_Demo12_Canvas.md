---
demo:
    title: 'Demo 12: Create canvas app'
    module: '3: Create canvas apps'
---

# Demo 12 - Create canvas app

**Objective:** In this demo, you will show how to create a canvas app and display a list of records from a Dataverse table.

## Task 12.1 - Create an app with a gallery of Pets

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
