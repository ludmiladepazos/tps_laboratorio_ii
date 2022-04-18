using System;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        
        /// <summary>
        /// Validar que el operador recibido sea +, - , / o *. Caso contrario retorna +
        /// </summary>
        /// <param name="operador"></param> Operador que ingresa el usuario, el cual sera validado
        /// <returns></returns> retorno del operador ingresado, en caso de no ingresar ninguna de las opciones retorna +
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    return '+';
                case '-':
                    return '-';
                case '/':
                    return '/';
                case '*':
                    return '*';
            }
            return '+';
        }

        /// <summary>
        /// Llama a la funcion validarOperador para validarlo y luego realiza la operacion correspondiente entre ambos numeros
        /// </summary>
        /// <param name="num1"></param> Primer numero de tipo Operando utilizado para la operacion
        /// <param name="num2"></param> Segundo numero de tipo Operando utilizado para la operacion
        /// <param name="operador"></param> Operador a ser utilizado en el calculo
        /// <returns></returns> Retorna el resultado de la operacion 
        public static double Operar(Operando num1, Operando num2, char operador) 
        {

            char operadorValidado = ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;

        }


    }
}

