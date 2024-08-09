---
demo:
    title: 'Demo 13: Create a custom connector'
    module: '8: Custom Connectors'
---

# Demo 13 - Create a custom connector

**Objective:** In this demo, you will show how to create a custom connector from an OpenAPI file

## Task 13.1 - Open API file

1. Create a text file named openapi.json on the virtual machine and enter the following the JSON.

    ```json
    {
        "swagger": "2.0",
        "info": {
            "title": "Inventory Management",
            "version": "1.0"
        },
        "host": "apiapp-inventorymanagement.azurewebsites.net",
        "basePath": "/inventory",
        "schemes": [
            "https"
        ],
        "securityDefinitions": {
            "apiKeyHeader": {
                "type": "apiKey",
                "name": "Ocp-Apim-Subscription-Key",
                "in": "header"
            },
            "apiKeyQuery": {
                "type": "apiKey",
                "name": "subscription-key",
                "in": "query"
            }
        },
        "security": [
            {
                "apiKeyHeader": []
            },
            {
                "apiKeyQuery": []
            }
        ],
        "paths": {
            "/api/WarehouseLocations": {
                "get": {
                    "operationId": "get-api-warehouselocations",
                    "summary": "/api/WarehouseLocations - GET",
                    "tags": [
                        "WarehouseLocations"
                    ],
                    "produces": [
                        "text/plain",
                        "application/json",
                        "text/json"
                    ],
                    "responses": {
                        "200": {
                            "description": "Success",
                            "schema": {
                                "$ref": "#/definitions/WarehouseCityArray"
                            },
                            "examples": {
                                "application/json": "[\r\n  {\r\n    \"cityName\": \"string\"\r\n  }\r\n]",
                                "text/json": "[\r\n  {\r\n    \"cityName\": \"string\"\r\n  }\r\n]"
                            }
                        }
                    }
                }
            }
        },
        "definitions": {
            "WarehouseCity": {
                "type": "object",
                "properties": {
                    "cityName": {
                        "type": "string"
                    }
                }
            },
            "WarehouseCityArray": {
                "type": "array",
                "items": {
                    "$ref": "#/definitions/WarehouseCity"
                }
            }
        },
        "tags": []
    }   
   ```

## Task 13.2 - Import a custom connector

1. In the Power Automate portal `https://make.powerautomate.com`.

1. Select the **Demo** environment.

1. Expand Data and select Connectors.

1. Select + New custom connector and select Import an Open API file.

   - Enter InventoryManager for Connector name.
   - Select the openapi.json file.

1. Show the tabs in the connector wizard.

1. Create the connector.

## Task 13.3 - Add connector to solution

1. In the demo solution, add existing custom connector.

1. Select the Outside Dataverse tab and add the InventoryManager connector.
