using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    class Database
    {
        public static SqlConnection ConnectDB()
        {
            string connString = "data source = DESKTOP-CPV8G9B\\SQLEXPRESS; database= Library; integrated security = True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
