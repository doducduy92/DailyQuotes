using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Service
{
	[Table("Quote")]
	public class QuoteModel : BaseModel
	{
		[PrimaryKey("id", false)] // false if it's auto-incrementing (serial/identity)
		public int Id { get; set; }

		[Column("quote")]
		public string Quote { get; set; }

		[Column("book")]
		public string Book { get; set; }
	}
}
