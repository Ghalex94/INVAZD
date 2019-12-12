using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace pjtImagenbaseDatos
{
    class clsConexiones
    {

      public static  MySqlConnection cnx = new MySqlConnection("Server=127.0.0.1; database=prueba; Uid=root; pwd=Aa123;");


        public static DataTable EjecutarQuery(string Q)
        {
            MemoryStream MS = new MemoryStream();

            byte[] Imagenes = MS.GetBuffer();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(Q, cnx);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Imagen", Imagenes);

            try
            {
                cnx.Open();
                da.Fill(dt);
                cnx.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally{ cnx.Close(); }

            return dt;

        }

    }
}
