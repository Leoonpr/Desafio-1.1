using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervalo
{
    public class Intervalos
    {
        public DateTime Inicio { get; }
        public DateTime Fim { get; }

        public Intervalos(DateTime inicio, DateTime fim)
        {
            if (inicio > fim)
            {
                throw new ArgumentException("A data/hora inicial deve ser menor ou igual à data/hora final.");

            }
            Inicio = inicio;
            Fim = fim;
        }

        public TimeSpan Duracao
        {
            get { return Fim - Inicio; }
        }

        public bool TemIntersecao(Intervalos intervalo)
        {
            return Inicio < intervalo.Fim && Fim > intervalo.Inicio;
        }

        public bool Igual(Intervalos intervalo)
        {
            return Inicio == intervalo.Inicio && Fim == intervalo.Fim;
        }

        static void Main(string[] args)
        {
            try
            {
                Intervalos intervalo1 = new Intervalos(new DateTime(2024, 10, 1, 10, 0, 0), new DateTime(2024, 10, 1, 12, 0, 0));
                Intervalos intervalo2 = new Intervalos(new DateTime(2024, 10, 1, 11, 0, 0), new DateTime(2024, 10, 1, 13, 0, 0));
                Intervalos intervalo3 = new Intervalos(new DateTime(2024, 10, 1, 12, 0, 0), new DateTime(2024, 10, 1, 14, 0, 0));

                Console.WriteLine($"Intervalo 1: Início = {intervalo1.Inicio}, Fim = {intervalo1.Fim}, Duração = {intervalo1.Duracao}");
                Console.WriteLine($"Intervalo 2: Início = {intervalo2.Inicio}, Fim = {intervalo2.Fim}, Duração = {intervalo2.Duracao}");
                Console.WriteLine($"Intervalo 3: Início = {intervalo3.Inicio}, Fim = {intervalo3.Fim}, Duração = {intervalo3.Duracao}");

                Console.WriteLine($"O Intervalo 1 tem interseção com o Intervalo 2? {intervalo1.TemIntersecao(intervalo2)}");
                Console.WriteLine($"O Intervalo 1 tem interseção com o Intervalo 3? {intervalo1.TemIntersecao(intervalo3)}");

                Console.WriteLine($"O Intervalo 1 é igual ao Intervalo 2? {intervalo1.Igual(intervalo2)}");
                Console.WriteLine($"O Intervalo 1 é igual ao Intervalo 3? {intervalo1.Igual(intervalo3)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }

    }
}
