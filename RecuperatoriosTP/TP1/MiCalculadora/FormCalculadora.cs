using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("+");
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Convierte el resultado a binario de existir y lo muestra en la etiqueta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;
            if (!(String.IsNullOrEmpty(resultado)))
            {
                Numero auxNumero = new Numero();
                string resultadoBinario = auxNumero.DecimalBinario(resultado);
                this.lblResultado.Text = resultadoBinario;
            }
        }

        /// <summary>
        /// Convierte el resultado a decimal de existir y lo muestra en la etiqueta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;
            if (!(String.IsNullOrEmpty(resultado)))
            {
                Numero auxNumero = new Numero();
                string resultadoDecimal = auxNumero.BinarioDecimal(resultado);
                this.lblResultado.Text = resultadoDecimal;
            }
        }

        /// <summary>
        /// Llama a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Opera entre los numeros ingresados por el usuario y muestra el resultado en la etiqueta
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double calculo = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = calculo.ToString();
        }

        /// <summary>
        /// Limpia todos los valores del formulario
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Opera entre los numeros recibidos con el metodo Operar
        /// </summary>
        /// <param name="numero1">Primero numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            double resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            return resultado;
        }
    }
}
