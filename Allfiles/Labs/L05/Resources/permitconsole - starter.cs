using System;
using System.ServiceModel;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace Permit_console
{
    class Program
    {
        static public void Main(string[] args)
        {
            Console.Title = "PL400.Permit.Console";
            Console.WriteLine("Permit console : Start");

            string userName = "admin@M365x99999999.onmicrosoft.com";
            string password = "password";
            string url = "https://orgNNNNNNNN.crm.dynamics.com";

            string connectionString = "AuthType=OAuth;Username=" + userName + ";Password=" + password + ";Url=" + url + ";AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;LoginPrompt=Auto";

            try
            {
                Console.WriteLine("Connect using XRM Tooling");
                CrmServiceClient crmSvc = new CrmServiceClient(connectionString);
                if (crmSvc.IsReady)
                    Console.WriteLine("Connected");
                else
                {
                    throw new Exception("Failed to connect");
                }

                Console.WriteLine("Version={0}", crmSvc.ConnectedOrgVersion);
                Console.WriteLine("Organization={0}", crmSvc.ConnectedOrgUniqueName);

                Console.WriteLine("Retrieve current user");
                Guid currentuserid = ((WhoAmIResponse)crmSvc.Execute(new WhoAmIRequest())).UserId;
                Entity systemUser = (Entity)crmSvc.Retrieve("systemuser", currentuserid, new ColumnSet(new string[] { "firstname", "lastname" }));
                Console.WriteLine("Logged on user is {0} {1}.", systemUser["firstname"], systemUser["lastname"]);

                // Data Operations



                Console.WriteLine("Permit console : End");
                // Pause the console so it does not close.
                Console.WriteLine("Press the <Enter> key to exit.");
                Console.ReadLine();
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.WriteLine("Press the <Enter> key to exit.");
                Console.ReadLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.WriteLine("Press the <Enter> key to exit.");
                Console.ReadLine();
            }
        }
    }
}
