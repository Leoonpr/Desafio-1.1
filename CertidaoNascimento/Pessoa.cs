using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertidaoNascimento
{
    class Pessoa
    {
        public string Nome { get; private set; }
        public CertidaoNascimento? Certidao { get; private set; }

        public Pessoa(string nome)
        {
            if (nome == null)
                throw new ArgumentException("O nome é obrigatório.");

            Nome = nome;
        }

        public void CriarCertidao(DateTime dataEmissao)
        {
            if (this.Certidao != null)
            {
                throw new ArgumentException("Essa pessoa já possui uma certidão");
            }
            Certidao = new CertidaoNascimento(this, dataEmissao);
        }
    }
}
