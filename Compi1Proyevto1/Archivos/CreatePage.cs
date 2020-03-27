using System;
using Compi1Proyevto1.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compi1Proyevto1.Archivos
{
    class CreatePage
    {
        public void pageTokens(LinkedList<Token> lstToken)
        {
            String page = "";
            page += "<!DOCTYPE HTML> \n " +
            "<HTML lang=\"es\"> \n"
            + "<head> \n"
            + "<title> Lista de Tokens </title> \n"
            + "<meta charset=\"UTF-8\"> \n"
            + "<meta name=\"description\" content=\"Reporte de Tokens\"> \n"
            + "<link rel=\"stylesheet\" href=\"css/bootstrap.min.css\"> \n"
            + "</head> \n"
            + "<body> \n"
            + "<div> \n"
            + "<h1 class=\"container\">Lista Tokens</h1> \n"
            + "</div> \n"
            + "<div class=\"container\"> \n"
            + "<table class=\"table table-dark\">\n"
            + "<thead>\n"
            + "<tr>\n"
            + "<th scope=\"col\">No.</th>\n"
            + "<th scope=\"col\">Lexema</th>\n"
            + "<th scope=\"col\">Token</th>\n"
            + "<th scope=\"col\">Fila</th>\n"
            + "<th scope=\"col\">Columna</th>\n"
            + "</tr>\n"
            + "</thead>\n"
            + "<tbody>\n";
            for (int i = 0; i < lstToken.Count(); i++)
            {
                String valor = lstToken.ElementAt(i).Valor;
                valor = valor.Replace("\n", "/n");
                valor = valor.Replace("\t", "/t");
                valor = valor.Replace("\r", "/r");
                valor = valor.Replace("\"", "ComillaD");
                page += "<tr>\n"
                        + "<th scope=\"row\">"
                        + lstToken.ElementAt(i).ContadorToken
                        + "</th>\n"
                        + "<td>\n"
                        + valor
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstToken.ElementAt(i).getTipo()
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstToken.ElementAt(i).Fila
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstToken.ElementAt(i).Columna
                        + "\n</td\n>"
                        + "</tr>\n";
            }
            page += "</tbody>\n";
            page += "</table>\n";
            page += "</div>\n";
            page += "</body>\n";
            page += "</HTML>";
            File.WriteAllText("Reporte Token.html", page);
            System.Diagnostics.Process.Start("Reporte Token.html");
        }

        public void pageError(LinkedList<Error> lstError)
        {
            String page = "";
            page += "<!DOCTYPE HTML> \n " +
            "<HTML lang=\"es\"> \n"
            + "<head> \n"
            + "<title> Lista de Tokens </title> \n"
            + "<meta charset=\"UTF-8\"> \n"
            + "<meta name=\"description\" content=\"Reporte de Errores\"> \n"
            + "<link rel=\"stylesheet\" href=\"css/bootstrap.min.css\"> \n"
            + "</head> \n"
            + "<body> \n"
            + "<div> \n"
            + "<h1 class=\"container\">Lista Errores</h1> \n"
            + "</div> \n"
            + "<div class=\"container\"> \n"
            + "<table class=\"table table-dark\">\n"
            + "<thead>\n"
            + "<tr>\n"
            + "<th scope=\"col\">No.</th>\n"
            + "<th scope=\"col\">Error</th>\n"
            + "<th scope=\"col\">Descripcion</th>\n"
            + "<th scope=\"col\">Fila</th>\n"
            + "<th scope=\"col\">Columna</th>\n"
            + "</tr>\n"
            + "</thead>\n"
            + "<tbody>\n";
            for (int i = 0; i < lstError.Count(); i++)
            {
                page += "<tr>\n"
                        + "<th scope=\"row\">"
                        + lstError.ElementAt(i).ContadorE
                        + "</th>\n"
                        + "<td>\n"
                        + lstError.ElementAt(i).Valor
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstError.ElementAt(i).Descripcion
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstError.ElementAt(i).Fila
                        + "\n</td\n>"
                        + "<td>\n"
                        + lstError.ElementAt(i).Columna
                        + "\n</td\n>"
                        + "</tr>\n";
            }
            page += "</tbody>\n";
            page += "</table>\n";
            page += "</div>\n";
            page += "</body>\n";
            page += "</HTML>";
            File.WriteAllText("Reporte Error.html", page);
            System.Diagnostics.Process.Start("Reporte Error.html");
        }
    }
}
