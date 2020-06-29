using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fornecedor
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string ContaCorrente { get; set; }

        public string Agencia { get; set; }
        public string Banco { get; set; }
        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
