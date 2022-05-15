using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalcDiv;

public class DivFunction
{

    /// <summary>
    /// A simple function that devides two numbers
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public APIGatewayProxyResponse DivFunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        float num1, num2, ans;
        int statusCode = 400;
        num1 = num2 = ans = 0;

        string response;

        if (request.QueryStringParameters["num1"] != null
            && request.QueryStringParameters["num2"] != null)
        {
            num1 = float.Parse(request.QueryStringParameters["num1"]);
            num2 = float.Parse(request.QueryStringParameters["num2"]);
            ans = num1 / num2;
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
