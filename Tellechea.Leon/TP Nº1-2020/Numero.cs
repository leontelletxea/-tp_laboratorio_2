using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Nº1_2020
{
    class Numero
    {
        private double numero;

        public void SetNumero(string strNumber)
        {
            double number = ValidarNumero(strNumber);

            numero = number;
        }

        public string BinarioDecimal(string binario)
        {
            int i;
            int accumulator = 0;
            string auxiliar;
            char[] array = binario.ToCharArray();

            if(EsBinario(binario) == true)
            {
                Array.Reverse(array);

                for (i=0; i<array.Length; i++)
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

        public string DecimalBinario(double numero)
        {
            int convertedNumber = Convert.ToInt32(numero);
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
            int convertedNumber = Convert.ToInt32(binario);
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

        private bool EsBinario(string numero)
        {
            int i;
            bool flag = true;

            for (i=0; i<numero.Length; i++)
            {
                if(numero[i] != '0' || numero[i] != '1')
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

        public Numero(double numero)
        {
           
        }

        public Numero(string strNumero)
        {

        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1 - n2;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1 * n2;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double outcome;

            if(Convert.ToDouble(n2) != 0)
            {
                outcome = n1 - n2;
            }
            else
            {
                outcome = double.MinValue;
            }

            return outcome;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1 + n2;
        }

        private double ValidarNumero(string strNumero)
        {
            double convertedNumber;
            double returnNumber;

            if(double.TryParse(strNumero, out convertedNumber) == true)
            {
                returnNumber = convertedNumber;
            }
            else
            {
                returnNumber = 0;
            }

            return convertedNumber;
        }
        
    }
}
