using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Compi1Proyevto1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            //Se redimenciona la ventana por cualquier tema de margenes
            Menu.Width = 158;
            pictureBox1.Width = 158;
            btnRestore.Visible = false;
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
    }
}
