---
demo:
    title: 'Demo 8: Model-driven app forms'
    module: '2: Create model-driven apps'
---

# Demo 8 - Model-driven app forms

**Objective:** In this demo, you will show how to edit model-driven app forms.

## Task 8.1 - Tour of model-driven app form designer

Take a tour of a model-driven app form designer and show:

- Form structure: Tabs, sections, components
- Components tab
- Table columns tab
- Tree view tab

## Task 8.2 - Customize Pet main form

1. Edit the Main form for the Pet table.

1. Change the General tab to be 3-columns.
1. Add the Timeline control to the middle column section.
1. Change the name of the right-hand column section to Related.
1. Drag the Owner field to the Header.
1. Add the following columns to the general section:
   - Species
   - Date of birth
   - Pet owner
1. Add a new 1-column section to the left-hand column.
1. Change the name of the new section to Details.
1. Add the Currency and Pet Value fields to the new section.
1. Add a Quick View control to the Related section, selecting the Pet Owner (Contact) lookup and the Account contact card.

## Task 8.3 - Add sub-grid for Pet Tricks

1. In the Pet Main form, add a 1-column tab.

1. Change the name of the tab to Tricks.
1. Add a Subgrid control to the new section, selecting the Pet Tricks table.

## Task 8.4 - Quick View form

1. Edit the Quick View form for the Pet table.

1. Hide the Owner field.
1. Add the following columns:
   - Species
   - Pet owner

## Task 8.5 - Customize Trick main form

1. Edit the Main form for the Trick table.

1. Add the following columns to the general section:
   - Points

## Task 8.6 - Customize Pet Trick main form

1. Edit the Main form for the Pet Trick table.

1. Drag the Owner field to the Header.
1. Add the Status Reason column to the Header.
1. Add the following columns to the general section:
   - Pet
   - Trick
   - Level
   - Points
1. Change the General tab to be 2-columns.
1. Add a Quick View control to the Related section, selecting the Pet lookup.

## Task 8.7 - Quick Create form for Trick table

1. Enable the Trick table for Quick Create by checking **Leverage quick-create form if available**.

1. Create a Quick Create form for the Trick table and include the columns:
   - Trick name
   - Points
1. Hide the labels on the form.
