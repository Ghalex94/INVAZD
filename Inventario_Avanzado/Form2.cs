using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjtImagenbaseDatos;

namespace MenuResponsive
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvImagen.DataSource = clsConexiones.EjecutarQuery("select * from borrar");
            int cont = dgvImagen.RowCount;
            for (int i = 0; i < cont; i++)
            {
                //dgvImagen.Rows[i].Height = 700;
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
