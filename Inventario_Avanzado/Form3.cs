using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MenuResponsive
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //MessageBox.Show("callamrd");
        }

        MySqlConnection conectar = new MySqlConnection("server=192.168.0.201; database=db_inventario; uid = prueba; pwd=Aa123");



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Screen s = this.PrimaryScreen;
            //int a = this.Bounds.Height;
            //int b = this.Bounds.Width;
            //int bta = button2.Bounds.Width;
            //int btu = button2.Location.X;
            //MessageBox.Show("Alto: " + a + " Ancho: " + b + "\nAncho Boton:" + bta + "\nMe encuentro en: X=" + btu);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //int a = this.Bounds.Height;

            //this.Width = Convert.ToInt32(a * 0.8);
            //this.Height = 768;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ancho ventana: " + this.Bounds.Width);
        }
    }
}
