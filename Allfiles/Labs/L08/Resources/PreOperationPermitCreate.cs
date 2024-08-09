using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace ContosoPackageProject
{
    public class PreOperationPermitCreate : PluginBase
    {
        public PreOperationPermitCreate(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(PreOperationPermitCreate))
        {
        }

        // Entry point for custom business logic execution
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            var permitEntity = context.InputParameters["Target"] as Entity;
            var buildSiteRef = permitEntity["contoso_buildsite"] as EntityReference;
            localPluginContext.Trace("Primary Entity Id: " + permitEntity.Id);
            localPluginContext.Trace("Build Site Entity Id: " + buildSiteRef.Id);

            string fetchString = "<fetch output-format='xml-platform' distinct='false' version='1.0' mapping='logical' aggregate='true'><entity name='contoso_permit'><attribute name='contoso_permitid' alias='Count' aggregate='count' /><filter type='and' ><condition attribute='contoso_buildsite' uitype='contoso_buildsite' operator='eq' value='{" + buildSiteRef.Id + "}'/><condition attribute='statuscode' operator='eq' value='330650001'/></filter></entity></fetch>";
            localPluginContext.Trace("Calling RetrieveMultiple for locked permits");
            var response = localPluginContext.PluginUserService.RetrieveMultiple(new FetchExpression(fetchString));

            int lockedPermitCount = (int)((AliasedValue)response.Entities[0]["Count"]).Value;
            localPluginContext.Trace("Locked Permit count : " + lockedPermitCount);
            if (lockedPermitCount > 0)
            {
                throw new InvalidPluginExecutionException("Too many locked permits for build site");
            }
        }
    }
}
