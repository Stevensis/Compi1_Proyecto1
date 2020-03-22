using Compi1Proyevto1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Procesos
{
    class Validacion_Lexema
    {
        private String cadena,expresionName;
        private List<Conjunto> conjuntos;
        private List<Thompson> expresiones;
        private bool valido = false, comp = true;
        private Thompson aux;
        private Estado estadoActual;
        private int i=0;

        public Estado EstadoActual { get => estadoActual; set => estadoActual = value; }
        public string Cadena { get => cadena; set => cadena = value; }
        public string ExpresionName { get => expresionName; set => expresionName = value; }

        private int contadorTk = 0, contadorErro=0;
        private List<Token> lstToken = new List<Token>();
        private List<Error> lstErrores = new List<Error>();
        public bool Valido { get => valido; set => valido = value; }
        public List<Token> LstToken { get => lstToken; set => lstToken = value; }
        public List<Error> LstErrores { get => lstErrores; set => lstErrores = value; }

        public Validacion_Lexema(string cadena, string expresionName, List<Conjunto> conjuntos, List<Thompson> expresiones)
        {
            this.cadena = cadena;
            this.expresionName = expresionName;
            this.conjuntos = conjuntos;
            this.expresiones = expresiones;
            aux = searchTransicion();
            estadoActual = aux.Transiciones.Tabla1.ElementAt(0);
            if (aux!= null)
            {
                validacion();
            }
        }

        public void validacion() {
            char c;
            int fila = 0, columna = 0, columnaiT;
            for (int i = 0; i < cadena.Length; i++)
            {
                
                c = cadena.ElementAt(i);
                
                if (c == '\n') { fila++; columna = 0; } else { columna++; } // Va tener el conteneo de filas y columnas
                bool v = false;
                foreach (var item in estadoActual.Transicion)
                {
                    if (item.Estado1.Name!="--")
                    {
                        switch (item.Terminal.TipoToken)
                        {
                            case Token.Tipo.ID:
                                if (searchConjunto(item.Terminal.Valor).Conjuntoo.Contains(c))
                                {
                                    estadoActual = item.Estado1;
                                    v = true;
                                    valido = true;
                                    agregarTk(c+"","Conjunto "+item.Terminal.Valor,fila,columna);
                                }
                                break;
                            case Token.Tipo.CADENA:
                                String temp = "" + c;
                                int contador = i;
                                for (int j = 1; j < item.Terminal.Valor.Length; j++)
                                {
                                    contador++;
                                    temp += cadena.ElementAt(contador);
                                }
                                if (item.Terminal.Valor.Equals(temp))
                                {
                                    i += item.Terminal.Valor.Length - 1;
                                    estadoActual = item.Estado1;
                                    v = true;
                                    valido = true;
                                    agregarTk(temp,temp, fila, columna);
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    if (v) //Si ya cambio de esta rompe el ciclo del estado que se estaba analizando
                    {
                        break;
                    }
                    if (!v && item == estadoActual.Transicion.ElementAt(estadoActual.Transicion.Count-1)) 
                    {
                        //Si ya llego a la ultima transicion del estado y no encontro un estado al cual alcanzar se termina todos los ciclos y es falso
                        i = cadena.Length;
                        valido = false;
                        agregarError(c+"",fila,columna,"Del estado: "+estadoActual.Name+" no se puede alcanzar otro estado con este caracter");
                    }
                }
            }
            if (!estadoActual.Aceptacion) //Si el ultimo estado que alcanzo no es de aceptacion, entonces la cadena es invalida
            {
                valido = false;
            }
        }

        public Thompson searchTransicion() { //busca la expresion ah evaluar
            foreach (var item in this.expresiones)
            {
                if (item.NameEr.Equals(this.expresionName))
                {
                    return item;
                }
            }
            return null;
        }

        public Conjunto searchConjunto(String id) { //Retornara un conjunto con respecto al id
            foreach (var item in conjuntos)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }

        public void agregarTk(string valor, string tipoTokenString, int fila, int columna) {
            contadorTk++;
            lstToken.Add(new Token(valor,tipoTokenString,contadorTk,fila,columna));
        }

        public void agregarError(string valor, int fila, int columna, string descripcion) {
            contadorErro++;
            lstErrores.Add(new Error(valor,contadorErro,fila,columna,descripcion));
        }
    }
}
