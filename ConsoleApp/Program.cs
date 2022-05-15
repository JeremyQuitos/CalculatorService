using System;
using System.Net.Http;

namespace CalcApp
{
    internal class Calculator
    {
		private static string _params;
        public static void Main(string[] args)
        {
			Console.WriteLine("Select operation. Type *,/,+,-");
			string operation = Console.ReadLine();
			Console.WriteLine("Type first number...");
			int num1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Type second number...");
			int num2 = Convert.ToInt32(Console.ReadLine());

			_params = $"?num1={num1}&num2={num2}";
			switch (operation)
            {
				case "+":
					ProcessAPI("add", _params);
					break;
				case "-":
					ProcessAPI("sub", _params);
					break;
				case "*":
					ProcessAPI("mul", _params);
					break;
				case "/":
					ProcessAPI("div", _params);
					break;
				default:
					Console.WriteLine("Invalid Operation");
					break;
			}
		}

		private static void ProcessAPI(string method, string urlParameters)
		{
			var URL = $"https://8k24kpt9vk.execute-api.us-east-1.amazonaws.com/stage/{method}";
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(URL);

			HttpResponseMessage response = client.GetAsync(urlParameters).Result;
			if (response.IsSuccessStatusCode)
			{
				var body = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine("The Answer is {0}", body);
			}
		}
	}
}
