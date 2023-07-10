using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Text.RegularExpressions;

namespace ContosoPackageProject
{
    public class LockPermitCancelInspections : PluginBase
    {
        public LockPermitCancelInspections(string unsecureConfiguration, string secureConfiguration)
: base(typeof(PreOperationPermitCreate))
        {

        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var permitEntityRef = localPluginContext.PluginExecutionContext.InputParameters["Target"] as EntityReference;
            Entity permitEntity = new Entity(permitEntityRef.LogicalName, permitEntityRef.Id);

            localPluginContext.Trace("Updating Permit Id : " + permitEntityRef.Id);
            permitEntity["statuscode"] = new OptionSetValue(330650001);

            localPluginContext.CurrentUsQuerterService.Update(permitEntity);
            localPluginContext.Trace("Updated Permit Id " + permitEntityRef.Id);

            QueryExpression qe = new QueryExpression
            {
                EntityName = "contoso_inspection",
                ColumnSet = new ColumnSet("statuscode"),
            };
            qe.Criteria.AddCondition("contoso_permit", ConditionOperator.Equal, permitEntityRef.Id);

            localPluginContext.Trace("Retrieving inspections for Permit Id " + permitEntityRef.Id);
            var inspectionsResult = localPluginContext.PluginUserService.RetrieveMultiple(qe);
            localPluginContext.Trace("Retrieved " + inspectionsResult.Entities.Count + " inspection records");

            int canceledInspectionsCount = 0;
            foreach (var inspection in inspectionsResult.Entities)
            {
                var currentValue = inspection.GetAttributeValue<OptionSetValue>("statuscode");
                if (currentValue.Value == 1 || currentValue.Value == 330650001)
                {
                    canceledInspectionsCount++;
                    inspection["statuscode"] = new OptionSetValue(330650004);
                    localPluginContext.Trace("Canceling inspection Id : " + inspection.Id);
                    localPluginContext.PluginUserService.Update(inspection);
                    localPluginContext.Trace("Canceled inspection Id : " + inspection.Id);
                }
            }

            if (canceledInspectionsCount > 0)
            {
                localPluginContext.Trace("Canceled " + canceledInspectionsCount + " inspection records");
                localPluginContext.PluginExecutionContext.OutputParameters["CanceledInspectionsCount"] = canceledInspectionsCount;
            }

            if (localPluginContext.PluginExecutionContext.InputParameters.ContainsKey("Reason"))
            {
                localPluginContext.Trace("Building a note record");
                Entity note = new Entity("annotation");
                note["subject"] = "Permit Locked";
                note["notetext"] = "Reason for locking this permit: " + localPluginContext.PluginExecutionContext.InputParameters["Reason"];
                note["objectid"] = permitEntityRef;
                note["objecttypecode"] = permitEntityRef.LogicalName;

                localPluginContext.Trace("Creating a note record");
                var createdNoteId = localPluginContext.PluginUserService.Create(note);

                if (createdNoteId != Guid.Empty)
                    localPluginContext.Trace("Note record was created");

            }
        }
    }
}
