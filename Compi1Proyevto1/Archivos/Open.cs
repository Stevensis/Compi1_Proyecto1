using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compi1Proyevto1.Archivos
{
    class Open
    {
        //Metodo para leer el arhivo que se seleccione
        public String LeerA(OpenFileDialog op) //Obtiene el componente que da el nombre del archivo
        {
            Stream stream;
            if ((stream = op.OpenFile()) != null) //Verifica que el contenido no es vacio
            {
                String rutaA = op.FileName; //Ruta del archivo
                String contenido = File.ReadAllText(rutaA); //Guarda el contenido
                stream.Close();
                return contenido;
            }
            stream.Close();
            return "";
        }
        //Metodo para guardar como el archivo 
        public Boolean GuardarC(String ruta, String contenido)
        {

            Boolean v = false;
            //fijamos dondevamos a crear el archivo 
            try
            {
                if (!File.Exists(ruta))
                {
                    StreamWriter escrito = File.CreateText(ruta); // en el 
                                                                  //para agregar datos al archivo existente 
                                                                  //StreamWriter escrito = File.AppendText("c:\\file.txt"); // en el 
                                                                  //escribimos. 
                    escrito.Write(contenido);
                    escrito.Flush();
                    //Cerramos 
                    escrito.Close();
                    v = true;
                }
                else
                {
                    StreamWriter escrito = File.CreateText(ruta);
                    escrito.Write(contenido);
                    escrito.Flush();
                    //Cerramos 
                    escrito.Close();
                    v = true;
                }

            }
            catch (Exception)
            {
                v = false;
            }

            return v;
        }
    }
}
