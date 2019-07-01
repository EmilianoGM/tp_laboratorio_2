using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion definida entre dos numeros, previa validacion del operador
        /// </summary>
        /// <param name="num1">Primero numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador en string</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string auxOperador = Calculadora.ValidarOperador(operador);
            double numRetorno = 0;
            switch (auxOperador)
            {
                case "-":
                    numRetorno = num1 - num2;
                    break;
                case "*":
                    numRetorno = num1 * num2;
                    break;
                case "/":
                    numRetorno = num1 / num2;
                    break;
                case "+":
                    numRetorno = num1 + num2;
                    break;
            }
            return numRetorno;
        }

        /// <summary>
        /// Valida que el string recibido sea un operador +,-,*,/
        /// </summary>
        /// <param name="operador">El string a validar</param>
        /// <returns>El operador recibido o el operador + en caso invalido</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (String.Equals(operador, "-") || String.Equals(operador, "*") || String.Equals(operador, "/"))
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
