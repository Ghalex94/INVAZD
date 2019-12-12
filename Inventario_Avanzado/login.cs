using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace MenuResponsive
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsusario.Text != "")
            {
                if (txtContra.Text != "")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtUsusario.Text, txtContra.Text);
                    if (validLogin)
                    {
                        FPrincipal mainmenu = new FPrincipal();
                        mainmenu.Show();
                        mainmenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario y Contraseña incorrectas. \n    Por favor intente denuevo.");
                        txtUsusario.Clear();
                        txtContra.Clear();
                        txtUsusario.Focus();                         
                    }
                }
                else msgError("Por favor ingrese la contraseña.");
            }
            else msgError("Por favor Ingrese el usuario.");
        }
        private void msgError(string msg)
        {
            lblmsgError.Text = "    " + msg;
            lblmsgError.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsusario.Clear();
            txtContra.Clear();
            txtUsusario.Focus();
            lblmsgError.Visible = false;
            this.Show();
            txtUsusario.Focus();
        }
    }
}
