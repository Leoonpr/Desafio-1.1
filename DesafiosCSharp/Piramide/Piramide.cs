using System;

namespace Piramide
{
    class Piramide
    {
        private int n;

        public int N
        {
            get { return n; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("N deve ser maior ou igual a 1.");
                n = value;
            }
        }

        public Piramide(int n)
        {
            N = n;
        }

        public void Desenha()
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }

                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite o valor de N para a pirâmide:");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    Piramide piramide = new Piramide(n);
                    piramide.Desenha();
                }
                else
                {
                    Console.WriteLine("Erro: Entrada inválida. Digite um número inteiro.");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro: " + erro.Message);
            }
        }
    }
}
