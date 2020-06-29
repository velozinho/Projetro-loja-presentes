using Dados;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP2
{
    public partial class FFornecedor : System.Web.UI.Page
    {

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = int.Parse(TxtCodigo.Text),
                Descricao = TxtDescricao.Text,
                Telefone = TxtTelefone.Text,
                Cidade = TxtCidade.Text,
                Estado = TxtEstado.Text,
                Logradouro = TxtLogradouro.Text,
                Numero = TxtNumero.Text,
                CNPJ = TxtCNPJ.Text,
                Email = TxtEmail.Text,
                ContaCorrente = TxtContaCorrente.Text,
                Agencia = TxtAgencia.Text,
                Banco = TxtBanco.Text
            };

            FornecedorDB fornecedorDB = new FornecedorDB();
            bool status = fornecedorDB.Salvar(fornecedor);

            if (status)
            {

                lblMSG.Text = "Salvo com sucesso!";
                LimparComponentes();

            }
            else
            {
                lblMSG.Text = "Erro ao salvar";
               
            }

        }

        private void LimparComponentes()
        {
            TxtCodigo.Text = String.Empty;
            TxtDescricao.Text = String.Empty;
            TxtAgencia.Text = String.Empty;
            TxtBanco.Text = String.Empty;
            TxtCidade.Text = String.Empty;
            TxtCNPJ.Text = String.Empty;
            TxtContaCorrente.Text = String.Empty;
            TxtLogradouro.Text = String.Empty;
            TxtNumero.Text = String.Empty;
            TxtTelefone.Text = String.Empty;

        }
    }
}