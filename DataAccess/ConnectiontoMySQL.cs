using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public abstract class ConnectiontoMySQL
    {
        private readonly string connectionString;
        public ConnectiontoMySQL()
        {
            connectionString = "server=127.0.0.1; database=db_inventario; uid = root; pwd=Aa123";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
