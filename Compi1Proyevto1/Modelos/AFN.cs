﻿using System;
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

        public string dot()
        {
            String cadena = "";
            cadena+= "size =\"4,4\";\n";
            foreach (var item in transiciones)
            {
                cadena += item.State_from + " -> "+ item.State_to + " [label=\""+ item.Trans_symbol.Valor +" \"];" + "\n";
            }
            return cadena;
        }
    }
}