using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compi1Proyevto1.Manejador
{
    class Tabs
    {

        int ContadorPestañas = 0;
        TabControl tabControlP;

        public Tabs(TabControl tabControlP)
        {
            this.tabControlP = tabControlP;
        }

        public void New(String nombre, String Contenido, String rutaId) {
            TabPage NuevaPestaña = new TabPage(nombre + verificarNP(nombre)); // Creamos una nueva pestaña, adentro ire el nombre que tendra la pestaña
            NuevaPestaña.Name = rutaId + verificarIdP(nombre); //Pone un nombre para identificar la pestaña
            RichTextBox areT = new RichTextBox();  //Crea un nuevo espacio de texto
            areT.Name = "ATP"; //+ NuevaPestaña.Name;  //Asigna nombre al espacio de texto para identificarlo
            areT.Size = new System.Drawing.Size(372, 390); //Asignamos un tamaño al RichTextBox
            areT.Text = Contenido; //Aigna el contenido que le mandamos al instanciar el metodo
            areT.Font = new Font("Arial", 9, FontStyle.Regular); //En este proyecto el font de las pestañas sera distinto al del texto en el Rich Text Box
            tabControlP.Refresh();
            NuevaPestaña.Controls.Add(areT); //Añade un area de texto a la pagina

            tabControlP.TabPages.Add(NuevaPestaña); //cargamos la pestaña en el control

            

            tabControlP.SelectedTab = NuevaPestaña; //seleccionamos la pestaña
        }
        //Verifica si es una carga de archivo o una nueva pestaña para poder poner el nombre
        public String verificarNP(String nombreP)
        {
            if (nombreP != "Nueva Pestaña")
            {
                return "";
            }
            ContadorPestañas++; //variable que lleva el control de la cantidad de pestaña creada
            return " " + ContadorPestañas;
        }
        //Verifica si es una carga de archivo o una nueva pestaña para poder poner el name que identifica a la pestaña
        public String verificarIdP(String nombreP)
        {
            if (nombreP != "Nueva Pestaña")
            {
                return "";
            }
            return "P" + ContadorPestañas;
        }
        //Elimina la pestaña actual 
        public void DeleteTab()
        {
            TabPage current_tab = tabControlP.SelectedTab; //Guardamos la pestaña que esta seleccionada
            if (current_tab != null)
            {
                tabControlP.TabPages.Remove(current_tab);
            }
        }
        //Busca el tab seleccionado para obtener el contenido de su richtBox
        public String searchTxt()
        {
            String idTxt = "ATP";// + idtab; //Este es el id que van a tener todos los controles RICH
            String contenidoTxt = ""; //Lo que va retornar
            try
            {
                foreach (Control control in tabControlP.SelectedTab.Controls) //recorremos la lista de controles, //Obtiene el control seleccionado
                {
                    if (control.Name.Equals(idTxt)) //El que sea igual al id de idTxt es el RICH que contiene la informacion del archivo
                    {
                        RichTextBox richText = (RichTextBox)control; //El control lo convertimos a tipo RichTextBox
                        contenidoTxt = richText.Text; //El contenido lo guardamos en la variable a retornar


                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No hay pestaña seleccionada");
            }

            return contenidoTxt;
        }
    }
}
