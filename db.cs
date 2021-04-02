using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autorizazia_wpf
{
    public class db
    {
        MySqlConnection connection = new MySqlConnection("server=rudy.zzz.com.ua;port=3306; username=kkv1506;password=2002Kkv53_1;database=kkv1506");

        public void openConn()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConn()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConn()
        {
            return connection;
        }
    }
}
