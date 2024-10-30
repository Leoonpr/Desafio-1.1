using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro
{
    class Carro
    {
        public string Placa { get; }
        public string Modelo { get; }
        private Motor motor;

        public Motor Motor
        {
            get { return motor; }
            private set
            {
                if (value.EstaInstalado)
                    throw new InvalidOperationException("Este motor já está instalado em outro carro.");
                motor?.Desinstalar();
                motor = value;
                motor.Instalar();
            }
        }

        public Carro(string placa, string modelo, Motor motorInicial)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("A placa é obrigatória.");
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("O modelo é obrigatório.");

            Placa = placa;
            Modelo = modelo;
            Motor = motorInicial;
        }

        public void TrocarMotor(Motor novoMotor)
        {
            Motor = novoMotor;
        }

        public int VelocidadeMaxima
        {
            get
            {
                if (motor.Cilindrada <= 1.0)
                    return 140;
                if (motor.Cilindrada <= 1.6)
                    return 160;
                if (motor.Cilindrada <= 2.0)
                    return 180;

                return 220;
            }
        }
    }
}
