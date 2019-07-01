using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Propiedades
        /// <summary>
        /// Establece el valor del numero previa validacion
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de numero
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Constructor parametrizado de numero
        /// </summary>
        /// <param name="numero">Valor a inicializar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor parametrizado de numero
        /// </summary>
        /// <param name="strNumero">El numero en formato string</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el string recibido sea un numero decimal
        /// </summary>
        /// <param name="strNumero">EL string a validar</param>
        /// <returns>Devuelve el numero decimal si es correcto o CERO si no lo es</returns>
        private double ValidarNumero(string strNumero)
        {
            double auxNumero;
            if (!Double.TryParse(strNumero, out auxNumero))
            {
                auxNumero = 0;
            }
            return auxNumero;
        }

        /// <summary>
        /// Convierte un numero binario en string a numero decimal, previa validacion del binario
        /// </summary>
        /// <param name="binario">El numero binario en forma de string</param>
        /// <returns>Devuelve un string con el numero decimal o "Valor invalido" en caso de error</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            bool esBinario = true;
            int auxNumero;
            if(!string.IsNullOrEmpty(binario))
            {
                foreach (char letra in binario)
                {
                    if (!(letra.Equals('1')) && !(letra.Equals('0')))
                    {
                        esBinario = false;
                        break;
                    }
                }
                if (esBinario)
                {
                    auxNumero = Convert.ToInt32(binario, 2);
                    retorno = auxNumero.ToString();
                }
            }        
            return retorno;
        }

        /// <summary>
        /// Convierte el absoluto de un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">El numero decimal</param>
        /// <returns>EL numero binario en string</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "";
            int auxNumero;
            try
            {
                auxNumero = Convert.ToInt32(Math.Abs(numero));
                retorno = Convert.ToString(auxNumero, 2);
            } catch (Exception e)
            {
                retorno = "Valor invalido";
            }
            
            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en string a numero binario, previa validacion del decimal
        /// </summary>
        /// <param name="numero">El numero decimal en string</param>
        /// <returns>El numero binario en string</returns>
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
        #endregion

        #region Sobrecarga operadores
        /// <summary>
        /// Realiza la resta entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre dos numeros, validando la division por cero
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El resultado de la operacion o el valor minimo de un double en caso de division por cero</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}
