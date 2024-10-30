using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertidaoNascimento
{
    class CertidaoNascimento
    {
        public Pessoa Pessoa { get; }
        public DateTime DataEmissao { get; }

        public CertidaoNascimento(Pessoa pessoa, DateTime dataEmissao)
        {
            if (pessoa == null)
                throw new ArgumentNullException("Uma pessoa deve ser associada à certidão.");

            Pessoa = pessoa;
            DataEmissao = dataEmissao;
        }
    }
}
