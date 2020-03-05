using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class Error
    {
        private String valor;
        private int contadorE;
        private int fila;
        private int columna;
        private String descripcion;

        public Error(string valor, int contadorE, int fila, int columna, string descripcion)
        {
            this.valor = valor;
            this.contadorE = contadorE;
            this.fila = fila;
            this.columna = columna;
            this.descripcion = descripcion;
        }

        public string Valor { get => valor; set => valor = value; }
        public int ContadorE { get => contadorE; set => contadorE = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
