using System;
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
using Compi1Proyevto1.Procesos;
using Compi1Proyevto1.Modelos;

namespace Compi1Proyevto1
{
    public partial class Form : System.Windows.Forms.Form
    {
        Tabs tab;
        Open open;
        xml xml;
        LinkedList<Token> ListaTk;
        LinkedList<Error> ListaErr;
        PictureBox picktore;
        
        public Form()
        {
            InitializeComponent();
            //Se redimenciona la ventana por cualquier tema de margenes
            Menu.Width = 158;
            pictureBox1.Width = 158;
            btnRestore.Visible = false;
            tab = new Tabs(this.tabControl1); //La clasa tab utlizara el tab control de este panel
            open = new Open();
            xml = new xml();
            picktore = new PictureBox();
            picktore.Size = new Size(700, 700);
            picktore.SizeMode = PictureBoxSizeMode.Zoom; //Adapta la imagen a las dimensiones
            this.PanelContenedor.Controls.Add(picktore);
            picktore.Location = new Point(0,650) ;
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
            picktore.Size = new Size(1200, 1200);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestore.Visible = false;
            picktore.Size = new Size(700, 700);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null) //Se se presiona ok y hay una pestaña activa
            {
                String rutaGA = tabControl1.SelectedTab.Name;//Ruta del archivo (El name del tab contiene la ruta del archivo)
                //Si es una prestaña nueva, el nombre comenzara con la letra P
                if (rutaGA.ElementAt(0)!='P')
                {
                    open.GuardarC(rutaGA, tab.searchTxt());
                    MessageBox.Show("Guardado con exito");
                }
                else
                {
                    MessageBox.Show("Primero tiene que presionar en Guardar Como");
                }

            }
            else
            {
                MessageBox.Show("No hay prestaña abierta");
            }
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            if (SaveFile.ShowDialog() == DialogResult.OK && tabControl1.SelectedTab != null) //Se se presiona ok y hay una pestaña activa
            {
                String rutaGA = SaveFile.FileName;//Ruta del archivo
                if (open.GuardarC(rutaGA, tab.searchTxt()))
                {
                    tabControl1.SelectedTab.Text = Path.GetFileNameWithoutExtension(SaveFile.FileName); 
                    tabControl1.SelectedTab.Name = SaveFile.FileName;
                }
                else
                {
                    MessageBox.Show("Error al guardar el archivo");
                }

            }
            else
            {
                MessageBox.Show("No hay prestaña abierta");
            }
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            this.cbxExpresion.Items.Clear();
            this.richConsola.Text = "";
            CreatePage page = new CreatePage();
            AnalizadorLexico analizadorLexico = new AnalizadorLexico();
            ListaTk = analizadorLexico.analizar(tab.searchTxt()); //Optenemos la lista de tokens
            ListaErr = analizadorLexico.getListErr(); //Optenemos la lista de erros
            if (ListaErr.Count==0) //En dado caso la lista de errores este vacia, podremos imprimir la lista de tokens 
            {
                // xml.Tokens(ListaTk);
                page.pageTokens(ListaTk);
                AnalizarTokens analizarTK = new AnalizarTokens(ListaTk);
                analizarTK.analizarTokens();


                foreach (var item in analizarTK.LstThompson)
                {
                     Graficador graficador = new Graficador();
                    //* Gra gra = new Gra();
                    //*  gra.graficar(item.Raiz.dot(), item.NameEr); //Mandamos el contenido del dot y el nombre que contendra el archivo(sera el mismo de la expresion)
                    //* gra.abrirGrafo();
                     graficador.graficar(item.Raiz.dot(),item.NameEr); //Mandamos el contenido del dot y el nombre que contendra el archivo(sera el mismo de la expresion)
                   //  graficador.abrirGrafo();
                     graficador.graficar(item.Transiciones.dot(),item.NameEr+"-table");
                   //  graficador.abrirGrafo();
                    graficador.graficar(item.Transiciones.dotAFD(),item.NameEr+"-AFD");
                    //  graficador.abrirGrafo
                    graficador.graficar(item.Transiciones.dotTableC(), item.NameEr + "-tableC");
                    File.WriteAllText(item.NameEr+ ".xml", "Reporete Tokens de la expresion regular: "+item.NameEr+" \n \n");
                    this.cbxExpresion.Items.Add(item.NameEr);
                    this.cbxExpresion.SelectedIndex = 0;
                }
                
                foreach (var item in analizarTK.LstLexamas)
                {
                    richConsola.Text += "Lexema: " + item.Cadena + " de la expresion: " + item.ExpresionName + " es: " + item.Valido.ToString() +"\n";
                    xml.Tokens(item.LstToken," Tokens de lexema \""+item.Cadena+"\" \n",item.ExpresionName);
                    xml.Errores(item.LstErrores, " Errores de lexema \"" + item.Cadena + "\" \n", item.ExpresionName);
                }
                MessageBox.Show("Analicis Correcto");

            }
            else //de lo contrario imprimeremos la lista de errores
            {
                page.pageError(ListaErr);
                //xml.Errores(ListaErr);
            }
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnTableEstados_Click(object sender, EventArgs e)
        {
            viewImage("-table");
        }

        private void btnTableCerradura_Click(object sender, EventArgs e)
        {
            viewImage("-tableC");
        }

        private void btnAFD_Click(object sender, EventArgs e)
        {
            viewImage("-AFD");
           
        }

        private void btnAFN_Click(object sender, EventArgs e)
        {
            viewImage("");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (this.cbxExpresion.SelectedItem.ToString()!="")
            {
                System.Diagnostics.Process.Start(this.cbxExpresion.SelectedItem.ToString()+".xml");
            }
        }

        public void viewImage(String image) {
            if (this.cbxExpresion.SelectedItem.ToString() != "")
            {
                
                Image miImagen = Image.FromFile(this.cbxExpresion.SelectedItem.ToString() + image+".png"); // crea la nueva imagen
                picktore.Image = miImagen; //Agregamos la imagen al cuadro
                
            }
            else
            {
                MessageBox.Show("No hay ninguna expresion seleccionada");
            }
            
        }
    }
}
