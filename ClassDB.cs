using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos_avtoinspekciya
{
    class ClassDB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-82TL9N1K\SQLEXPRESS;Initial Catalog=Gos_avtoinspekciya;Integrated Security=True");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
