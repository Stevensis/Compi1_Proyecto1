using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class Transicion //TRANSICION DE LOS MINI AFN
    {
        private int state_from, state_to;
        private Token trans_symbol;

        public Transicion(int state_from, int state_to, Token trans_symbol)
        {
            this.state_from = state_from;
            this.state_to = state_to;
            this.trans_symbol = trans_symbol;
        }

        public int State_from { get => state_from; set => state_from = value; }
        public int State_to { get => state_to; set => state_to = value; }
        public Token Trans_symbol { get => trans_symbol; set => trans_symbol = value; }
    }
}
