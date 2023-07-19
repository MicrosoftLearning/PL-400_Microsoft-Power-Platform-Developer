---
demo:
    title: 'Demo 14: Use formulas in canvas app'
    module: '3: Create canvas apps'
---

# Demo 14 - Use formulas in canvas app

**Objective:** In this demo, you will show how to use formulas, collections, and variables in a canvas app.

## Task 14.1 - OnStart property

1. In the demo solution, edit the Pet Training canvas app.

1. In the App's OnStart property enter `Set (userprofile, User()); Clear(selectedRecords);`.
1. Add a Text label and move to top right of screen.
1. Set the label's Text property to `userprofile.FullName`.

## Task 14.2 - Collection

1. In the OnSelect property for the PetList gallery replace with `Collect(selectedRecords, ThisItem);Navigate(DetailScreen);`

1. Run App.OnStart.
1. Preview the app.
1. Select a row from the gallery.
1. Select Back and select another row.
1. Close the Preview
1. Show the Collection
