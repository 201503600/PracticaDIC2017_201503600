namespace Practica1_201503600.Vistas
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJSON = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilaCompletaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizPilaprimeraMatrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colaCompletaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizColaprimeraColaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplicarColaXPilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJSON
            // 
            this.txtJSON.Location = new System.Drawing.Point(12, 63);
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.Size = new System.Drawing.Size(455, 288);
            this.txtJSON.TabIndex = 0;
            this.txtJSON.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cargarArchivo);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Analizar JSON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.analizarCadena);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentaToolStripMenuItem,
            this.reportarToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(479, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem1});
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Eliminar cuenta";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.deleteUser);
            // 
            // cerrarSesiónToolStripMenuItem1
            // 
            this.cerrarSesiónToolStripMenuItem1.Name = "cerrarSesiónToolStripMenuItem1";
            this.cerrarSesiónToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.cerrarSesiónToolStripMenuItem1.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem1.Click += new System.EventHandler(this.logout);
            // 
            // reportarToolStripMenuItem
            // 
            this.reportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilaToolStripMenuItem,
            this.colaToolStripMenuItem});
            this.reportarToolStripMenuItem.Name = "reportarToolStripMenuItem";
            this.reportarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.reportarToolStripMenuItem.Text = "Reportar";
            // 
            // pilaToolStripMenuItem
            // 
            this.pilaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilaCompletaToolStripMenuItem,
            this.matrizPilaprimeraMatrizToolStripMenuItem});
            this.pilaToolStripMenuItem.Name = "pilaToolStripMenuItem";
            this.pilaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pilaToolStripMenuItem.Text = "Pila";
            // 
            // pilaCompletaToolStripMenuItem
            // 
            this.pilaCompletaToolStripMenuItem.Name = "pilaCompletaToolStripMenuItem";
            this.pilaCompletaToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.pilaCompletaToolStripMenuItem.Text = "Pila completa";
            this.pilaCompletaToolStripMenuItem.Click += new System.EventHandler(this.mostarPila);
            // 
            // matrizPilaprimeraMatrizToolStripMenuItem
            // 
            this.matrizPilaprimeraMatrizToolStripMenuItem.Name = "matrizPilaprimeraMatrizToolStripMenuItem";
            this.matrizPilaprimeraMatrizToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.matrizPilaprimeraMatrizToolStripMenuItem.Text = "Matriz pila (primera matriz)";
            this.matrizPilaprimeraMatrizToolStripMenuItem.Click += new System.EventHandler(this.mostrarMPila);
            // 
            // colaToolStripMenuItem
            // 
            this.colaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colaCompletaToolStripMenuItem,
            this.matrizColaprimeraColaToolStripMenuItem});
            this.colaToolStripMenuItem.Name = "colaToolStripMenuItem";
            this.colaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.colaToolStripMenuItem.Text = "Cola";
            // 
            // colaCompletaToolStripMenuItem
            // 
            this.colaCompletaToolStripMenuItem.Name = "colaCompletaToolStripMenuItem";
            this.colaCompletaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.colaCompletaToolStripMenuItem.Text = "Cola completa";
            this.colaCompletaToolStripMenuItem.Click += new System.EventHandler(this.mostrarCola);
            // 
            // matrizColaprimeraColaToolStripMenuItem
            // 
            this.matrizColaprimeraColaToolStripMenuItem.Name = "matrizColaprimeraColaToolStripMenuItem";
            this.matrizColaprimeraColaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.matrizColaprimeraColaToolStripMenuItem.Text = "Matriz cola (primera cola)";
            this.matrizColaprimeraColaToolStripMenuItem.Click += new System.EventHandler(this.mostrarMCola);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiplicarColaXPilaToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // multiplicarColaXPilaToolStripMenuItem
            // 
            this.multiplicarColaXPilaToolStripMenuItem.Name = "multiplicarColaXPilaToolStripMenuItem";
            this.multiplicarColaXPilaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.multiplicarColaXPilaToolStripMenuItem.Text = "Multiplicar Cola x Pila";
            this.multiplicarColaXPilaToolStripMenuItem.Click += new System.EventHandler(this.productoCP);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 363);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtJSON);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VentanaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Practica1_201503600";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtJSON;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilaCompletaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizPilaprimeraMatrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaCompletaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizColaprimeraColaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplicarColaXPilaToolStripMenuItem;
    }
}