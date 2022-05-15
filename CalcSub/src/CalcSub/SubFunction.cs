using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalcSub;

public class SubFunction
{

    /// <summary>
    /// A simple function that subtracts two numbers
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public APIGatewayProxyResponse SubFunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        int num1, num2, diff, statusCode;
        num1 = num2 = diff = statusCode = 0;
        string response;

        if (request.QueryStringParameters["num1"] != null
            && request.QueryStringParameters["num2"] != null)
        {
            num1 = int.Parse(request.QueryStringParameters["num1"]);
            num2 = int.Parse(request.QueryStringParameters["num2"]);
            diff = num1 - num2;
            statusCode = 200;
            response = diff.ToString();
        }
        else
        {
            statusCode = 400;
            response = "Invalid numbers";
        }

        context.Logger.Log($"Numbers: {num1}, {num2}, Diff: {diff}");
        return new APIGatewayProxyResponse
        {
            StatusCode = statusCode,
            Body = response
        };
    }
}
