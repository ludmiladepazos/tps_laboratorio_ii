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

        /// <summary>
        /// En el evento formclosing pregunta si el usuario desea cancelar el cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                
            }
        }

        /// <summary>
        /// Al hacer click en el boton cerrar pregunta si queremos ejecutar el cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// En el evento load del formulario lo limpia, para que inicie vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e) //llama al metodo limpiar
        {
            this.Limpiar();
        }

        /// <summary>
        /// El boton limpiar, limpia todos los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e) //llama a limpiar borra textbox combox y label
        {
            this.Limpiar();
        }

        /// <summary>
        /// este metodo limpia lo ingresado en el textbox, combobox, label y list de operaciones
        /// </summary>
        private void Limpiar() 
        {
            textNumero1.Clear();
            textNumero2.Clear();
            cmbOperador.Text = string.Empty;
            lblResultado.Text = "0";
            lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// Segun los numeros ingresados y el operador seleccionado realiza la operacion
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns> en caso de exito retorna el resultado de la operacion, 0 en caso de no haberla podido realizar
        private static double Operar(string numero1, string numero2, string operador) 
        {
            double resultado = 0;
            char auxOperador;
            
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(numero2)) 
            {
                Operando num1 = new Operando(numero1);
                Operando num2 = new Operando(numero2);
                char.TryParse(operador, out auxOperador);
                resultado = Calculadora.Operar(num1, num2, auxOperador);
            }
            
            return resultado;
        }

        /// <summary>
        /// Este evento acciona la operacion ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            
            StringBuilder resultadoDisplay = new StringBuilder();

            if (!string.IsNullOrEmpty(textNumero1.Text) && !string.IsNullOrEmpty(textNumero2.Text) && double.TryParse(textNumero1.Text, out double numero1) && double.TryParse(textNumero2.Text, out double numero2))
            {
                resultado = Operar(textNumero1.Text, textNumero2.Text, cmbOperador.Text);

                this.lblResultado.Text = resultado.ToString();

                resultadoDisplay.AppendLine(textNumero1.Text + cmbOperador.Text + textNumero2.Text + " = " + resultado);

                this.lstOperaciones.Items.Add(resultadoDisplay);

                if (resultado == double.MinValue)
                {
                    MessageBox.Show("No es posible divivir por cero");

                }
            }
            else 
            {
                MessageBox.Show("Ingrese numeros no letras");
            }
            
        }

        /// <summary>
        /// Acciona la conversion del resultado obtenido de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numBinario = new Operando();
            string resultadoBinario;
            resultadoBinario = numBinario.DecimalBinario(lblResultado.Text);
            lblResultado.Text = resultadoBinario;
            lstOperaciones.Items.Add(resultadoBinario.ToString());
        }

        /// <summary>
        /// acciona la conversion del numero binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numDecimal = new Operando();
            string resultadoDecimal;
           
            resultadoDecimal = numDecimal.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = resultadoDecimal;
            lstOperaciones.Items.Add(resultadoDecimal.ToString());
        }
    }
}
