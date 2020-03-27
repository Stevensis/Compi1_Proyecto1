using Compi1Proyevto1.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Archivos
{
    class xml
    {
        public void  Tokens(List<Token> ltokens, String encabezado, String name) {
            String XmlS = encabezado+"\n";
            XmlS += "<?xml version=\"1.0\"?>\n";
            XmlS += "<ListaTokens>\n";
            foreach (var item in ltokens)
            {
                XmlS += "   <Token>\n";
                XmlS += "       <Nombre>"+item.TipoTokenString+"</Nombre>\n";
                String valor = item.Valor;
                valor = valor.Replace("\n", "/n");
                valor = valor.Replace("\t", "/t");
                valor = valor.Replace("\r", "/r");
                valor = valor.Replace("\"", "\\\"");
                XmlS += "       <Valor>"+valor+"</Valor>\n";
                XmlS += "       <Fila>"+item.Fila+"</Fila>\n";
                XmlS += "       <Columna>"+item.Columna+"</Columna>\n";
                XmlS += "   </Token>\n";
            }
            XmlS += "</ListaTokens>\n";

            File.AppendAllText(name + ".xml", XmlS);
        }

        public void Errores(List<Error> lerrores, String encabezado, String name) {
            String XmlS = encabezado+"\n";
            XmlS += "<?xml version=\"1.0\"?>\n";
            XmlS += "<ListaErrores>\n";
            foreach (var item in lerrores)
            {
                XmlS += "   <Error>\n";
                XmlS += "       <descripcion>" + item.Descripcion + "</descripcion>\n";
                String valor = item.Valor;
                valor = valor.Replace("\n", "/n");
                valor = valor.Replace("\t", "/t");
                valor = valor.Replace("\r", "/r");
                valor = valor.Replace("\"", "\\\"");
                XmlS += "       <Valor>" + valor + "</Valor>\n";
                XmlS += "       <Fila>" + item.Fila + "</Fila>\n";
                XmlS += "       <Columna>" + item.Columna + "</Columna>\n";
                XmlS += "   </Error>\n";
            }
            XmlS += "</ListaErrores>\n";
            File.AppendAllText(name + ".xml", XmlS);
            /*creando archivo xml*/
            //File.WriteAllText(name+".xml", XmlS);
            //  File.WriteAllText(name + "name.pdf", XmlS);
            //  System.Diagnostics.Process.Start("Reporte Errores.xml");
         //   File.AppendAllText(name + ".pdf", XmlS);
        }
    }
}
