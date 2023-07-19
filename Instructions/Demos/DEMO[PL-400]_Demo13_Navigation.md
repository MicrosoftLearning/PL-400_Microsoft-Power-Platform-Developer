---
demo:
    title: 'Demo 13: Add navigation to canvas app'
    module: '3: Create canvas apps'
---

# Demo 13 - Add navigation to canvas app

**Objective:** In this demo, you will show how to add navigation between screens in a canvas app.

## Task 13.1 - Add screen and navigation

1. In the demo solution, edit the Pet Training canvas app.

1. Add a Blank Screen.
1. Rename to `DetailScreen`.
1. Copy and Paste MainHeader from MainScreen to DetailScreen and rename as `DetailHeader` and change Text to `PetList.Selected.'Pet Name'`.
1. In the PetList gallery, set OnSelect to `Navigate(DetailScreen)`.
1. Add Left icon to top left of DetailScreen and set OnSelect to `Back()`.
1. Demonstrate selecting a Pet and using the Back button.
