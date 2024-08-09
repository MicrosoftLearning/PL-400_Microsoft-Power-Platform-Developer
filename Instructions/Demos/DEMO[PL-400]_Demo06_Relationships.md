---
demo:
    title: 'Demo 6: Relationships in canvas apps'
    module: '1: Advanced techniques in canvas apps'
---

# Demo 6 - Relationships in canvas apps

**Objective:** In this demo, you will show how to use relational data in an canvas app.

## Task 6.1 - List related rows in a one-to-many relationship

1. In the demo solution, edit the Pet Training canvas app.

1. Select the MainScreen.

1. Add a gallery.
   - Add a vertical gallery control
   - Select the Pet Ticks table
   - Rename the gallery to `PetTrickList`
   - Change layout to Title, Subtitle and Body
   - Change fields to Name, Pet Trick, and Level
   - Set X to PetList.Width
   - Set Y to PetList.Y
   - Set Width to Parent.Width / 3
   - Set Height = Parent.Height - MainHeaderRect.Height

1. Filter Pet Tricks
   - Select the PetTrickList gallery
   - Set the Items property to `Filter('Pet Tricks', Pet.Pet = PetList.Selected.Pet)`.

## Task 17.2 - Display related row column in a many-to-one relationship

1. Display the Trick Name
   - Select the field in the gallery that shows the Pet Trick GUID.
   - Change the Text property to `ThisItem.Trick.'Trick Name'`.
