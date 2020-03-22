using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class Token
    {
        //Se enumeran las posibilidades de tipos que puede ser un token (para llevar un orden)
        public enum Tipo
        {
            PALABRA_R,
            CADENA,
            COMENTARIO_L,
            COMENTARIO_ML,
            LLAVE_IZ,
            LLAVE_DE,
            PUNTO_Y_C,
            COMILLAS,
            PORCENTAJE,
            ID,
            NUMERO_ENTERO,
            LETRA,
            DIAGONAL,
            MENORQUE,
            EXCLAMACION,
            MAYORQUE,
            MENOS,
            EQUIVALENCIA,
            ASTERISCO,
            COMA,
            BARRA_V,
            PUNTO,
            MAS,
            INTERROGACION_DE,
            DOS_PUNTOS,
            SIGNO,
            NUMERAL,
            EPSILON
        }
        private Tipo tipoToken;
        private String valor; //El Contenido del token
        private String tipoTokenString;
        private int contadorToken;
        private int fila;
        private int columna;

        public Tipo TipoToken { get => tipoToken; set => tipoToken = value; }
        public string Valor { get => valor; set => valor = value; }
        public int ContadorToken { get => contadorToken; set => contadorToken = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public string TipoTokenString { get => tipoTokenString; set => tipoTokenString = value; }

        public String getTipo()
        {
            switch (tipoToken)
            {
                case Tipo.PALABRA_R:
                    return "PALABRA_RESERVADA";
                case Tipo.CADENA:
                    return "CADENA";
                case Tipo.LLAVE_IZ:
                    return "LLAVE_IZQUIERDA";
                case Tipo.LLAVE_DE:
                    return "LLAVE_DERECHA";
                case Tipo.COMENTARIO_L:
                    return "COMENTARIO_LINEA";
                case Tipo.COMENTARIO_ML:
                    return "COMENTARIO_MULTI_LINEAS";
                case Tipo.PUNTO_Y_C:
                    return "PUNTO_Y_COMA";
                case Tipo.PORCENTAJE:
                    return "PORCENTAJE";
                case Tipo.COMILLAS:
                    return "COMILLAS";
                case Tipo.ID:
                    return "ID";
                case Tipo.LETRA:
                    return "LETRA";
                case Tipo.DIAGONAL:
                    return "DIAGONAL";
                case Tipo.MENORQUE:
                    return "MENOR_QUE";
                case Tipo.EXCLAMACION:
                    return "EXCLAMACION";
                case Tipo.MAYORQUE:
                    return "MAYOR_QUE";
                case Tipo.MENOS:
                    return "MENOS";
                case Tipo.EQUIVALENCIA:
                    return "EQUIVALENCIA";
                case Tipo.ASTERISCO:
                    return "ASTERISCO";
                case Tipo.COMA:
                    return "COMA";
                case Tipo.BARRA_V:
                    return "BARRA_VERTICAL";
                case Tipo.PUNTO:
                    return "PUNTO";
                case Tipo.MAS:
                    return "MAS";
                case Tipo.INTERROGACION_DE:
                    return "INTERROGACION_DERECHA";
                case Tipo.DOS_PUNTOS:
                    return "DOS_PUNTOS";
                case Tipo.SIGNO:
                    return "SIGNO";
                case Tipo.NUMERO_ENTERO:
                    return "NUMERO_ENTERO";
                case Tipo.EPSILON:
                    return "EPSILON";
                default:
                    return "";
                
            }

        }
        public Token(Tipo tipoToken, string valor, int contadorToken, int fila, int columna)
        {
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.contadorToken = contadorToken;
            this.fila = fila;
            this.columna = columna;
        }

        public Token(string valor, string tipoTokenString, int contadorToken, int fila, int columna)
        {
            this.valor = valor;
            this.tipoTokenString = tipoTokenString;
            this.contadorToken = contadorToken;
            this.fila = fila;
            this.columna = columna;
        }
    }
}
