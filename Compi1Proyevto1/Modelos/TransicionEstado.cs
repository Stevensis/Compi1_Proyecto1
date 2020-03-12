using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class TransicionEstado //TRANSICION DE LOS TERMINALES EN LA TABLA DE TRANSICIONES
    {
        private Token terminal;
        private Estado Estado;

        public TransicionEstado(Token terminal, Estado estado)
        {
            this.terminal = terminal;
            Estado = estado;
        }

        public TransicionEstado()
        {
        }

        public Token Terminal { get => terminal; set => terminal = value; }
        public Estado Estado1 { get => Estado; set => Estado = value; }
    }
}
