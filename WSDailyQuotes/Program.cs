using Serilog;

namespace WSDailyQuotes
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);

			// 1. Configure Serilog to write to a file with daily rotation
			string logPath = Path.Combine(AppContext.BaseDirectory, "Logs", "worker-log.txt");
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
				.CreateLogger();

			// 2. Override default logging provider with Serilog
			builder.Services.AddSerilog();

			Log.Information("Starting the Worker Service host...");
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
