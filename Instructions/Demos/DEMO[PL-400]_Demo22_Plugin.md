---
demo:
    title: 'Demo 22: Build a plug-in'
    module: '9: Extending Microsoft Dataverse'
---

# Demo 22 - Build a plug-in

**Objective:** In this demo, you will show how to create a Dataverse plug-in to validate a Pet Trick record is associated with a Trick and a Pet.

## Task 22.1 - Create plug-in

1. Create a folder on the Virtual machine named DemoPlugin and then run the following commands in the Developer command prompt.

     ```dos
     pac plugin init
     ```

     ```dos
     start DemoPlugin.csproj
     ```

1. Rename Plugin1.cs to ValidatePetTrick.cs.

1. Replace the code.

    ```csharp
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
    ```

1. Build the project.

## Task 22.2 - Register plug-in

1. Start the Plug-in Registration Tool.

   - In the command prompt, run the command below to launch the Plugin Registration Tool (PRT).

     ```dos
     pac tool prt
     ```

1. Create a connection to the Demo environment.

1. Register the DemoPlugin.dll assembly.

1. Register a step on the DemoPlugin.dll assembly.

   - Enter `Create` for **Message**.

   - Enter `dem_pettrick` for **Primary Table**.

   - Select **PreValidation** from dropdown for **Event Pipeline Stage of Execution**.

## Task 22.3 - Test plug-in

1. Open a new Pet Trick form.

1. Enter a name and select Save.

1. Select a Pet and select Save.

1. Select a Trick and select Save.

## Task 22.4 - Add plug-in to solution

1. In the demo solution, add existing Plug-in Assembly and select DemoPlugin.

1. In the demo solution, add existing Plug-in step and select Create of dem_pettrick.
