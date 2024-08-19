---
demo:
    title: 'Demo 9: JavaScript and OnChange event'
    module: '4: Extending the model-driven app user experience'
---

# Demo 9 - JavaScript and OnChange event

**Objective:** In this demo, you will show how to create a JavaScript web resource and an OnChange event handler in the Pet Trick form.

## Task 9.1 - JavaScript function

1. Create a text file on your computer and enter the following JavaScript.

```javascript
function dem_pettrick_trick_OnChange(executionContext) {
    "use strict";
    console.log('dem: on change - Pet Trick form - Trick');
    var formContext = executionContext.getFormContext();
    var trick = formContext.getAttribute("dem_trickid").getValue();
    if (trick === null) {
        console.log('dem: Trick null');
        formContext.ui.controls.get("dem_points").setVisible(false);
        formContext.getAttribute("dem_points").setValue(0);
        return;
    } else {
        var trickid = trick[0].id;
        console.log('dem: Trick =' + trickid);
        Xrm.WebApi.retrieveRecord("dem_trick", trickid).then(function (result) {
            if (result.dem_trickpoints) {
                console.log('dem: Trick Points');
                formContext.getControl("dem_points").setVisible(true);
                formContext.getAttribute("dem_points").setValue(result.dem_trickpoints);
            }
        },
            function (error) { console.log('dem: Error:' + error.message) });
     }
}
```

## Task 9.2 - JavaScript web resource

1. In the demo solution, create a new web resource.

   - Enter `Pet Trick Library` for Display name.
   - Enter `pettricklibrary` for Name.
   - Select JavaScript for Type
   - Choose the file containing the JavaScript function

## Task 9.3 - OnChange event handler

1. Edit the Pet Trick main form.

1. Select the Trick field.
1. Select the Events tab in the right-hand pane.
1. Select + Add library.
1. Search for `dem` and add the Pet Trick Library.
1. Expand On Change and select + Event Handler.
   - Select On Change for Event Type.
   - Select dem_pettricklibrary for Library.
   - Enter `dem_pettrick_trick_OnChange` for Function.
   - Check Pass execution content as first parameter

## Task 9.4 - Test OnChange event

1. Open a new Pet Trick form.

1. Open Dev Tools and show the console.
1. Clear the console.
1. Filer the console using `dem`.
1. Select a Trick lookup and show the console log.
1. Clear the Trick lookup and show the console log.
