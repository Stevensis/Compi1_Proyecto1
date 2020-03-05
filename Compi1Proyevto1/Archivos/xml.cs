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
        public void  Tokens(LinkedList<Token> ltokens) {
            String XmlS = "";
            XmlS += "<?xml version=\"1.0\"?>\n";
            XmlS += "<ListaTokens>\n";
            foreach (var item in ltokens)
            {
                XmlS += "   <Token>\n";
                XmlS += "       <Nombre>"+item.getTipo()+"</Nombre>\n";
                XmlS += "       <Valor>"+item.Valor+"</Valor>\n";
                XmlS += "       <Fila>"+item.Fila+"</Fila>\n";
                XmlS += "       <Columna>"+item.Columna+"</Columna>\n";
                XmlS += "   </Token>\n";
            }
            XmlS += "</ListaTokens>\n";
            /*creando archivo xml*/
            File.WriteAllText("Reporte Token.xml", XmlS);
            System.Diagnostics.Process.Start("Reporte Token.xml");
        }

        public void Errores(LinkedList<Error> lerrores) {
            String XmlS = "";
            XmlS += "<?xml version=\"1.0\"?>\n";
            XmlS += "<ListaErrores>\n";
            foreach (var item in lerrores)
            {
                XmlS += "   <Error>\n";
                XmlS += "       <descripcion>" + item.Descripcion + "</descripcion>\n";
                XmlS += "       <Valor>" + item.Valor + "</Valor>\n";
                XmlS += "       <Fila>" + item.Fila + "</Fila>\n";
                XmlS += "       <Columna>" + item.Columna + "</Columna>\n";
                XmlS += "   </Error>\n";
            }
            XmlS += "</ListaErrores>\n";
            /*creando archivo xml*/
            File.WriteAllText("Reporte Errores.xml", XmlS);
            System.Diagnostics.Process.Start("Reporte Errores.xml");
        }
    }
}
