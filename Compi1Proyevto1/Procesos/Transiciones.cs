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
        public Transiciones(Thompson thompson)
        {
            this.Tabla = new List<Estado>();
            this.thompson = thompson;
            CerraduraI = cerraduraX(0);
            CerraduraI.Sort();
            Tabla.Add(new Estado(CerraduraI,"A")); //CREAMOS  el primer estado
            ir(Tabla.ElementAt(0));
            pintar();
        }

        public List<int> CerraduraI1 { get => CerraduraI; set => CerraduraI = value; }

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

        public void ir(Estado estado) {
            foreach (var item in thompson.Terminales)
            {
                List<int> ter = new List<int>();
                foreach (var k in estado.Cerradura)
                {
                    foreach (var t in thompson.Raiz.Transiciones)
                    {
                        if (t.State_from == k && t.Trans_symbol.Valor==item.Valor)
                        {
                            ter.Add(t.State_to);
                        }
                    }
                }
                ter.Sort();
                if (estado.Cerradura == ter && ter.Count() > 0)
                {
                    estado.Transicion.Add(new TransicionEstado(item, estado));
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
                    Estado estado1 = new Estado(cerraduraTemp, "" + c);
                    Tabla.Add(estado1);
                    estado.Transicion.Add(new TransicionEstado(item, estado1));
                }
                else {
                    estado.Transicion.Add(new TransicionEstado(item, new Estado(null,"--")));
                }
            }
        }

        public void pintar() {
            foreach (var item in Tabla)
            {
                Console.Write("--");
                Console.Write(" Estado " +item.Name +" tiene :");
                foreach (var item2 in item.Cerradura)
                {
                    Console.Write(item2);
                }
                Console.WriteLine(" Mueve a: ");
                foreach (var item1 in item.Transicion)
                {
                    Console.Write(item1.Estado1.Name+" Con "+item1.Terminal.Valor +" --| ");
                }
            }            
        }
  
    }
}
