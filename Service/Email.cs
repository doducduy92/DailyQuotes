using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	internal class Email
	{
		public static async Task SendEmailAsync(List<QuoteModel> list)
		{
			var email = new MimeMessage();

			email.From.Add(new MailboxAddress("Sender Name", "doducduy92@gmail.com"));
			email.To.Add(new MailboxAddress("Receiver Name", "doducduy92@gmail.com"));

			email.Subject = "1% Better Every Day";

			// Use StringBuilder for efficient string concatenation
			var sb = new StringBuilder();
			foreach (var quote in list)
			{
				sb.Append("<p><b>").Append(quote.Book).Append("</b><br>");
				sb.Append(quote.Quote).Append("</p><hr>");
			}

			email.Body = new TextPart(TextFormat.Html)
			{
				Text = sb.ToString()
			};

			// Use MailKit's SmtpClient (not System.Net.Mail.SmtpClient)
			using var client = new SmtpClient();

			// Connect using STARTTLS on port 587
			await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

			// Authenticate using your Gmail App Password
			await client.AuthenticateAsync("doducduy92@gmail.com", "lcixllazzetdxpyh");

			await client.SendAsync(email);
			await client.DisconnectAsync(true);
		}
	}
}
