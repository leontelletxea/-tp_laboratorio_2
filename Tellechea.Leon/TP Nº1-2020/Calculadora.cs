using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Nº1_2020
{
    static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double outcome = 0;
            double number1 = Convert.ToDouble(num1);
            double number2 = Convert.ToDouble(num2);

            switch (operador)
            {
                case "+":
                    outcome = number1 + number2;
                    break;
                case "-":
                    outcome = number1 - number2;
                    break;
                case "/":
                    outcome = number1 / number2;
                    break;
                case "*":
                    outcome = number1 * number2;
                    break;
            }

            return outcome;
        }

        private static string ValidarOperador(char operador)
        {
            string valueReturn;

            switch(operador)
            {
                case '+':
                    valueReturn = Convert.ToString(operador);
                    break;
                case '-':
                    valueReturn = Convert.ToString(operador);
                    break;
                case '/':
                    valueReturn = Convert.ToString(operador);
                    break;
                case '*':
                    valueReturn = Convert.ToString(operador);
                    break;
                default:
                    valueReturn = "+";
                    break;
            }

            return valueReturn;
        }
    }
}
