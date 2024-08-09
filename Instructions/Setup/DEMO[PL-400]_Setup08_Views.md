---
demo:
    title: 'Demo Setup 8: Model-driven app views'
    module: '2: Create model-driven apps'
---

# Demo setup instructions 8 - Model-driven app views

**Objective:** In this demo, you will show how to edit model-driven app views.

## Task 8.1 - Customize Pet views

1. Edit the Active Pets view.

1. Remove the Created On column.
1. Add the following columns:
   - Species
   - Date of birth
   - Pet owner

## Task 8.2 - Customize Trick views

1. Edit the Active Tricks view.

1. Rename the view to `Tricks`.
1. Remove the Created On column.
1. Add the Points column.

## Task 8.3 - Customize Pet Trick views

1. Edit the Active Pet Tricks view.

1. Rename the view to `Pet Tricks`.
1. Remove the Created On column.
1. Add the following columns:
   - Pet
   - Trick
   - Level
   - Points
   - Owner
   - Status Reason
1. Add the Species and Date of Birth columns from the Pet table after the Pet column.
1. Delete name from Sort by.
1. Sort by Pet and then by Trick columns.

1. Use Save As to copy the Pet Tricks view and name the view Beginner Tricks.
1. Select the Level column and set Filter by Equals Beginner.
1. Remove the Level and Date of Birth columns.

## Task 8.4 - Customize Pet Trick Associated view

1. Edit the Pet Trick Associated view.
1. Remove the Created On column.
1. Add the following columns:
   - Pet
   - Trick
   - Level
   - Points

## Task 8.5 - Customize Pet Trick Quick Find view

1. Edit the Pet Trick Quick Find view.
1. Remove the Created On column.
1. Add the following columns:
   - Pet
   - Pet.Species
   - Trick
   - Level
   - Points
   - Owner
1. Edit the find table columns and add:
   - Pet
   - Trick

## Task 8.6 - Customize Pet Lookup view

1. Edit the Pet Lookup view.
1. Remove the Created On column.
1. Add the following columns:
   - Species
   - Pet Owner
   - Pet value

## Task 8.7 - Customize Trick Lookup view

1. Edit the Trick Lookup view.
1. Remove the Created On column.
1. Add the following columns:
   - Points
