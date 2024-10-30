using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertice;

namespace Poligono
{
    class Poligono
    {
        private List<Vertices> vertices;

        public Poligono(List<Vertices> verticesIniciais)
        {
            if (verticesIniciais.Count < 3)
                throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices.");

            vertices = new List<Vertices>();

            foreach (var vertice in verticesIniciais)
            {
                AddVertice(vertice);
            }
        }

        public bool AddVertice(Vertices novoVertice)
        {
            foreach (var vertice in vertices)
            {
                if (vertice.Equals(novoVertice))
                    return false;
            }

            vertices.Add(novoVertice);
            return true;
        }

        public void RemoveVertice(Vertices verticeARemover)
        {
            if (vertices.Count <= 3)
                throw new InvalidOperationException("O polígono deve ter pelo menos 3 vértices.");

            vertices.Remove(verticeARemover);
        }

        public double Perimetro
        {
            get
            {
                double perimetro = 0;

                for (int i = 0; i < vertices.Count; i++)
                {
                    Vertices atual = vertices[i];
                    Vertices proximo = vertices[(i + 1) % vertices.Count];
                    perimetro += atual.Distancia(proximo);
                }

                return perimetro;
            }
        }

        public int QuantidadeDeVertices
        {
            get { return vertices.Count; }
        }

        static void Main(string[] args)
        {
            try
            {
                // Cria alguns vértices
                List<Vertices> vertices = new List<Vertices>
                {
                    new Vertices(0, 0),
                    new Vertices(4, 0),
                    new Vertices(4, 3)
                };

                // Cria um polígono
                Poligono poligono = new Poligono(vertices);

                // Exibe informações do polígono
                Console.WriteLine($"Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
                Console.WriteLine($"Perímetro: {poligono.Perimetro}");

                // Adiciona um novo vértice
                Vertices novoVertice = new Vertices(0, 3);
                if (poligono.AddVertice(novoVertice))
                {
                    Console.WriteLine("Vértice adicionado com sucesso.");
                }
                else
                {
                    Console.WriteLine("O vértice já existe no polígono.");
                }

                // Exibe informações após adicionar um vértice
                Console.WriteLine($"Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
                Console.WriteLine($"Perímetro: {poligono.Perimetro}");

                // Remove um vértice
                poligono.RemoveVertice(vertices[0]);
                Console.WriteLine($"Vértice removido. Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
                Console.WriteLine($"Perímetro: {poligono.Perimetro}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}
