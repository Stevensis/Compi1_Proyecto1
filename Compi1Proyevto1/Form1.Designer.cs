namespace Compi1Proyevto1
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.Menu = new System.Windows.Forms.Panel();
            this.btnNuevaV = new System.Windows.Forms.Button();
            this.btnGuardarC = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnRestore = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnAFN = new System.Windows.Forms.Button();
            this.btnAFD = new System.Windows.Forms.Button();
            this.btnTableCerradura = new System.Windows.Forms.Button();
            this.btnTableEstados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxExpresion = new System.Windows.Forms.ComboBox();
            this.lblConsola = new System.Windows.Forms.Label();
            this.richConsola = new System.Windows.Forms.RichTextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            this.PanelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Gray;
            this.Menu.Controls.Add(this.btnNuevaV);
            this.Menu.Controls.Add(this.btnGuardarC);
            this.Menu.Controls.Add(this.btnGuardar);
            this.Menu.Controls.Add(this.btnAbrir);
            this.Menu.Controls.Add(this.pictureBox1);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(220, 1000);
            this.Menu.TabIndex = 0;
            // 
            // btnNuevaV
            // 
            this.btnNuevaV.FlatAppearance.BorderSize = 0;
            this.btnNuevaV.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNuevaV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaV.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaV.Image = global::Compi1Proyevto1.Properties.Resources.pestanas;
            this.btnNuevaV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaV.Location = new System.Drawing.Point(3, 347);
            this.btnNuevaV.Name = "btnNuevaV";
            this.btnNuevaV.Size = new System.Drawing.Size(220, 88);
            this.btnNuevaV.TabIndex = 4;
            this.btnNuevaV.Text = "Nueva Ventana";
            this.btnNuevaV.UseVisualStyleBackColor = true;
            this.btnNuevaV.Click += new System.EventHandler(this.btnNuevaV_Click);
            // 
            // btnGuardarC
            // 
            this.btnGuardarC.FlatAppearance.BorderSize = 0;
            this.btnGuardarC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnGuardarC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarC.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarC.Image = global::Compi1Proyevto1.Properties.Resources.salvar;
            this.btnGuardarC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarC.Location = new System.Drawing.Point(0, 244);
            this.btnGuardarC.Name = "btnGuardarC";
            this.btnGuardarC.Size = new System.Drawing.Size(220, 88);
            this.btnGuardarC.TabIndex = 3;
            this.btnGuardarC.Text = "Guardar Como";
            this.btnGuardarC.UseVisualStyleBackColor = true;
            this.btnGuardarC.Click += new System.EventHandler(this.btnGuardarC_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::Compi1Proyevto1.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(0, 175);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 72);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Image = global::Compi1Proyevto1.Properties.Resources.abrir_carpeta_con_documento__1_;
            this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.Location = new System.Drawing.Point(0, 104);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(220, 72);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compi1Proyevto1.Properties.Resources.Usa_Logo2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnRestore);
            this.BarraTitulo.Controls.Add(this.btnMaximizar);
            this.BarraTitulo.Controls.Add(this.btnClose);
            this.BarraTitulo.Controls.Add(this.btnSlide);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(220, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(954, 49);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(795, 4);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 35);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 4;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.Location = new System.Drawing.Point(846, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(35, 35);
            this.btnRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestore.TabIndex = 3;
            this.btnRestore.TabStop = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(846, 4);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(35, 35);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(903, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(6, 3);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(35, 35);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlide.TabIndex = 0;
            this.btnSlide.TabStop = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.AutoScroll = true;
            this.PanelContenedor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelContenedor.Controls.Add(this.btnReportes);
            this.PanelContenedor.Controls.Add(this.btnAFN);
            this.PanelContenedor.Controls.Add(this.btnAFD);
            this.PanelContenedor.Controls.Add(this.btnTableCerradura);
            this.PanelContenedor.Controls.Add(this.btnTableEstados);
            this.PanelContenedor.Controls.Add(this.label1);
            this.PanelContenedor.Controls.Add(this.cbxExpresion);
            this.PanelContenedor.Controls.Add(this.lblConsola);
            this.PanelContenedor.Controls.Add(this.richConsola);
            this.PanelContenedor.Controls.Add(this.btnAnalizar);
            this.PanelContenedor.Controls.Add(this.tabControl1);
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(220, 49);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(954, 951);
            this.PanelContenedor.TabIndex = 2;
            this.PanelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContenedor_Paint);
            // 
            // btnReportes
            // 
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Image = global::Compi1Proyevto1.Properties.Resources.encuesta;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(554, 465);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(316, 82);
            this.btnReportes.TabIndex = 12;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnAFN
            // 
            this.btnAFN.FlatAppearance.BorderSize = 0;
            this.btnAFN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnAFN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAFN.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAFN.ForeColor = System.Drawing.Color.White;
            this.btnAFN.Image = global::Compi1Proyevto1.Properties.Resources.cerebro__1_;
            this.btnAFN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAFN.Location = new System.Drawing.Point(554, 377);
            this.btnAFN.Name = "btnAFN";
            this.btnAFN.Size = new System.Drawing.Size(316, 82);
            this.btnAFN.TabIndex = 11;
            this.btnAFN.Text = "AFN, Thompson";
            this.btnAFN.UseVisualStyleBackColor = true;
            this.btnAFN.Click += new System.EventHandler(this.btnAFN_Click);
            // 
            // btnAFD
            // 
            this.btnAFD.FlatAppearance.BorderSize = 0;
            this.btnAFD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnAFD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAFD.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAFD.ForeColor = System.Drawing.Color.White;
            this.btnAFD.Image = global::Compi1Proyevto1.Properties.Resources.cerebro;
            this.btnAFD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAFD.Location = new System.Drawing.Point(554, 289);
            this.btnAFD.Name = "btnAFD";
            this.btnAFD.Size = new System.Drawing.Size(316, 82);
            this.btnAFD.TabIndex = 10;
            this.btnAFD.Text = "AFD";
            this.btnAFD.UseVisualStyleBackColor = true;
            this.btnAFD.Click += new System.EventHandler(this.btnAFD_Click);
            // 
            // btnTableCerradura
            // 
            this.btnTableCerradura.FlatAppearance.BorderSize = 0;
            this.btnTableCerradura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnTableCerradura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableCerradura.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableCerradura.ForeColor = System.Drawing.Color.White;
            this.btnTableCerradura.Image = global::Compi1Proyevto1.Properties.Resources.tabla_de_datos;
            this.btnTableCerradura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableCerradura.Location = new System.Drawing.Point(554, 209);
            this.btnTableCerradura.Name = "btnTableCerradura";
            this.btnTableCerradura.Size = new System.Drawing.Size(316, 82);
            this.btnTableCerradura.TabIndex = 9;
            this.btnTableCerradura.Text = "Tabla Cerraduras";
            this.btnTableCerradura.UseVisualStyleBackColor = true;
            this.btnTableCerradura.Click += new System.EventHandler(this.btnTableCerradura_Click);
            // 
            // btnTableEstados
            // 
            this.btnTableEstados.FlatAppearance.BorderSize = 0;
            this.btnTableEstados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnTableEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableEstados.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableEstados.ForeColor = System.Drawing.Color.White;
            this.btnTableEstados.Image = global::Compi1Proyevto1.Properties.Resources.columna;
            this.btnTableEstados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableEstados.Location = new System.Drawing.Point(554, 121);
            this.btnTableEstados.Name = "btnTableEstados";
            this.btnTableEstados.Size = new System.Drawing.Size(316, 82);
            this.btnTableEstados.TabIndex = 8;
            this.btnTableEstados.Text = "Tabla Estados";
            this.btnTableEstados.UseVisualStyleBackColor = true;
            this.btnTableEstados.Click += new System.EventHandler(this.btnTableEstados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Expresiones";
            // 
            // cbxExpresion
            // 
            this.cbxExpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExpresion.FormattingEnabled = true;
            this.cbxExpresion.Location = new System.Drawing.Point(579, 55);
            this.cbxExpresion.Name = "cbxExpresion";
            this.cbxExpresion.Size = new System.Drawing.Size(121, 24);
            this.cbxExpresion.TabIndex = 6;
            // 
            // lblConsola
            // 
            this.lblConsola.AutoSize = true;
            this.lblConsola.Location = new System.Drawing.Point(608, 598);
            this.lblConsola.Name = "lblConsola";
            this.lblConsola.Size = new System.Drawing.Size(59, 17);
            this.lblConsola.TabIndex = 5;
            this.lblConsola.Text = "Consola";
            // 
            // richConsola
            // 
            this.richConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richConsola.ForeColor = System.Drawing.Color.White;
            this.richConsola.Location = new System.Drawing.Point(45, 621);
            this.richConsola.Name = "richConsola";
            this.richConsola.Size = new System.Drawing.Size(686, 182);
            this.richConsola.TabIndex = 4;
            this.richConsola.Text = "";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.FlatAppearance.BorderSize = 0;
            this.btnAnalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnAnalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizar.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.ForeColor = System.Drawing.Color.White;
            this.btnAnalizar.Image = global::Compi1Proyevto1.Properties.Resources.prueba__1_;
            this.btnAnalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalizar.Location = new System.Drawing.Point(120, 533);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(331, 82);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(25, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 510);
            this.tabControl1.TabIndex = 0;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "OpenFile";
            this.OpenFile.Filter = "Archivos ER (*.ER)|*.ER";
            this.OpenFile.Title = "Archivo a Analizar";
            // 
            // SaveFile
            // 
            this.SaveFile.Filter = "Archivos ER (*.ER)|*.ER";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1000);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            this.PanelContenedor.ResumeLayout(false);
            this.PanelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnRestore;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevaV;
        private System.Windows.Forms.Button btnGuardarC;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Label lblConsola;
        private System.Windows.Forms.RichTextBox richConsola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxExpresion;
        private System.Windows.Forms.Button btnTableEstados;
        private System.Windows.Forms.Button btnTableCerradura;
        private System.Windows.Forms.Button btnAFD;
        private System.Windows.Forms.Button btnAFN;
        private System.Windows.Forms.Button btnReportes;
    }
}

