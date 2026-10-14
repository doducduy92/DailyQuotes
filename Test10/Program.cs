using Service;

namespace Test10
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			await DuyUtility.CompareDate();
			//var list = await DuyUtility.GetQuoteList();
			Console.WriteLine("Hello, World!");
		}
	}
}
