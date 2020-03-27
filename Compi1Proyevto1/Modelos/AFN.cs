using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class AFN
    {
        private List<int> estados;
        private List<Transicion> transiciones;
        private int estadoFinal;

        public List<int> Estados { get => estados; set => estados = value; }
        public List<Transicion> Transiciones { get => transiciones; set => transiciones = value; }
        public int EstadoFinal { get => estadoFinal; set => estadoFinal = value; }

        //Metodo va servir para cuando venda un terminal, creara un AFN de 2 estods
        //el estado 0 que es de donde viene y el estado 1 que es a donde va, con un simbolo de terminal Tk
        public AFN(Token Tk)
        {
            this.estados = new List<int>();
            this.transiciones = new List<Transicion>();
            this.setStateSize(2);
            this.estadoFinal = 1;
            this.transiciones.Add(new Transicion(0,1,Tk));
        }
        //Crea un AFN con un tamaño de estados producto de la union de 2 AFN 
        public AFN(int size) {
            this.Estados = new List<int>();
            this.transiciones = new List<Transicion>();
            this.estadoFinal = 0;
            this.setStateSize(size);
        }

        public void setStateSize(int size)
        {
            for (int i = 0; i < size; i++)
                this.estados.Add(i);
        }

        public string Display() {
            String cadena="";
            foreach (var item in transiciones)
            {
                cadena += "("+item.State_from+","+item.Trans_symbol.Valor+","+item.State_to+"\n";
            }
            return cadena;
        }
        //Metodo que crea el dot que contendra el AFN retornara el cuerpo del dot que sea distinto a digraph G { }
        public string dot()
        {
            String cadena = "";
            cadena+= "size =\"30\";\n";
            cadena += "rankdir=LR;";
            foreach (var item in transiciones)
             {
                String valor = item.Trans_symbol.Valor;
                valor = valor.Replace("\n", "/n");
                valor = valor.Replace("\t", "/t");
                valor = valor.Replace("\r", "/r");
                valor = valor.Replace("\"", "ComillaD");
                cadena += item.State_from + " [shape=\"circle\"]\n";
                 cadena += item.State_from + " -> "+ item.State_to + " [label=\"\\\""+ valor + "\\\"\"];" + "\n";
            }

            cadena += estados.Count() - 1 + " [shape=\"doublecircle\"]";
            return cadena;
        }
    }
}
