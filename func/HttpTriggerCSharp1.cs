using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Cgol.Func
{
	public static class HttpTriggerCSharp1
	{
		[Function("HttpTriggerCSharp1")]
		public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
				FunctionContext executionContext)
		{
			var logger = executionContext.GetLogger("HttpTriggerCSharp1");
			logger.LogInformation("C# HTTP trigger function processed a request.");

			var response = req.CreateResponse(HttpStatusCode.OK);
			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			response.WriteString($"Hello World, time and date are {DateTime.Now.ToString()}");

			return response;
		}
	}
}
