using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertice
{
    public class Vertices
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vertices(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distancia(Vertices outro)
        {
            double deltaX = X - outro.X;
            double deltaY = Y - outro.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public void Move(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Vertices outro)
        {
            return X == outro.X && Y == outro.Y;
        }

        static void Main(string[] args)
        {
            Vertices vertice1 = new Vertices(1, 4);
            Vertices vertice2 = new Vertices(2, 3);
            Console.WriteLine($"Vértice 1: ({vertice1.X}, {vertice1.Y})");
            Console.WriteLine($"Vértice 2: ({vertice2.X}, {vertice2.Y})");

            double distancia = vertice1.Distancia(vertice2);
            Console.WriteLine($"Distância entre Vértice 1 e Vértice 2: {distancia}");

            vertice1.Move(1, 1);
            Console.WriteLine($"Vértice 1 após movimentação: ({vertice1.X}, {vertice1.Y})");

            bool saoIguais = vertice1.Equals(vertice2);
            Console.WriteLine($"Vértices são iguais? {saoIguais}");
        }
    }
}
