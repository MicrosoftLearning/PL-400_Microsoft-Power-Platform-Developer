---
demo:
    title: 'Demo Setup 3: Columns'
    module: '1: Work with Microsoft Dataverse'
---

# Demo setup instructions 3 - Columns

**Objective:** In this demo, you will show how to add columns to the tables created in the previous demo.

![Screenshot ERD for Demo tables.](../images/Demos/demo-erd.png)

## Task 3.1 - Add columns to Pets table

1. Navigate to the Power Apps Maker portal `https://make.powerapps.com`.

1. Select the **Demo** environment.
1. Select **Solutions** from the left navigation pane.
1. Select the **PL400 Demos** solution.
1. Expand **Tables**.
1. Select and expand the **Pet** table.
1. Select **Columns**.

1. Select **+ New column**
1. Enter `Date of birth` for Display name.
1. Select **Date and time** and then **Date only** for Data type.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Show options for Time zone adjustment and select **Date only**.
1. Select **Save**.

1. Select **+ New column**
1. Enter `Species` for Display name.
1. Select **Choice** and then **Choice** for Data type.
1. Under **Sync this choice with**, select **+ New choice**.
1. Enter `Species type` for **Display name**.
1. Enter `Cat` for **Label** and select **+ New choice**.
1. Enter `Dog` for **Label**.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Select **Save**.
1. Select **Species type** for **Sync this choice with**.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Select **Save**.

1. Select **+ New column**
1. Enter `Pet value` for Display name.
1. Select **Currency** for Data type.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Enter `0` for Minimum value.
1. Enter `99999` for Minimum value.
1. Select **Save**.

## Task 3.2 - Add columns to Tricks table

1. Select **Tricks** table.

1. Select **+ New** and then select **Column**.
1. Enter `Points` for Display name.
1. Select **Number** and then **Whole number** for Data type.
1. Show the options for Format and select **None**.
1. Expand **Advanced options**.
1. Enter `trickpoints' for Schema name.
1. Enter `0` for Minimum value.
1. Enter `100` for Minimum value.
1. Select **Save**.

## Task 3.3 - Add columns to Pet Tricks table

1. Select **Pet Trick** table.
1. Under **Schema**, select **Columns**.
1. Select **+ New column**.
1. Enter `Points` for Display name.
1. Select **Number** and then **Whole number** for Data type.
1. Show the options for Format and select **None**.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Enter `0` for Minimum value.
1. Enter `100` for Minimum value.
1. Select **Save**.

1. Select **+ New column**
1. Enter `Level` for Display name.
1. Select **Choice** and then **Choice** for Data type.
1. Under **Sync this choice with**, select **+ New choice**.
1. Enter `Skill level` for **Display name**.
1. Enter `Beginner` for **Label** and select **+ New choice**.
1. Enter `Intermediate` for **Label** and select **+ New choice**.
1. Enter `Expert` for **Label**.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Select **Save**.
1. Select **Skill level** for **Sync this choice with**.
1. Select **Beginner** for Default choice.
1. Expand **Advanced options**.
1. Change Schema name to lower case.
1. Select **Save**.

1. Select the **Status Reason** column.
1. Select **Edit**.
1. Change the Active option label to New Trick.

   - Make sure you have **Active** selected for **Status**.
   - Change the Label from Active to `New Trick`.

1. Add the Training option.

   - Select **+ New choice**.
   - Enter `Training` for Label.

1. Add the Evaluation option.

   - Select **+ New choice**.
   - Enter `Evaluation` for Label.

1. Add the Passed option.

   - Select **+ New choice**.
   - Enter `Passed` for Label.

1. Add the Rejected option.

   - Select **+ New choice**.
   - Enter `Rejected` for Label.

1. Select **New Trick** for Default choice.

1. Change the Inactive option label to Canceled.

   - Select the **Inactive** Status.
   - Change the Label from Inactive to `Canceled`.

1. Select **Save**.
1. Select **All** in the Objects tree.
1. Select **Publish all customizations**.
