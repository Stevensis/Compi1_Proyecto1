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
        String nameEr; //Nombre de la expresion regular
        AFN raiz; //Contendra el AFN Final (que sera una lista de transiciones)
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
                case Token.Tipo.PUNTO: //Operacion .
                    i++;
                    AFN n = create(); //esperamos el primer tramo de mini AFN
                    AFN m = create(); //esperamos el segundo tramo de mini AFN con el que queremos concatenar
                    AFN resultadoConcat = AFNConcat(n,m);
                    return resultadoConcat;
                    break;
                case Token.Tipo.BARRA_V: // Operacion |
                    i++;
                    AFN nOr = create(); //esperamos el primer tramo de mini AFN
                    AFN mOr = create(); //esperamos el segundo tramo de mini AFN con el que queremos hacer la union
                    AFN resultado = AFNUnion(nOr,mOr);
                    return resultado;
                    break;
                case Token.Tipo.ASTERISCO: // Operacion *
                    i++;
                    AFN nKleene = create();
                    AFN resultadoK = AFNKleene(nKleene);
                    return resultadoK;
                    break;
                case Token.Tipo.MAS: //Operacion +
                    i++;
                    AFN nMas = create(); //Optenemos a
                    AFN nMasWithKleend = AFNKleene(nMas); //Optenemos a*
                    AFN resultadoMas = AFNConcat(nMasWithKleend,nMas); //Optenemos .a*a
                    return resultadoMas;
                    break;
                case Token.Tipo.INTERROGACION_DE: //Operacion ?
                    i++;
                    AFN nInterogacion = create(); //Optenemos a
                    AFN nEpsilon = AFNTerminal(new Token(Token.Tipo.EPSILON, "ε", 0,0,0)); //Optenemos ε
                    AFN resultadoInterrogacion = AFNUnion(nInterogacion,nEpsilon); //Optenemos |aε
                    return resultadoInterrogacion;
                    break;
                case Token.Tipo.CADENA:
                    AFN afnCadena = AFNTerminal(er.ElementAt(i));
                    return afnCadena;
                    break;
                case Token.Tipo.ID:
                    AFN afnId = AFNTerminal(er.ElementAt(i));
                    return afnId;
                    break;
                default:
                    i++;
                    break;
            }
            return null;
        }

        //Meoto para hacer la union de 2 miniautomatas
        public AFN AFNUnion(AFN n, AFN m) {
            //Para la union lo que se hace es agarrar el primer mini automata, agarrar el segundo mini automata
            //Hacer un estado con al inicio que apunte con epsilon a ambos mini automatas
            //lugo hacer un estado que los dos mini automatas apuntan a ese estado con epsilon
            //Con este algoritmo se determina que el nuevo AFN que resulta tiene un tamaño, del primer mini automata mas el segundo y se le suma 2 estados mas
            //que seran el se inicio y el de fin
            AFN result = new AFN(n.Estados.Count()+m.Estados.Count()+2);//Se crea el nuevo nimi automata y se le determina el tamaño de estados que contendra
            result.Transiciones.Add(new Transicion(0,1,new Token(Token.Tipo.EPSILON, "ε",0,0,0))); //creamos la transicion de inicio 
            foreach (var item in n.Transiciones) //se recorren las transisciones de n para crear nuevas transiciones que iran al nuevo mini automata
            {
                result.Transiciones.Add(new Transicion(item.State_from + 1, item.State_to + 1, item.Trans_symbol)); //Se vuelve a rescribir las transiciones de n en result, pero con las transiciones de n corrido uno el valor de sus estados
            }
            result.Transiciones.Add(new Transicion(n.Estados.Count(),n.Estados.Count()+m.Estados.Count()+1,new Token(Token.Tipo.EPSILON, "ε", 0, 0, 0))); //Se crea la transicion de n al estado final
            result.Transiciones.Add(new Transicion(0,n.Estados.Count()+1,new Token(Token.Tipo.EPSILON, "ε", 0, 0, 0))); //Creamos la transicion de 0 al mini estado m
            foreach (var item in m.Transiciones) //se recorren las transisciones de m para crear nuevas transiciones que iran al nuevo mini automata
            {
                result.Transiciones.Add(new Transicion(item.State_from+n.Estados.Count()+1,item.State_to+n.Estados.Count()+1,item.Trans_symbol));//Se vuelve a rescribir las transiciones de m en result, pero con las transiciones de m corridos segun el tamaño de los estados de n, para llevar una secuencia de estados
            }
            result.Transiciones.Add(new Transicion(m.Estados.Count() + n.Estados.Count(), m.Estados.Count() + n.Estados.Count() + 1, new Token(Token.Tipo.EPSILON, "ε", 0, 0, 0))); //Se crea la transicion de m con el estado final
            result.EstadoFinal = n.Estados.Count() + m.Estados.Count() + 1; //Indicamos cual es el estado final
            return result;
        }

        //Metodo para hacer la cerradura de kleene
        public AFN AFNKleene(AFN n) {
            Token token = new Token(Token.Tipo.EPSILON, "ε",0,0,0);
            //apartir de un mini estado n, se agregaran 2 estados nuevos que se añadiran al inicio y al final saliendo de uno con un Epsilon y llegan al otro un epsilon tambien
            AFN result = new AFN(n.Estados.Count()+2); //primero crea un nuevo AFN que sera el que se retorne, la cantidad de estados sera igual a la cantidad de estados de n mas dos (que seran los de inico y fin)
            result.Transiciones.Add(new Transicion(0,1,token)); //Se añade una nueva transicion que sera la transicion de inicio, la cual apunta de 0 a 1 con Epsilon

            foreach (var item in n.Transiciones) //Se recore las transicion de n para reescribirlas en result
            {
                result.Transiciones.Add( new Transicion(item.State_from+1,item.State_to+1,item.Trans_symbol)); //cada transicion se correra un valor los estados
            }
            result.Transiciones.Add(new Transicion(n.Estados.Count(), n.Estados.Count() + 1, token)); //el final de n apuntara a otro estado con Epsilon
            result.Transiciones.Add(new Transicion(0, n.Estados.Count() + 1, token)); //El estado 0 apuntara al final del AFN con epsilon
            result.Transiciones.Add(new Transicion(n.Estados.Count(),1,token)); //el final de n apuntara al inicio de n con Epsilon
            return result;
        }
        //Metodo para hacer la concatenaciond e 2 miniautomatas
        public AFN AFNConcat(AFN n, AFN m) {
            m.Estados.Remove(0); //removemos el primer estado de el segundo tramo
            foreach (var item in m.Transiciones) //Se ara la union de ambos
            {
                //Se rescribe las transiciones m en n con la diferencia que las nuevas transiciones que son de m estan corridas un valor su estado
                n.Transiciones.Add(new Transicion(item.State_from + n.Estados.Count() - 1, item.State_to + n.Estados.Count() - 1, item.Trans_symbol));
            }
            foreach (var item in m.Estados)
            {
                n.Estados.Add(item + n.Estados.Count() + 1);
            }
            n.EstadoFinal = n.Estados.Count() + m.Estados.Count() - 2;
            return n;
        }
        //Retornara un Mini AFN que sera solo de un estado 0 a un estado 1 con un terminal t
        public AFN AFNTerminal(Token t) {
            AFN afnCadena = new AFN(t); //Se crea un mini AFN de 2 estados, inicio y final y es alcansable con el terminal CADENA
            i++;
            return afnCadena;
        }
    }
}
