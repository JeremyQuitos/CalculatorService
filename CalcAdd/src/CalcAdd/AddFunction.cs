using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalcAdd;

public class AddFunction
{
    
    /// <summary>
    /// A simple function that adds two numbers
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public APIGatewayProxyResponse AddFunctionHandler(APIGatewayProxyRequest request,ILambdaContext context)
    {
        int num1, num2, sum, statusCode;
        num1 = num2 = sum = statusCode = 0;

        string response;

        if (request.QueryStringParameters["num1"] != null 
            && request.QueryStringParameters["num2"] != null)
        {
            num1 = int.Parse(request.QueryStringParameters["num1"]);
            num2 = int.Parse(request.QueryStringParameters["num2"]);
            sum = num1 + num2;
            statusCode = 200;
            response = sum.ToString();
        }
        else
        {
            statusCode = 400;
            response = "Invalid numbers";
        }

        context.Logger.Log($"Numbers: {num1}, {num2}. Sum: {sum}");
        return new APIGatewayProxyResponse
        {
            StatusCode = statusCode,
            Body = response
        };
    }
}
