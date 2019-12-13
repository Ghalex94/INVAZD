using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Common.Cache;

namespace DataAccess
{
    public class UserDao:ConnectiontoMySQL
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM db_inventario.tb_usuarios where usuario = @user and pass = @pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.usuario = reader.GetString(0);
                            UserCache.pass = reader.GetString(1);
                            UserCache.nombre = reader.GetString(2);
                            UserCache.tipo = reader.GetInt32(3);
                        }
                        return true;
                    }
                    else
                        return false;

                }
            }
        }
    }
}

