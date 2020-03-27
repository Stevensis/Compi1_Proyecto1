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
        private List<Thompson> lstThompson = new List<Thompson>();
        private List<Validacion_Lexema> lstLexamas = new List<Validacion_Lexema>();

        public AnalizarTokens(LinkedList<Token> listaTokens)
        {
            this.listaTokens = listaTokens;
        }

        public List<Conjunto> LstConjunto { get => lstConjunto; set => lstConjunto = value; } //Contendra la lista de conjuntos con su respectico ID
        public List<Thompson> LstThompson { get => lstThompson; set => lstThompson = value; }
        public List<Validacion_Lexema> LstLexamas { get => lstLexamas; set => lstLexamas = value; }

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
                            else if (listaTokens.ElementAt(i).TipoToken==Token.Tipo.DOS_PUNTOS)
                            {
                                i++;
                                List<char> lstChar = new List<char>();
                                for (int j = 32; j < 127; j++)
                                {
                                    lstChar.Add((char) j);
                                }
                                conjunto.Conjuntoo = lstChar;
                            }
                            lstConjunto.Add(conjunto);
                        }
                        break;
                    
                    case Token.Tipo.ID:
                        String nameEr = listaTokens.ElementAt(i).Valor;
                        i++;
                        if (listaTokens.ElementAt(i).TipoToken== Token.Tipo.MENOS)
                        {
                            List<Token> er = new List<Token>();
                            i++;
                            i++;
                            do
                            {
                                if (listaTokens.ElementAt(i).TipoToken != Token.Tipo.LLAVE_IZ && listaTokens.ElementAt(i).TipoToken != Token.Tipo.LLAVE_DE)
                                {
                                    er.Add(listaTokens.ElementAt(i));
                                    i++;
                                }
                                else
                                {
                                    i++;
                                }
                                
                            } while (listaTokens.ElementAt(i).TipoToken != Token.Tipo.PUNTO_Y_C);
                            Thompson thompson = new Thompson(er,nameEr);
                            Transiciones transiciones = new Transiciones(thompson);
                            thompson.Transiciones = transiciones;
                            lstThompson.Add(thompson);
                        }
                        else if (listaTokens.ElementAt(i).TipoToken == Token.Tipo.DOS_PUNTOS)
                        {
                            i++;
                            Validacion_Lexema validacion_Lexema = new Validacion_Lexema(listaTokens.ElementAt(i).Valor,nameEr,lstConjunto,LstThompson);
                            
                            LstLexamas.Add(validacion_Lexema);
                            i++;
                        }
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
