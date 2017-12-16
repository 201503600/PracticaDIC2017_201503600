using Practica1_201503600.Estructuras;
using Practica1_201503600.Estructuras.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_201503600.Vistas
{
    public partial class Registro : Form
    {
        private Form1 referencia;
        public Registro(Form1 referencia)
        {
            InitializeComponent();
            this.referencia = referencia;
        }

        private ListaUsuario usuarioRegistrado = new ListaUsuario();
        private void addUser(object sender, EventArgs e)
        {
            usuarioRegistrado.addUser(txtUsername.Text, txtPassword.Text);
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        public ListaUsuario getRegistrados()
        {
            return usuarioRegistrado;
        }

        public void vaciar()
        {
            usuarioRegistrado = new ListaUsuario();
        }

        private void backPrincipal(object sender, EventArgs e)
        {
            this.Hide();
            this.referencia.Show();
            this.referencia.addUsers(usuarioRegistrado);
        }
    }
}
