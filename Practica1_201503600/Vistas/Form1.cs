using Practica1_201503600.Estructuras.Usuario;
using Practica1_201503600.JSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_201503600.Vistas
{
    public partial class Form1 : Form
    {

        private ListaUsuario usuarios;
        private static String path = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString();
        public Form1()
        {
            InitializeComponent();

            this.usuarios = new ListaUsuario();
            this.ventanaRegistro = new Registro(this);
            this.principal = new VentanaPrincipal(this);
            
        }

        private Registro ventanaRegistro;
        private void registrar(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.ventanaRegistro.Show();
        }

        private VentanaPrincipal principal;
        private void iniciarSesion(object sender, EventArgs e)
        {
            if (!txtUser.Text.ToString().Equals("") && !txtPass.Text.ToString().Equals(""))
            {
                NodoUsuario aux = usuarios.findUser(txtUser.Text, txtPass.Text);
                if (aux != null)
                {
                    principal.login(aux);
                    this.Hide();
                    this.principal.Show();
                }
                else
                    MessageBox.Show("Usuario y/o contraseña inválidos");
            }
            else
                MessageBox.Show("Campos inválidos");
        }

        public void cerrarSesion(NodoUsuario user)
        {
            txtUser.Text = "";
            txtPass.Text = "";
            usuarios.updateUser(user);
        }

        public void eliminarCuenta(NodoUsuario user)
        {
            txtUser.Text = "";
            txtPass.Text = "";
            usuarios.deleteUser(user.getUsername(), user.getPassword());
        }

        public void addUsers(ListaUsuario nuevos)
        {
            NodoUsuario auxiliar;
            for (int i = 0; i < nuevos.getSize(); i++)
            {
                auxiliar = nuevos.get(i);
                usuarios.addUser(auxiliar.getUsername(), auxiliar.getPassword());
            }
            ventanaRegistro.vaciar();
        }


        private void mostrarUsuarios(object sender, EventArgs e)
        {
            if (usuarios.getSize() > 0)
            {
                String dot = usuarios.generarImagen();
                // Delete the file if it exists.
                if (File.Exists(path + "\\Dot\\usuarios.dot"))
                    File.Delete(path + "\\Dot\\usuarios.dot");
                try
                {
                    if (File.Exists(path + "\\Png\\usuarios.png"))
                        File.Delete(path + "\\Png\\usuarios.png");
                }
                catch (Exception)
                {
                    foreach (Process proceso in Process.GetProcesses())
                    {
                        if (proceso.ProcessName == "Fotos.exe")
                        {
                            proceso.Kill();
                        }
                    }
                    File.Delete(path + "\\Png\\usuarios.png");
                }

                // Create the file.
                using (FileStream fs = File.Create(path + "\\Dot\\usuarios.dot"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(dot);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\usuarios.dot -o {path}\\Png\\usuarios.png");
                cmd.StandardInput.Flush();
                cmd.Close();
                try
                {
                    while (!File.Exists(path + "\\Png\\usuarios.png"))
                        Thread.Sleep(500);
                    Process p = new Process();
                    p.StartInfo.FileName = path + "\\Png\\usuarios.png";
                    p.Start();
                    p.Close();
                    
                }
                catch (Exception) {
                    MessageBox.Show("No se pudo abrir la imagen");
                }
            }
            else
                MessageBox.Show("No existen usuarios para mostrar");
        }
    }
}
