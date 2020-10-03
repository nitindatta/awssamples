using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Util;
using Amazon.Lambda;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Demo.Aws.LambdaFunction
{
  public class Function
  {

    public async Task<string> FunctionHandler(SQSEvent invocationEvent, ILambdaContext context)
    {
      LambdaLogger.Log("ENVIRONMENT VARIABLES: " + JsonSerializer.Serialize(System.Environment.GetEnvironmentVariables()));
      LambdaLogger.Log("CONTEXT: " + JsonSerializer.Serialize(context));
      LambdaLogger.Log("EVENT: " + JsonSerializer.Serialize(invocationEvent));
      try
      {
        foreach (var trans in invocationEvent.Records)
        {            
            var transaction = JsonSerializer.Deserialize<Transaction>(trans.Body);
             LambdaLogger.Log("Transaction: " + transaction);             
        }
      }
      catch
      {
        throw;
      }
      return "Success";
    }    
  }
}