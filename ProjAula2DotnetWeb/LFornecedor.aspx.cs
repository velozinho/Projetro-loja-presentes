using Model;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ProjP2
{
    public partial class LFornecedor : System.Web.UI.Page
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
                Logradouro = Logradouro.Text,
                Numero = Numero.Text,
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

                lblMSG.Text = "Registro Inserido!";
                LimparComponentes();

            }
            else
            {
                lblMSG.Text = "Erro ao inserir registro";
                lblMSG.ForeColor = Color.Red;
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
            Logradouro.Text = String.Empty;
            Numero.Text = String.Empty;
            TxtTelefone.Text = String.Empty;
            TxtEmail.Text = String.Empty;
            TxtEstado.Text = String.Empty;
            

        }
    }
}