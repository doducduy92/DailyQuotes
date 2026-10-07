using Supabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
	public class DuyUtility
	{
		public static string ReadDate()
		{
			string textFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\date.txt";
			string text = File.ReadAllText(textFile);
			return text;
		}

		public static void WriteDate()
		{
			string textFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\date.txt";
			string text = DateTime.Today.AddDays(1).ToString("yyyyMMdd");
			File.WriteAllText(textFile, text);
		}

		public static async Task CompareDate()
		{
			string text = ReadDate();
			string today = DateTime.Today.ToString("yyyyMMdd");
			if (Convert.ToInt32(text) <= Convert.ToInt32(today))
			{
				var list = await GetQuoteList();

				await Email.SendEmailAsync(list);
				WriteDate();
			}
		}

		public static async Task<List<QuoteModel>> GetQuoteList()
		{
			var url = "https://xzufiikmaceklozkitnp.supabase.co";
			var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inh6dWZpaWttYWNla2xvemtpdG5wIiwicm9sZSI6ImFub24iLCJpYXQiOjE3OTEzNzU5OTEsImV4cCI6MjEwNjk1MTk5MX0.tW8ivUjya2_tadYVeCdKxa5uOS16X77yy00mMdk07Es";

			var options = new SupabaseOptions { AutoConnectRealtime = false };
			var client = new Client(url, key, options);
			await client.InitializeAsync();

			// 2. Lấy tất cả danh sách Quote
			var response = await client.From<QuoteModel>().Get();
			var allQuotes = response.Models;

			// 3. Chọn ngẫu nhiên 3 quotes
			var randomQuotes = allQuotes.OrderBy(_ => Guid.NewGuid()).Take(3).ToList();

			return randomQuotes;
		}
	}
}
