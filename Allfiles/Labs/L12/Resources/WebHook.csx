#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async void Run(HttpRequest req, ILogger log)
{
	log.LogInformation("C# HTTP trigger function processed a request.");

	string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
	dynamic data = JsonConvert.DeserializeObject(requestBody);
	string indentedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
	log.LogInformation(indentedJson);
}