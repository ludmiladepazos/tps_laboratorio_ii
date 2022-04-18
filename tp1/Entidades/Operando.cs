using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Inicializa el numero en 0
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Asigna un valor double pasado por parametro al atributo numero
        /// </summary>
        /// <param name="numero"></param> numero el cual va a ser asignado a la instancia
        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// La propiedad numero asigna un valor en formato double al atributo numero
        /// </summary>
        private string Numero 
        {
            set 
            {
                this.numero = ValidarOperando(value);
            }
        }
        
        /// <summary>
        /// Recibe por parametro un string, si puede convertirlo en double retorna el numero, sino retorna un 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero) 
        {
            double numRetornado;
            
            if (double.TryParse(strNumero, out numRetornado))
            {
                return numRetornado;
            }
            //retorna un booleano, un true o false, si se pudo convertir o no

            return 0;
        }

        /// <summary>
        /// Valida que la cadena de caracteres recibida este compuesta solamente por caracteres '0' y '1'
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i].ToString() != "0" && binario[i].ToString() != "1")
                {
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// Convierte el string biario recibido en decimal previa evaluacion
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            int numEntero;
            string retorno = "Valor invalido";

            if (EsBinario(binario))
            {
                numEntero = Convert.ToInt32(binario, 2);
                if (numEntero > 0) 
                {
                    retorno = numEntero.ToString();
                }
                    
            }
            return retorno;
        }

        /// <summary>
        /// convertira un número decimal a binario, en caso de ser posible. 
        /// Caso contrario retornará "Valor inválido"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string numBinario = "";
            long resto;
            long numCociente = (long)numero;

            while (numCociente > 0)
            {
                resto = numCociente % 2;
                numCociente = numCociente / 2;

                if (resto != 0)
                {
                    numBinario = "1" + numBinario;
                }
                else
                {
                    numBinario = "0" + numBinario;
                }
            }
            return numBinario;
        }
        /// <summary>
        /// convertirán un número decimal a binario, en caso de ser posible. 
        /// Caso contrario retornará "Valor inválido"
        /// </summary>
        /// <param name="numero"></param> valor a ser convertido en binario
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double numCociente;
            string retorno = "Valor Inválido";
            if (double.TryParse(numero, out numCociente))
            {
                retorno = this.DecimalBinario(numCociente);
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador suma
        /// </summary>
        /// <param name="num1">Primer numero de tipo Operando utilizado para la operacion</param>
        /// <param name="num2">Segundo numero de tipo Operando utilizado para la operacion</param>
        /// <returns></returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador resta
        /// </summary>
        /// <param name="num1">Primer numero de tipo Operando utilizado para la operacion</param>
        /// <param name="num2">Segundo numero de tipo Operando utilizado para la operacion</param>
        /// <returns></returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador multiplicacion
        /// </summary>
        /// <param name="num1">Primer numero de tipo Operando utilizado para la operacion</param>
        /// <param name="num2">Segundo numero de tipo Operando utilizado para la operacion</param>
        /// <returns></returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador division
        /// </summary>
        /// <param name="num1">Primer numero de tipo Operando utilizado para la operacion</param>
        /// <param name="num2">Segundo numero de tipo Operando utilizado para la operacion<</param>
        /// <returns></returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if (num2.numero == 0)
            {
                return double.MinValue;
            }
            return num1.numero / num2.numero;
        }

    }
}




