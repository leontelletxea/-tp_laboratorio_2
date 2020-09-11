using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double outcome = 0;

            switch (operador)
            {
                case "+":
                    outcome = num1 + num2;
                    break;
                case "-":
                    outcome = num1 - num2;
                    break;
                case "/":
                    outcome = num1 / num2;
                    break;
                case "*":
                    outcome = num1 * num2;
                    break;
                default:
                    outcome = num1 + num2;
                    break;
            }

            return outcome;
        }

        private static string ValidarOperador(char operador)
        {
            string returnValue;

            switch (operador)
            {
                case '+':
                    returnValue = Convert.ToString(operador);
                    break;
                case '-':
                    returnValue = Convert.ToString(operador);
                    break;
                case '/':
                    returnValue = Convert.ToString(operador);
                    break;
                case '*':
                    returnValue = Convert.ToString(operador);
                    break;
                default:
                    returnValue = "+";
                    break;
            }

            return returnValue;
        }
    }
}
