using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Presente
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public Tipo Tipo { get; set; }

        public Marca Marca { get; set; }

        public Finalidade Finalidade { get; set; }

        public string Cor { get; set; }

        public double Tamanho { get; set; }

        public decimal Preco { get; set; }

        public Fornecedor Fornecedor { get; set; }




    }
}
