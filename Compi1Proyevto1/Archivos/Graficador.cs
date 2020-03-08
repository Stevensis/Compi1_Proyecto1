using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Archivos
{
    class Graficador
    {
        String ruta;
        StringBuilder grafo;
        String rtImagen = "";

        public Graficador()
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
        public void graficar(String contenido, String name)
        {
            grafo = new StringBuilder();
            String rutaDot = ruta + "\\"+name+".dot";
            String rutaImagen = ruta + "\\" + name + ".png";
            rtImagen = rutaImagen;
            grafo.Append("digraph G { ");
            grafo.Append(contenido);
            grafo.Append("}");
            this.generadorDot(rutaDot, rutaImagen);

        }

        public String abrirGrafo()
        {
            if (File.Exists(this.rtImagen))
            {
                try
                {
                    System.Diagnostics.Process.Start(this.rtImagen); //Hace que la imagen se abra
                    return this.rtImagen;
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
