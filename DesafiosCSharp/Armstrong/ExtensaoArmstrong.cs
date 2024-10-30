using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong
{
    public static class ExtensaoArmstrong
    {
        public static bool IsArmstrong(this int numero)
        {
            string numeroStr = numero.ToString();
            int numeroDeDigitos = numeroStr.Length;
            int soma = 0;

            foreach (char digito in numeroStr)
            {
                int digitoInt = digito - '0';
                soma += (int)Math.Pow(digitoInt, numeroDeDigitos);
            }

            return soma == numero;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Números de Armstrong de 1 a 10000:");
            for (int i = 1; i <= 10000; i++)
            {
                if (i.IsArmstrong())
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
