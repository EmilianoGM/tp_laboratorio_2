using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;
        private string SetNumero
        {
            set { _numero = this.ValidarNumero(value); }
        }
        #region Constructores
        public Numero() : this(0)
        {
        }
        public Numero(double numero)
        {
            _numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion
        #region Metodos
        private double ValidarNumero(string strNumero)
        {
            double auxNumero;
            if (!Double.TryParse(strNumero, out auxNumero))
            {
                auxNumero = 0;
            }
            return auxNumero;
        }
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            bool flag = true;
            int auxNumero;
            foreach (char letra in binario)
            {
                if (!(letra.Equals('1')) && !(letra.Equals('0')))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                auxNumero = Convert.ToInt32(binario, 2);
                retorno = auxNumero.ToString();
            }
            return retorno;
        }
        public string DecimalBinario(double numero)
        {
            string retorno;
            int auxNumero;
            auxNumero = Convert.ToInt32(Math.Abs(numero));
            retorno = Convert.ToString(auxNumero, 2);
            return retorno;
        }
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double auxNumero;
            if (Double.TryParse(numero, out auxNumero))
            {
                retorno = this.DecimalBinario(auxNumero);
            }
            return retorno;
        }
        #region Sobrecarga operadores
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }
        #endregion
        #endregion
    }
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string auxOperador = Calculadora.ValidarOperador(operador);
            Numero casoCero = new Numero();
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
                    numRetorno = Double.MinValue;
                    if (num1 + num2 != num1 + casoCero)
                    {
                        numRetorno = num1 / num2;
                    }
                    break;
                case "+":
                    numRetorno = num1 + num2;
                    break;
            }
            return numRetorno;
        }
        private static string ValidarOperador(string operador)
        {
            if (String.Equals(operador, "-") || String.Equals(operador, "*") || String.Equals(operador, "/") || String.Equals(operador, "+"))
            {
                return operador;
            }
            return "+";
        }
    }
}