using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalcMul;

public class MulFunction
{

    /// <summary>
    /// A simple function that multiplies two numbers
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public APIGatewayProxyResponse MulFunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        int num1, num2, ans, statusCode;
        num1 = num2 = ans = statusCode = 0;
        string response;

        if (request.QueryStringParameters["num1"] != null
            && request.QueryStringParameters["num2"] != null)
        {
            num1 = int.Parse(request.QueryStringParameters["num1"]);
            num2 = int.Parse(request.QueryStringParameters["num2"]);
            ans = num1 * num2;
            statusCode = 200;
            response = ans.ToString();
        }
        else
        {
            statusCode = 400;
            response = "Invalid numbers";
        }

        context.Logger.Log($"Numbers: {num1}, {num2}. Ans: {ans}");
        return new APIGatewayProxyResponse
        {
            StatusCode = statusCode,
            Body = response
        };
    }
}
