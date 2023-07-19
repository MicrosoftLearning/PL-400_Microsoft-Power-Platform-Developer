using Microsoft.Xrm.Sdk;
using System;

namespace DemoPlugin
{
    public class ValidatePetTrick : PluginBase
    {
        public ValidatePetTrick(string unsecureConfiguration, string secureConfiguration) : base(typeof(ValidatePetTrick))
        {
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;
            localPluginContext.Trace("Message:" + context.MessageName);
            localPluginContext.Trace("Entity:" + context.PrimaryEntityName);
            localPluginContext.Trace("Primary Entity Id:" + context.PrimaryEntityId.ToString());
            localPluginContext.Trace("Stage:" + context.Stage.ToString());
            localPluginContext.Trace("Depth:" + context.Depth.ToString());

            // Validate Entity and Message
            if (context.PrimaryEntityName != "dem_pettrick")
            {
                localPluginContext.Trace("Primary Entity is not Pet Trick");
                //return;
            }

            if (context.MessageName.ToLower() != "create")
            {
                localPluginContext.Trace("Message is not Create");
                return;
            }

            // Validate contents of entity
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                localPluginContext.Trace("Target");
                var entity = (Entity)context.InputParameters["Target"];
                if (!entity.Contains("dem_petid"))
                {
                    localPluginContext.Trace("No Pet in Entity");
                    throw new InvalidPluginExecutionException("A pet must be selected");
                }
                if (!entity.Contains("dem_trickid"))
                {
                    localPluginContext.Trace("No Trick in Entity");
                    throw new InvalidPluginExecutionException("A trick must be selected");
                }
            }
        }
    }
}