using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoMinecraf
{
    partial class Form1
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
            NombreJugador = new TextBox();
            NombredelJugador = new Label();
            NivelJugador = new NumericUpDown();
            NiveldelJugador = new Label();
            Agregar = new Button();
            Actualizar = new Button();
            Eliminar = new Button();
            MostrarInventario = new DataGridView();
            TipoBloque = new ComboBox();
            FiltrarBloques = new Label();
            Filtro = new Button();
            label1 = new Label();
            Raresa = new Label();
            RarezaBloque = new ComboBox();
            pictureBox1 = new PictureBox();
            SeleccionDocumento = new Label();
            Exportar_a_CSV = new Button();
            Exportar_Excel = new Button();
            ((System.ComponentModel.ISupportInitialize)NivelJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MostrarInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // NombreJugador
            // 
            NombreJugador.Location = new Point(182, 61);
            NombreJugador.Name = "NombreJugador";
            NombreJugador.Size = new Size(230, 27);
            NombreJugador.TabIndex = 0;
            // 
            // NombredelJugador
            // 
            NombredelJugador.AutoSize = true;
            NombredelJugador.Location = new Point(38, 61);
            NombredelJugador.Name = "NombredelJugador";
            NombredelJugador.Size = new Size(138, 20);
            NombredelJugador.TabIndex = 1;
            NombredelJugador.Text = "NombredelJugador";
            // 
            // NivelJugador
            // 
            NivelJugador.Location = new Point(182, 147);
            NivelJugador.Name = "NivelJugador";
            NivelJugador.Size = new Size(230, 27);
            NivelJugador.TabIndex = 2;
            // 
            // NiveldelJugador
            // 
            NiveldelJugador.AutoSize = true;
            NiveldelJugador.Location = new Point(38, 154);
            NiveldelJugador.Name = "NiveldelJugador";
            NiveldelJugador.Size = new Size(96, 20);
            NiveldelJugador.TabIndex = 3;
            NiveldelJugador.Text = "NivelJugador";
            // 
            // Agregar
            // 
            Agregar.BackColor = Color.FromArgb(192, 255, 255);
            Agregar.Location = new Point(40, 273);
            Agregar.Name = "Agregar";
            Agregar.Size = new Size(171, 29);
            Agregar.TabIndex = 4;
            Agregar.Text = "Agregar";
            Agregar.UseVisualStyleBackColor = false;
            Agregar.Click += Agregar_Click;
            // 
            // Actualizar
            // 
            Actualizar.BackColor = Color.FromArgb(192, 255, 255);
            Actualizar.Location = new Point(235, 273);
            Actualizar.Name = "Actualizar";
            Actualizar.Size = new Size(195, 29);
            Actualizar.TabIndex = 5;
            Actualizar.Text = "Actualizar";
            Actualizar.UseVisualStyleBackColor = false;
            Actualizar.Click += Actualizar_Click;
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.FromArgb(192, 255, 255);
            Eliminar.Location = new Point(463, 273);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(206, 29);
            Eliminar.TabIndex = 6;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = false;
            Eliminar.Click += Eliminar_Click;
            // 
            // MostrarInventario
            // 
            MostrarInventario.BackgroundColor = Color.FromArgb(192, 255, 255);
            MostrarInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MostrarInventario.Location = new Point(93, 333);
            MostrarInventario.Name = "MostrarInventario";
            MostrarInventario.RowHeadersWidth = 51;
            MostrarInventario.Size = new Size(491, 188);
            MostrarInventario.TabIndex = 7;
            // 
            // TipoBloque
            // 
            TipoBloque.BackColor = Color.White;
            TipoBloque.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoBloque.FormattingEnabled = true;
            TipoBloque.Location = new Point(38, 618);
            TipoBloque.Name = "TipoBloque";
            TipoBloque.Size = new Size(151, 28);
            TipoBloque.TabIndex = 8;
            // 
            // FiltrarBloques
            // 
            FiltrarBloques.AutoSize = true;
            FiltrarBloques.Location = new Point(270, 538);
            FiltrarBloques.Name = "FiltrarBloques";
            FiltrarBloques.Size = new Size(104, 20);
            FiltrarBloques.TabIndex = 10;
            FiltrarBloques.Text = "Filtrar Bloques";
            FiltrarBloques.Click += FiltrarBloques_Click;
            // 
            // Filtro
            // 
            Filtro.Location = new Point(463, 618);
            Filtro.Name = "Filtro";
            Filtro.Size = new Size(167, 29);
            Filtro.TabIndex = 11;
            Filtro.Text = "Filtro";
            Filtro.UseVisualStyleBackColor = true;
            Filtro.Click += Filtro_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 255, 255);
            label1.Location = new Point(40, 577);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 12;
            label1.Text = "Tipo";
            // 
            // Raresa
            // 
            Raresa.AutoSize = true;
            Raresa.BackColor = Color.FromArgb(192, 255, 255);
            Raresa.Location = new Point(220, 582);
            Raresa.Name = "Raresa";
            Raresa.Size = new Size(54, 20);
            Raresa.TabIndex = 13;
            Raresa.Text = "Rareza";
            // 
            // RarezaBloque
            // 
            RarezaBloque.DropDownStyle = ComboBoxStyle.DropDownList;
            RarezaBloque.FormattingEnabled = true;
            RarezaBloque.Location = new Point(223, 618);
            RarezaBloque.Name = "RarezaBloque";
            RarezaBloque.Size = new Size(174, 28);
            RarezaBloque.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(480, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // SeleccionDocumento
            // 
            SeleccionDocumento.AutoSize = true;
            SeleccionDocumento.Location = new Point(40, 685);
            SeleccionDocumento.Name = "SeleccionDocumento";
            SeleccionDocumento.Size = new Size(160, 20);
            SeleccionDocumento.TabIndex = 15;
            SeleccionDocumento.Text = "Selecciona documento";
            // 
            // Exportar_a_CSV
            // 
            Exportar_a_CSV.BackColor = Color.FromArgb(192, 255, 255);
            Exportar_a_CSV.Location = new Point(38, 718);
            Exportar_a_CSV.Name = "Exportar_a_CSV";
            Exportar_a_CSV.Size = new Size(205, 67);
            Exportar_a_CSV.TabIndex = 16;
            Exportar_a_CSV.Text = "Exportar.csv";
            Exportar_a_CSV.UseVisualStyleBackColor = false;
            Exportar_a_CSV.Click += ExportarInventarioASC;
            // 
            // Exportar_Excel
            // 
            Exportar_Excel.BackColor = Color.FromArgb(192, 255, 255);
            Exportar_Excel.Location = new Point(338, 718);
            Exportar_Excel.Name = "Exportar_Excel";
            Exportar_Excel.Size = new Size(197, 67);
            Exportar_Excel.TabIndex = 17;
            Exportar_Excel.Text = "Exportar.excel";
            Exportar_Excel.UseVisualStyleBackColor = false;
            Exportar_Excel.Click += ExportarInventarioExcel;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(741, 868);
            Controls.Add(Exportar_Excel);
            Controls.Add(Exportar_a_CSV);
            Controls.Add(SeleccionDocumento);
            Controls.Add(pictureBox1);
            Controls.Add(RarezaBloque);
            Controls.Add(Raresa);
            Controls.Add(label1);
            Controls.Add(Filtro);
            Controls.Add(FiltrarBloques);
            Controls.Add(TipoBloque);
            Controls.Add(MostrarInventario);
            Controls.Add(Eliminar);
            Controls.Add(Actualizar);
            Controls.Add(Agregar);
            Controls.Add(NiveldelJugador);
            Controls.Add(NivelJugador);
            Controls.Add(NombredelJugador);
            Controls.Add(NombreJugador);
            Name = "Form1";
            Text = "Formulario de Gestión de Minecraft";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)NivelJugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)MostrarInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ExportarInventarioExcel(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportarInventarioASC(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.TextBox NombreJugador;
        private Label NombredelJugador;
        private System.Windows.Forms.NumericUpDown NivelJugador;
        private Label NiveldelJugador;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.DataGridView MostrarInventario;
        private System.Windows.Forms.ComboBox TipoBloque;
        private Label FiltrarBloques;
        private System.Windows.Forms.Button Filtro;
        private Label label1;
        private Label Raresa;
        private ComboBox RarezaBloque;
        private PictureBox pictureBox1;
        private Label SeleccionDocumento;
        private Button Exportar_a_CSV;
        private Button Exportar_Excel;
    }
}
