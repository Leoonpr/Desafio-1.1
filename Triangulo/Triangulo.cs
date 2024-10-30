using System;
using Vertice;

namespace Triangulo
{
    public enum Tipo
    {
        Equilatero,
        Isosceles,
        Escaleno
    }

    public class Triangulo
    {
        public Vertices Vertice1 { get; private set; }
        public Vertices Vertice2 { get; private set; }
        public Vertices Vertice3 { get; private set; }

        public Triangulo(Vertices v1, Vertices v2, Vertices v3)
        {
            if (!FormaTriangulo(v1, v2, v3))
            {
                throw new ArgumentException("Os vértices fornecidos não formam um triângulo.");
            }

            Vertice1 = v1;
            Vertice2 = v2;
            Vertice3 = v3;
        }

        private bool FormaTriangulo(Vertices v1, Vertices v2, Vertices v3)
        {
            double a = v1.Distancia(v2);
            double b = v2.Distancia(v3);
            double c = v3.Distancia(v1);

            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        public bool Equals(Triangulo outro)
        {
            if (outro == null)
                return false;

            return (Vertice1.Equals(outro.Vertice1) && Vertice2.Equals(outro.Vertice2) && Vertice3.Equals(outro.Vertice3)) ||
                   (Vertice1.Equals(outro.Vertice2) && Vertice2.Equals(outro.Vertice3) && Vertice3.Equals(outro.Vertice1)) ||
                   (Vertice1.Equals(outro.Vertice3) && Vertice2.Equals(outro.Vertice1) && Vertice3.Equals(outro.Vertice2));
        }

        public double Perimetro
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);
                return a + b + c;
            }
        }

        public Tipo TipoDeTriangulo
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);

                if (a == b && b == c)
                {
                    return Tipo.Equilatero;
                }
                else if (a == b || b == c || a == c)
                {
                    return Tipo.Isosceles;
                }
                else
                {
                    return Tipo.Escaleno;
                }
            }
        }

        public double Area
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);
                double s = Perimetro / 2;

                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }
        static void Main(string[] args)
        {
            Vertices v1 = new Vertices(0, 0);
            Vertices v2 = new Vertices(3, 0);
            Vertices v3 = new Vertices(0, 4);

            try
            {
                Triangulo triangulo = new Triangulo(v1, v2, v3);
                Console.WriteLine($"Perímetro: {triangulo.Perimetro}");
                Console.WriteLine($"Área: {triangulo.Area}");
                Console.WriteLine($"Tipo: {triangulo.TipoDeTriangulo}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
