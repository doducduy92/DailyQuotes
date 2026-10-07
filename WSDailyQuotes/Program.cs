namespace WSDailyQuotes
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);

			builder.Services.AddWindowsService(options =>
			{
				options.ServiceName = "DailyQuotesService";
			});

			builder.Services.AddHostedService<Worker>();

			var host = builder.Build();
			host.Run();
		}
	}
}
