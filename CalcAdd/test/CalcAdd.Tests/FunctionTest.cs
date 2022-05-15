using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

namespace CalcAdd.Tests;

public class AddTest
{
    public AddTest() { }

    [Fact]
    public void TestGetMethod()
    {
        AddFunction functions = new AddFunction();
        APIGatewayProxyRequest request = new APIGatewayProxyRequest();
        TestLambdaContext context = new TestLambdaContext();
        APIGatewayProxyResponse response = new APIGatewayProxyResponse();

        //response = await AddFunction.AddFunctionHandler(request, context);
        //Assert.Equal(200, response.StatusCode);
    }
}
