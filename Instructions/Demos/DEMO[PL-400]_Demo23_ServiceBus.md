---
demo:
    title: 'Demo 23: Azure Service Bus'
    module: '10: Integrate Dataverse and Azure'
---

# Demo 23 - Azure Service Bus

**Objective:** In this demo, you will show how to create an Azure Service Bus Queue and then post messages to the queue from Dataverse.

## Task 23.1 - Create an Azure Service Bus queue

1. Open the Azure portal.

1. Create a Resource Group named Demo.

1. Create a Service Bus namespace and select the Standard tier.

1. Create a Queue in the Service Bus named trickqueue.

1. Select the queue and create a Shared access policy, named All with all checkboxes ticked.

1. Select the All policy and copy the Primary Connection String.

## Task 23.2 - Register a Service Endpoint

1. Start the Plug-in Registration Tool and connect to the Demo environment.

1. Register a new Service Endpoint and paste the Primary Connection String.

1. Select XML for Message Format.

1. Register a step on the service endpoint.

   - Enter `Create` for **Message**.

   - Enter `dem_trick` for **Primary Table**.

   - Select **PostOperation** from dropdown for **Event Pipeline Stage of Execution**.

   - Select **Asynchronous** for **Execution mode**.

   - Uncheck **Delete AsyncOperation**.

## Task 23.3 - Test integration with Azure

1. Open a new Trick form.

1. Enter a name and points and select Save.

1. In the Azure Portal navigate to the Overview page for the queue.

1. Show that there is 1 message in the queue.

1. Use the Service Bus Explorer to Peek the message and show the XML in the message body.

## Task 23.4 - Add service endpoint to solution

1. In the demo solution, add existing Service Endpoint and select trickqueue.

1. In the demo solution, add existing Plug-in step and select Create of dem_trick.
