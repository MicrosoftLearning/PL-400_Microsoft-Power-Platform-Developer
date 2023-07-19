---
demo:
    title: 'Demo 6: Business rules'
    module: '1: Work with Microsoft Dataverse'
---

# Demo 6 - Business rules

**Objective:** In this demo, you will show how to create business rule on the Pet trick table and columns created in the previous demos.

## Task 6.1 - Business rule to enforce selection of Level on Pet Trick records

1. Navigate to the Power Apps maker portal <https://make.powerapps.com>.

1. Select the **Demo** environment.
1. Select **Solutions** from the left navigation pane.
1. Select the **PL400 Demos** solution.
1. Expand **Tables**.
1. Select and expand the **Pet Trick** table.
1. Select **Business rules**.

1. Select **+ New business rule**.
1. Enter `Trick Level` for Business rule name.
1. Show the options for Scope and select **Entity**.
1. Select the Condition and enter `Level` for Display Name.
1. In the rule select:

   - **Trick** for Field.
   - **Contains data** for Operator.

1. Add a new rule by selecting **+ New**.

1. In Rule 2 select:

   - **Level** for Field.
   - **Does not contain data** for Operator.

1. Select **AND** for Rule Logic.
1. Select **Apply**.

1. Select the Components tab.
1. Drag the **Set Business Required** component to the right of the Condition.
1. Enter `Level required` for Display Name.
1. Select **Level** and **Business Required**.
1. Select **Apply**.

1. Select the Components tab.
1. Drag the **Show Error Message** component to the right of Set Business Required.
1. Enter `Error` for Display Name.
1. Select **Level** and enter `Level must be specified when a trick is selected`.
1. Select **Apply**.

1. Select the Components tab.
1. Drag the **Set Business Required** component to the right of the Condition.
1. Enter `Level not required` for Display Name.
1. Select **Level** and **Not Business Required**.
1. Select **Apply**.
1. Select **Save**.
1. Select **Activate**.
1. Select **Activate**.
1. Close the Business rule editor window.
1. Select **Done**.
