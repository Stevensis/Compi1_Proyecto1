using Compi1Proyevto1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Procesos
{
    class Thompson
    {
        int i=0;
        List<Token> er;
        String nameEr;
        AFN raiz;
        Stack<AFN> operadores = new Stack<AFN>();
        public Thompson(List<Token> er, string nameEr)
        {
            this.er = er;
            this.nameEr = nameEr;
            raiz = create();
        }

        public string NameEr { get => nameEr; set => nameEr = value; }
        public AFN Raiz { get => raiz; set => raiz = value; }

        public AFN create() {
            switch (er.ElementAt(i).TipoToken)
            {
                case Token.Tipo.PUNTO:
                    i++;
                    AFN n = create();
                    AFN m = create();
                    m.Estados.Remove(0);
                    foreach (var item in m.Transiciones)
                    {
                        n.Transiciones.Add(new Transicion(item.State_from+n.Estados.Count()-1,item.State_to+n.Estados.Count()-1,item.Trans_symbol));
                    }
                    foreach (var item in m.Estados)
                    {
                        n.Estados.Add(item + n.Estados.Count() + 1);
                    }
                    n.EstadoFinal = n.Estados.Count() + m.Estados.Count() - 2;
                    return n;
                    break;
                case Token.Tipo.CADENA:
                    AFN afnCadena = new AFN(er.ElementAt(i)); //Se crea un mini AFN de 2 estados, inicio y final y es alcansable con el terminal CADENA
                    i++;
                    return afnCadena;
                    break;
                case Token.Tipo.ID:
                    AFN afnId = new AFN(er.ElementAt(i)); //Se crea un mini AFN de 2 estados, inicio y final y es alcansable con el terminal ID
                    i++;
                    return afnId;  
                    break;
                default:
                    i++;
                    break;
            }
            return null;
        }
    }
}
