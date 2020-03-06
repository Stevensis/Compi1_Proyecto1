using Compi1Proyevto1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Procesos
{
    class AnalizarTokens
    {
        private LinkedList<Token> listaTokens;
        private List<Conjunto> lstConjunto = new List<Conjunto>();

        public AnalizarTokens(LinkedList<Token> listaTokens)
        {
            this.listaTokens = listaTokens;
        }

        public List<Conjunto> LstConjunto { get => lstConjunto; set => lstConjunto = value; } //Contendra la lista de conjuntos con su respectico ID

        public void analizarTokens() {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                switch (listaTokens.ElementAt(i).TipoToken) //Se analizara por el tipo de token
                {
                    case Token.Tipo.PALABRA_R:
                        i++;
                        i++;
                        if (listaTokens.ElementAt(i).TipoToken == Token.Tipo.ID)
                        {
                            Conjunto conjunto = new Conjunto();
                            conjunto.Id=listaTokens.ElementAt(i).Valor;
                            i++;
                            i++;
                            i++;
                            i++;
                            if (listaTokens.ElementAt(i).TipoToken == Token.Tipo.EQUIVALENCIA)
                            { //Si es una equivalencia va regresar un token antes para optener su ascci
                                int start = (int)listaTokens.ElementAt(i - 1).Valor.ElementAt(0);
                                i++; //Se adelante un token para optner el ascii donde va terminar
                                int finish = (int)listaTokens.ElementAt(i).Valor.ElementAt(0);
                                conjunto.Conjuntoo=generarConjuntos(start, finish);
                                i++;
                            }
                            else if (listaTokens.ElementAt(i).TipoToken == Token.Tipo.COMA)
                            {
                                i--;//Regresamos al primer caracter de los conjuntos
                                List<char> lstChar = new List<char>();
                                do
                                {
                                    if (listaTokens.ElementAt(i).TipoToken != Token.Tipo.COMA)
                                    {
                                        lstChar.Add(listaTokens.ElementAt(i).Valor.ElementAt(0));
                                        i++;
                                    }
                                    else { i++; }
                                } while (listaTokens.ElementAt(i).TipoToken != Token.Tipo.PUNTO_Y_C);
                                conjunto.Conjuntoo=lstChar;
                            }
                            lstConjunto.Add(conjunto);
                        }
                        break;
                    case Token.Tipo.CADENA:
                        break;
                    case Token.Tipo.COMENTARIO_L:
                        break;
                    case Token.Tipo.COMENTARIO_ML:
                        break;
                    case Token.Tipo.LLAVE_IZ:
                        break;
                    case Token.Tipo.LLAVE_DE:
                        break;
                    case Token.Tipo.PUNTO_Y_C:
                        break;
                    case Token.Tipo.COMILLAS:
                        break;
                    case Token.Tipo.PORCENTAJE:
                        break;
                    case Token.Tipo.ID:
                        break;
                    case Token.Tipo.NUMERO_ENTERO:
                        break;
                    case Token.Tipo.LETRA:
                        break;
                    case Token.Tipo.DIAGONAL:
                        break;
                    case Token.Tipo.MENORQUE:
                        break;
                    case Token.Tipo.EXCLAMACION:
                        break;
                    case Token.Tipo.MAYORQUE:
                        break;
                    case Token.Tipo.MENOS:
                        break;
                    case Token.Tipo.EQUIVALENCIA:
                        break;
                    case Token.Tipo.ASTERISCO:
                        break;
                    case Token.Tipo.COMA:
                        break;
                    case Token.Tipo.BARRA_V:
                        break;
                    case Token.Tipo.PUNTO:
                        break;
                    case Token.Tipo.MAS:
                        break;
                    case Token.Tipo.INTERROGACION_DE:
                        break;
                    case Token.Tipo.DOS_PUNTOS:
                        break;
                    case Token.Tipo.SIGNO:
                        break;
                    case Token.Tipo.NUMERAL:
                        break;
                    default:
                        break;
                }
            }
        }

        //va devolver una lista(de los conjuntos)
        public List<char> generarConjuntos(int inicio, int fin)
        {
            List<char> lstChar = new List<char>();
            for (int i = inicio; i <= fin; i++)
            {
                lstChar.Add((char)i);
            }
            return lstChar;
        }
    }
}
