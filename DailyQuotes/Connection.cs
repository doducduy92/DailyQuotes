using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyQuotes
{
    public class Connection
    {
        static string Server = "DESKTOP-3L86IB7";
        static string Username = "sa";
        static string Password = "123456";
        static string Database = "DailyQuotes";
        public static string ConnectionString = "Server=" + Server +
                                                    ";Database=" + Database +
                                                    ";User Id=" + Username +
                                                    ";Password=" + Password + ";";
    }
}
