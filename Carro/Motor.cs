using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro
{
    public class Motor
    {
        public double Cilindrada { get; }
        public bool EstaInstalado { get; private set; } = false;

        public Motor(double cilindrada)
        {
            if (cilindrada <= 0)
                throw new ArgumentException("A cilindrada deve ser maior que zero.");

            Cilindrada = cilindrada;
        }

        public void Instalar()
        {
            EstaInstalado = true;
        }

        public void Desinstalar()
        {
            EstaInstalado = false;
        }
    }
}
