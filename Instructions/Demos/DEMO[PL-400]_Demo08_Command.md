---
demo:
    title: 'Demo 8: Command button'
    module: '4: Extending the model-driven app user experience'
---

# Demo 8 - Command button

**Objective:** In this demo, you will show how to add a command button to a model-driven app that will reject and cancel a pet trick when in evaluation status.

## Task 8.1 - Add command button

1. Edit the model-driven app.
1. Edit the command bar for the Pet Tricks view.
1. Select Main form.
1. Add a new command.
1. Select Power Fx.
1. Enter `Reject Trick` for Label.
1. Select Reply for Icon.
1. Set Action to Run formula.
1. Open formula bar and enter `Patch('Pet Tricks', Self.Selected.Item, {'Status Reason': 'Status Reason (Pet Tricks)'.Rejected})`.
1. Set Visibility to Show on condition from formula.
1. Open formula bar and enter `If(Self.Selected.Item.'Status Reason' = 'Status Reason (Pet Tricks)'.Evaluation, true, false)`.
