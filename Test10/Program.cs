using Service;

namespace Test10
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			
			var list = await DuyUtility.GetQuoteList();
			Console.WriteLine("Hello, World!");
		}
	}
}
