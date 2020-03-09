using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Archivos
{
    class Gra
    {
        String ruta;
        StringBuilder grafo;
        String name="";
        public Gra()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Obtiene la ruta del escritorio
        }

        public void generadorDot(String rutaDot, String rutaImagen)
        {
            System.IO.File.WriteAllText(rutaDot, grafo.ToString());
            String comandoDot = "dot.exe -Tpng " + rutaDot + " -o " + rutaImagen + " ";
            var comando = string.Format(comandoDot);
            var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStart;
            proc.Start();
            proc.WaitForExit();

        }
        //contenido contiene las lineas
        public void graficar(String contenido, String contado)
        {
            grafo = new StringBuilder();
            String rutaDot = ruta + "\\"+ contado+ ".dot";
            String rutaImagen = ruta + "\\" + contado + ".png";
            name = contado;
            grafo.Append("digraph G { ");
            grafo.Append(contenido);
            grafo.Append("}");
            this.generadorDot(rutaDot, rutaImagen);

        }

        public String abrirGrafo()
        {
            if (File.Exists(ruta + "\\" + name + ".png"))
            {
                try
                {
                    System.Diagnostics.Process.Start(ruta+ "\\"+name+".png"); //Hace que la imagen se abra
                    return ruta + "\\" + name + ".png";
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error" + ex);
                    return "";
                }
            }
            else
            {
                Console.WriteLine("Archivo no existe");
                return "";
            }
        }
    }
}
