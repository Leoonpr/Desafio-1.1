using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intervalo;

namespace ListaIntervalo
{
    class ListaIntervalo
    {
        private List<Intervalos> intervalos = new List<Intervalos>();

        public void Add(Intervalos novoIntervalo)
        {
            foreach (var intervalo in intervalos)
            {
                if (intervalo.TemIntersecao(novoIntervalo))
                {
                    throw new InvalidOperationException("O intervalo tem interseção com outro intervalo da lista e não pode ser adicionado.");
                }
            }

            intervalos.Add(novoIntervalo);
        }

        public ReadOnlyCollection<Intervalos> Intervalos
        {
            get { return intervalos.OrderBy(i => i.Inicio).ToList().AsReadOnly(); }
        }

        static void Main(string[] args)
        {
            ListaIntervalo lista = new ListaIntervalo();
            Intervalos intervalo1 = new Intervalos(new DateTime(2024, 10, 1, 10, 0, 0), new DateTime(2024, 10, 1, 12, 0, 0));
            Intervalos intervalo2 = new Intervalos(new DateTime(2024, 10, 1, 15, 0, 0), new DateTime(2024, 10, 1, 18, 0, 0));
            lista.Add(intervalo2);
            lista.Add(intervalo1);
            Console.WriteLine("Intervalos na lista:");
            foreach (var intervalo in lista.Intervalos)
            {
                Console.WriteLine($"Início: {intervalo.Inicio}, Fim: {intervalo.Fim}, Duração: {intervalo.Duracao}");
            }



        }

    }
}
