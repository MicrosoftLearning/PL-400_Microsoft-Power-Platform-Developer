function dem_pettrick_trick_OnChange(executionContext) {
    "use strict";
    console.log('dem: on change - Pet Trick form - Trick');
    var formContext = executionContext.getFormContext();
    var trick = formContext.getAttribute("dem_trickid").getValue();
    if (trick === null) {
        console.log('dem: Trick null');
        formContext.ui.controls.get("dem_points").setVisible(false);
        formContext.getAttributes("dem_points").setValue(0);
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