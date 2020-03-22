using Compi1Proyevto1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Procesos
{
    class Transiciones //TABLA DE TRANSICIONES
    {
        Thompson thompson;
        private List<int> CerraduraI; //Guardara la cerradura inicial
        private List<Estado> Tabla; //Conotendra la tabla de estados
        private Queue<Estado> colaEstados = new Queue<Estado>();   
        public Transiciones(Thompson thompson)
        {
            this.Tabla = new List<Estado>();
            this.thompson = thompson;
            List<int> cabezera = new List<int>();
            cabezera.Add(0);
            CerraduraI = cerraduraX(0);
            CerraduraI.Sort();
            Tabla.Add(new Estado(CerraduraI,"A",cabezera)); //CREAMOS  el primer estado
            colaEstados.Enqueue(Tabla.ElementAt(0));
            ir();
            pintar();
        }

        public List<int> CerraduraI1 { get => CerraduraI; set => CerraduraI = value; }
        public List<Estado> Tabla1 { get => Tabla; set => Tabla = value; }

        List<int> cerraduraX(int j) { //Metodo que va optener la cerradura inicial 
            List<int> resultado = new List<int>();
            resultado.Add(j); //Todos tienen una transicion con epsilon con ellos mismos
            foreach (var item in thompson.Raiz.Transiciones)
            {
                if (item.Trans_symbol.TipoToken == Token.Tipo.EPSILON && item.State_from==j)
                {
                    resultado.AddRange(cerraduraX(item.State_to)); //Cada estado alcanzable con Epsilon
                }
            }
            return resultado;
        }

        public void ir() {
            do
            {
                Estado estado = colaEstados.Dequeue();
                foreach (var item in thompson.Terminales)
                {
                    List<int> ter = new List<int>();
                    foreach (var k in estado.Cerradura)
                    {
                        foreach (var t in thompson.Raiz.Transiciones)
                        {
                            if (t.State_from == k && t.Trans_symbol.Valor == item.Valor)
                            {
                                ter.Add(t.State_to);
                            }
                        }
                    }
                    ter.Sort();
                    Estado temp = estadoExistente(ter);
                    if (temp != null && ter.Count() > 0)
                    {
                        estado.Transicion.Add(new TransicionEstado(item, temp));
                    }
                    else if (ter.Count() > 0)
                    {
                        List<int> cerraduraTemp = new List<int>();
                        foreach (var o in ter)
                        {
                            cerraduraTemp.AddRange(cerraduraX(o));
                        }
                        cerraduraTemp.Sort();
                        int tempEstado = ((int)Tabla.ElementAt(Tabla.Count() - 1).Name.ElementAt(0)) + 1;
                        char c = (char)tempEstado;
                        Estado estado1 = new Estado(cerraduraTemp, "" + c,ter);
                        Tabla.Add(estado1);
                        colaEstados.Enqueue(estado1);
                        estado.Transicion.Add(new TransicionEstado(item, estado1));
                    }
                    else
                    {
                        estado.Transicion.Add(new TransicionEstado(item, new Estado(null, "--")));
                    }
                }
            } while (colaEstados.Count>0);
            
        }

        public void pintar() {
            foreach (var item in Tabla)
            {
                if (item.Cerradura.Contains(thompson.Raiz.Estados.Count() - 1))
                {
                    item.Aceptacion = true;
                }
            }           
        }

        public String dot() {
            String cadena = "\n";
            cadena += "size =\"30\";\n";
            cadena += "node[ shape = none, fontname = \"Arial\" ]; \n";
            cadena += "set1[ label=< \n";
            cadena += "<TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"4\"> \n";
            cadena += "<TR> \n";
            cadena += "<TD>Estado</TD> \n";
            foreach (var item in thompson.Terminales)
            {
                cadena += "<TD>\"" + item.Valor + "\"</TD> \n";
                
            }
            cadena += "</TR> \n";
            foreach (var item in Tabla)
            {
                cadena += "<TR> \n";
                if (item.Aceptacion)
                {
                    cadena += "<TD>" + item.Name + "*</TD> \n";
                }
                else
                {
                    cadena += "<TD>" + item.Name  + "</TD> \n";
                }
                foreach (var item1 in item.Transicion)
                {
                    cadena += "<TD>" + item1.Estado1.Name + "</TD> \n";
                }
                cadena += "</TR> \n";
            }
            cadena += "</TABLE>>];";
            return cadena;
        }

        public String dotTableC()
        {
            String cadena = "\n";
            cadena += "size =\"30\";\n";
            cadena += "node[ shape = none, fontname = \"Arial\" ]; \n";
            cadena += "set1[ label=< \n";
            cadena += "<TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"4\"> \n";
            cadena += "<TR> \n";
            cadena += "<TD>Estado</TD> \n";
            foreach (var item in thompson.Terminales)
            {
                cadena += "<TD>\"" + item.Valor + "\"</TD> \n";

            }
            cadena += "</TR> \n";
            foreach (var item in Tabla)
            {
                cadena += "<TR> \n";
                if (item.Aceptacion)
                {
                    cadena += "<TD>" + item.Name + " C(" + String.Join(",", item.Cabezera) + ")={" + String.Join(",", item.Cerradura) + "} "+  "*</TD> \n";
                }
                else
                {
                    cadena += "<TD>" + item.Name + " C(" + String.Join(",", item.Cabezera) + ")={"+ String.Join(",", item.Cerradura)+"} " + "</TD> \n";
                }
                foreach (var item1 in item.Transicion)
                {
                    if (item1.Estado1.Name.Equals("--"))
                    {
                        cadena += "<TD>" + item1.Estado1.Name + "</TD> \n";
                    }
                    else
                    {
                        cadena += "<TD>" + item1.Estado1.Name + " C(" + String.Join(",", item1.Estado1.Cabezera) + ") " + "</TD> \n";
                    }
                    
                }
                cadena += "</TR> \n";
            }
            cadena += "</TABLE>>];";
            return cadena;
        }

        public Estado estadoExistente(List<int> comparar) { //Nos indica si la cerradura que acabamos de crear ya existe
            Boolean existe = true;
            foreach (var item in Tabla)
            {
                foreach (var j in comparar)
                {
                    if (!item.Cabezera.Contains(j))
                    {
                        existe = false;
                    }
                }
                if (existe)
                {
                    return item;
                }
                else
                {
                    existe = true;
                }
            }
            return null;
        }

        public String dotAFD() {
            String cadena = "\n";
            cadena += "size =\"30\";\n";
            cadena += "rankdir=LR;\n";
            foreach (var item in Tabla)
            {
                if (item.Aceptacion)
                {
                    cadena += item.Name+ " [shape=\"doublecircle\"];\n";
                }
                else
                {
                    cadena += item.Name + " [shape=\"circle\"] ;\n";
                }
            }
            foreach (var item in Tabla)
            {
                foreach (var item2 in item.Transicion)
                {
                    if (!item2.Estado1.Name.Equals("--"))
                    {
                        cadena += item.Name + " -> " + item2.Estado1.Name + " [label=\"\\\"" + item2.Terminal.Valor + "\\\"\"];" + "\n";
                    }
                    
                }
            }
            return cadena;
        }
    }
}
