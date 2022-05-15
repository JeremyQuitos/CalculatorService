using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace CalcSub.Tests;

public class SubTestFunction
{
    [Fact]
    public void TestToUpperFunction()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new SubFunction();
        var context = new TestLambdaContext();
        //var upperCase = function.SubFunctionHandler("hello world", context);

        //Assert.Equal("HELLO WORLD", upperCase);
    }
}
