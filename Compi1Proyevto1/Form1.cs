﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compi1Proyevto1.Manejador;
using Compi1Proyevto1.Archivos;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Compi1Proyevto1
{
    public partial class Form : System.Windows.Forms.Form
    {
        Tabs tab;
        Open open;
        public Form()
        {
            InitializeComponent();
            //Se redimenciona la ventana por cualquier tema de margenes
            Menu.Width = 158;
            pictureBox1.Width = 158;
            btnRestore.Visible = false;
            tab = new Tabs(this.tabControl1);
            open = new Open();
        }
        //El menu bar se activara siempre se le haga click
        private void btnSlide_Click(object sender, EventArgs e)
        { //El tamaño de ancho siempre sera una constante, cuando se minimice los textos desaparecen para tener una estatica
            if (Menu.Width == 158) {
                btnAbrir.Text = "";
                btnGuardar.Text = "";
                btnGuardarC.Text = "";
                btnNuevaV.Text = "";
                Menu.Width = 49;
            }
            else
            {
                btnAbrir.Text = "Abrir";
                btnGuardar.Text = "Guardar";
                btnGuardarC.Text = "Guardar Como";
                btnNuevaV.Text = "Nueva Pestaña";
                Menu.Width = 158;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestore.Visible = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestore.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Ayuda que se pueda seleccionar y mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnNuevaV_Click(object sender, EventArgs e)
        {
            //Como es una nueva pestaña, no tendra ninguna ruta, ni contenido, solo un nombre indicando que esera una nueva pestaña
            tab.New("Nueva Pestaña", "", "");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    //Path.GetFileNameWithoutExtension es para que solo devuelva el nombre del archivo, //Filename es para la ruta completa del archivo
                    tab.New(Path.GetFileNameWithoutExtension(OpenFile.FileName),open.LeerA(OpenFile), OpenFile.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar Archivo");
                }
            }
            else
            {

            }
        }
    }
}
