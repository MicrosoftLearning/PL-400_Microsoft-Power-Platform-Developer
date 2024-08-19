if (typeof (ContosoPermit) === "undefined") { var ContosoPermit = { __namespace: true }; }
if (typeof (ContosoPermit.Scripts) === "undefined") { ContosoPermit.Scripts = { __namespace: true }; }

ContosoPermit.Scripts.PermitForm = {

    handleOnLoad: function (executionContext) {
        "use strict";
        console.log('on load - permit form');
    },

    handleOnChangePermitType: function (executionContext) {
        "use strict";
        console.log('on change - permit type');
    },

    __namespace: true
}

