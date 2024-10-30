using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoDados
{
     public class Dados
    {
        public static void Main(string[] args)
        {
            string nome = LerNome();
            string cpf = LerCPF();
            DateTime dataNascimento = LerDataNascimento();
            float rendaMensal = LerRendaMensal();
            char estadoCivil = LerEstadoCivil();
            int dependentes = LerDependentes();

            Console.WriteLine("\nDados Validados:");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"CPF: {cpf}");
            Console.WriteLine($"Data de Nascimento: {dataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Renda Mensal: {rendaMensal:C}");
            Console.WriteLine($"Estado Civil: {estadoCivil}");
            Console.WriteLine($"Dependentes: {dependentes}");
        }

        static string LerNome()
        {
            string nome;
            do
            {
                Console.Write("Digite o nome (mínimo 5 caracteres): ");
                nome = Console.ReadLine();
                if (nome.Length >= 5)
                    return nome;
                Console.WriteLine("Erro: O nome deve ter pelo menos 5 caracteres.");
            } while (true);
        }

        static string LerCPF()
        {
            string cpf;
            do
            {
                Console.Write("Digite o CPF (somente números): ");
                cpf = Console.ReadLine();
                if (ValidarCPF(cpf))
                    return cpf;
                Console.WriteLine("Erro: CPF inválido.");
            } while (true);
        }

        static DateTime LerDataNascimento()
        {
            DateTime dataNascimento;
            do
            {
                Console.Write("Digite a data de nascimento (DD/MM/AAAA): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out dataNascimento) && VerificarIdade(dataNascimento))
                    return dataNascimento;
                Console.WriteLine("Erro: Data de nascimento inválida ou idade menor que 18 anos.");
            } while (true);
        }

        static float LerRendaMensal()
        {
            float rendaMensal;
            do
            {
                Console.Write("Digite a renda mensal (ex: 1000,00): ");
                if (float.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, new CultureInfo("pt-BR"), out rendaMensal) && rendaMensal >= 0)
                    return rendaMensal;
                Console.WriteLine("Erro: Renda mensal deve ser um valor positivo.");
            } while (true);
        }

        static char LerEstadoCivil()
        {
            char estadoCivil;
            do
            {
                Console.Write("Digite o estado civil (C, S, V, D): ");
                estadoCivil = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if ("CSVD".Contains(estadoCivil))
                    return estadoCivil;
                Console.WriteLine("Erro: Estado civil inválido.");
            } while (true);
        }

        static int LerDependentes()
        {
            int dependentes;
            do
            {
                Console.Write("Digite o número de dependentes (0 a 10): ");
                if (int.TryParse(Console.ReadLine(), out dependentes) && dependentes >= 0 && dependentes <= 10)
                    return dependentes;
                Console.WriteLine("Erro: Número de dependentes deve estar entre 0 e 10.");
            } while (true);
        }

        static int CalcularDigito(string baseCpf, int[] multiplicadores)
        {
            int soma = baseCpf.Select((c, i) => (c - '0') * multiplicadores[i]).Sum();
            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        static bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);

            if (CalcularDigito(tempCpf, multiplicadores1) != int.Parse(cpf[9].ToString()) ||
                CalcularDigito(tempCpf + cpf[9], multiplicadores2) != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        static bool VerificarIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.Date < dataNascimento.AddYears(idade)) idade--;
            return idade >= 18;
        }

    }
}
