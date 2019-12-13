using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Inventario_Avanzado
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            AbrirFOrmulario<FHidden>();
        }


        private void AbrirFOrmulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormulario.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la coleccion el formulario
            // Si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormulario.Controls.Add(formulario);
                panelFormulario.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Form1"] == null)
            {
                button1.BackColor = Color.White;
            }
            if (Application.OpenForms["Form2"] == null)
            {

                button2.BackColor = Color.White;
            }
            if (Application.OpenForms["Form3"] == null)
            {
                button3.BackColor = Color.White;
            }
        }

        private void LoadUserData()
        {
            lblUsuario.Text = UserCache.usuario;
            lblNombre.Text = UserCache.nombre;
            if (UserCache.tipo == 0)
            {
                lblTipo.Text = "Super Admin";
            }
            else if (UserCache.tipo == 1)
            {
                lblTipo.Text = "Administrador";
            }
            else
            {
                lblTipo.Text = "Empleado";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Cerrar Sesion", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form1>();
            button1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form2>();
            button2.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form3>();
            button3.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
