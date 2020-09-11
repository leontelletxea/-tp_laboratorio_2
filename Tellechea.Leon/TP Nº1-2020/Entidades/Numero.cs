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

        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        public string BinarioDecimal(string binario)
        {
            int i;
            int accumulator = 0;
            string auxiliar;
            char[] array = binario.ToCharArray();

            if (EsBinario(binario) == true)
            {
                Array.Reverse(array);

                for (i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        accumulator += (int)Math.Pow(2, i);
                    }
                }
                auxiliar = Convert.ToString(accumulator);
            }
            else
            {
                auxiliar = "Valor inválido";
            }

            return auxiliar;
        }

        private static string ReverseArray(string chain)
        {
            char[] array = chain.ToCharArray();

            Array.Reverse(array);

            return new string(array);
        }

        public string DecimalBinario(double numero)
        {
            int convertedNumber = (int)Math.Abs(numero);
            string chain = "";
            string auxiliar = "";

            if (convertedNumber > 0)
            {
                while (convertedNumber > 0)
                {
                    if (convertedNumber % 2 == 0)
                    {
                        chain += "0";
                    }
                    else
                    {
                        chain += "1";
                    }
                    convertedNumber = convertedNumber / 2;
                }
                chain = ReverseArray(chain);
            }
            else if (convertedNumber == 0)
            {
                chain = "0";
            }
            else
            {
                chain = "Valor inválido";
            }

            auxiliar = chain;

            return auxiliar;
        }

        public string DecimalBinario(string binario)
        {
            double convertedNumber;
            string chain;

            if (double.TryParse(binario, out convertedNumber))
            {
                chain = DecimalBinario(convertedNumber);
            }
            else
            {
                chain = "Valor inválido";
            }

            return chain;
        }

        private bool EsBinario(string numero)
        {
            int i;
            bool flag = true;

            for (i = 0; i < numero.Length; i++)
            {
                if (numero[i] != '0' && numero[i] != '1')
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public Numero()
        {
            numero = 0;
        }

        public Numero(double dblNumero)
        {
            numero = dblNumero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double outcome;

            if (n2.numero != 0)
            {
                outcome = n1.numero / n2.numero;
            }
            else
            {
                outcome = double.MinValue;
            }

            return outcome;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double convertedNumber;
            double returnValue;

            if (double.TryParse(strNumero, out convertedNumber) == true)
            {
                returnValue = convertedNumber;
            }
            else
            {
                returnValue = 0;
            }

            return convertedNumber;
        }

    }
}
