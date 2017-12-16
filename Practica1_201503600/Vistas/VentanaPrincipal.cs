using Practica1_201503600.Estructuras.MoldeMatriz;
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
    public partial class VentanaPrincipal : Form
    {
        private NodoUsuario usuario;
        private Form1 referencia;
        private static String path = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString();
        public VentanaPrincipal(Form1 referencia)
        {
            InitializeComponent();
            this.referencia = referencia;
            this.usuario = null;
        }

        public void login(NodoUsuario user)
        {
            this.usuario = user;
        }

        private void cargarArchivo(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files (.json)|*.json";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                // Open the selected file to read.
                try
                {   // Open the text file using a stream reader.
                    StreamReader sr = new StreamReader(path);

                    // Read the stream to a string, and write the string to the console.
                    txtJSON.Text = sr.ReadToEnd();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo leer el archivo");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void analizarCadena(object sender, EventArgs e)
        {
            CastJsonToObject cast = new CastJsonToObject();
            try
            {
                cast.getModelo(txtJSON.Text);
                while (!cast.getPila().isEmpty())
                    usuario.getPila().push(cast.getPila().pop().getMatriz());

                while (!cast.getCola().isEmpty())
                    usuario.getCola().queue(cast.getCola().dequeue().getMatriz());
                MessageBox.Show("Archivo analizado correctamente!");
            }
            catch (Exception) {
                MessageBox.Show("Error al leer el archivo");
            }


            //if (m != null)
            //    MessageBox.Show("");
            //MessageBox.Show("Error al analizar el archivo");

        }

        private void deleteUser(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar la cuenta?", "Advertencia",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                 == DialogResult.Yes)
            {
                this.referencia.eliminarCuenta(usuario);
                this.usuario = null;
                this.Hide();
                this.referencia.Show();
            }
        }

        private void logout(object sender, EventArgs e)
        {
            this.referencia.cerrarSesion(usuario);
            this.usuario = null;
            this.Hide();
            this.referencia.Show();
        }
        
        private void mostarPila(object sender, EventArgs e)
        {
            if (!usuario.getPila().isEmpty())
            {
                String dot = usuario.getPila().generarImagenPila();
                // Delete the file if it exists.
                if (File.Exists(path + "\\Dot\\pila.dot"))
                    File.Delete(path + "\\Dot\\pila.dot");
                try
                {
                    if (File.Exists(path + "\\Png\\pila.png"))
                        File.Delete(path + "\\Png\\pila.png");
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
                    File.Delete(path + "\\Png\\pila.png");
                }
                // Create the file.
                using (FileStream fs = File.Create(path + "\\Dot\\pila.dot"))
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
                cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\pila.dot -o {path}\\Png\\pila.png");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                abrirImagen("pila.png");
            }
            else
                MessageBox.Show("No hay datos en la pila para mostrar");
        }
        
        private void mostrarMPila(object sender, EventArgs e)
        {
            if (!usuario.getPila().isEmpty())
            {
                String dot = usuario.getPila().peek().getMatriz().generarImagenMatriz();
                // Delete the file if it exists.
                if (File.Exists(path + "\\Dot\\matrizPila.dot"))
                    File.Delete(path + "\\Dot\\matrizPila.dot");
                try
                {
                    if (File.Exists(path + "\\Png\\matrizPila.png"))
                        File.Delete(path + "\\Png\\matrizPila.png");
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
                    File.Delete(path + "\\Png\\matrizPila.png");
                }
                // Create the file.
                using (FileStream fs = File.Create(path + "\\Dot\\matrizPila.dot"))
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
                cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\matrizPila.dot -o {path}\\Png\\matrizPila.png");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                abrirImagen("matrizPila.png");
            }
            else
                MessageBox.Show("No hay datos en la pila para mostrar");
        }
        
        private void mostrarCola(object sender, EventArgs e)
        {
            if (!usuario.getCola().isEmpty())
            {
                String dot = usuario.getCola().generarImagenCola();
                // Delete the file if it exists.
                if (File.Exists(path + "\\Dot\\cola.dot"))
                    File.Delete(path + "\\Dot\\cola.dot");
                try
                {
                    if (File.Exists(path + "\\Png\\cola.png"))
                        File.Delete(path + "\\Png\\cola.png");
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
                    File.Delete(path + "\\Png\\cola.png");
                }
                // Create the file.
                using (FileStream fs = File.Create(path + "\\Dot\\cola.dot"))
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
                cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\cola.dot -o {path}\\Png\\cola.png");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                abrirImagen("cola.png");
            }
            else
                MessageBox.Show("No hay datos en la cola para mostrar");
        }
        
        private void mostrarMCola(object sender, EventArgs e)
        {
            if (!usuario.getCola().isEmpty())
            {
                String dot = usuario.getCola().peek().getMatriz().generarImagenMatriz();
                // Delete the file if it exists.
                if (File.Exists(path + "\\Dot\\matrizCola.dot"))
                    File.Delete(path + "\\Dot\\matrizCola.dot");
                try
                {
                    if (File.Exists(path + "\\Png\\matrizCola.png"))
                        File.Delete(path + "\\Png\\matrizCola.png");
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
                    File.Delete(path + "\\Png\\matrizCola.png");
                }
                // Create the file.
                using (FileStream fs = File.Create(path + "\\Dot\\matrizCola.dot"))
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
                cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\matrizCola.dot -o {path}\\Png\\matrizCola.png");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                abrirImagen("matrizCola.png");
            }
            else
                MessageBox.Show("No hay datos en la cola para mostrar");
        }

        private int getProducto(NodoMatriz fila, NodoMatriz columna)
        {
            int suma = 0;

            while (fila != null)
            {
                suma += (fila.getDato() * columna.getDato());
                fila = fila.getDerecha();
                columna = columna.getAbajo();
            }

            return suma;
        }
        
        private void productoCP(object sender, EventArgs e)
        {
            if (!usuario.getCola().isEmpty())
            {
                if (!usuario.getPila().isEmpty())
                {
                    if (usuario.getCola().peek().getMatriz().getSizeX() == usuario.getPila().peek().getMatriz().getSizeY())
                    {
                        Matriz m1 = usuario.getCola().dequeue().getMatriz();
                        Matriz m2 = usuario.getPila().pop().getMatriz();
                        Matriz resultante = new Matriz(m2.getSizeX(), m1.getSizeY());

                        NodoMatriz nodo1 = m1.getRaiz();
                        NodoMatriz nodo2 = m2.getRaiz();

                        for (int y = 0; y < m1.getSizeY(); y++)
                        {
                            for (int x = 0; x < m2.getSizeX(); x++)
                            {
                                resultante.setValorMatriz(x, y, getProducto(nodo1, nodo2));
                                nodo2 = nodo2.getDerecha();
                            }
                            nodo1 = nodo1.getAbajo();
                            nodo2 = m2.getRaiz();
                        }

                        String dot = resultante.generarImagenMatriz();
                        // Delete the file if it exists.
                        if (File.Exists(path + "\\Dot\\matriz.dot"))
                            File.Delete(path + "\\Dot\\matriz.dot");
                        try
                        {
                            if (File.Exists(path + "\\Png\\matriz.png"))
                                File.Delete(path + "\\Png\\matriz.png");
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
                            File.Delete(path + "\\Png\\matriz.png");
                        }
                        // Create the file.
                        using (FileStream fs = File.Create(path + "\\Dot\\matriz.dot"))
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
                        cmd.StandardInput.WriteLine($"dot -Tpng {path}\\Dot\\matriz.dot -o {path}\\Png\\matriz.png");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        abrirImagen("matriz.png");
                    }
                    else
                        MessageBox.Show("No se puede realizar la operación, el #columnas debe ser igual al #filas");
                }
                else
                    MessageBox.Show("No hay datos en la pila, ingrese valores");
            }
            else
                MessageBox.Show("No hay datos en la cola, ingrese valores");
        }

        private void abrirImagen(String imagen)
        {
            try
            {
                while (!File.Exists(path + "\\Png\\" + imagen))
                    Thread.Sleep(500);
                Process aplicacion = new Process();
                aplicacion.StartInfo.FileName = path + "\\Png\\" + imagen;
                aplicacion.Start();
                aplicacion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el archivo:\n" + path + "\\Png\\" + imagen);
            }
        }
    }
}
