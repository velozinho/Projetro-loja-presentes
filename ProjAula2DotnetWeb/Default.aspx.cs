using Dados;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarFinalidade();
                CarregarFornecedor();
                CarregarMarca();
                CarregarTabela();
                CarregarTipo();
            }
            CarregarTabela();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Presente presente = new Presente()
            {
                Id = int.Parse(TxtCodigo.Text),
                Descricao = TxtDescricao.Text,
                Cor = TxtCor.Text,
                Finalidade = new Finalidade() { Id = int.Parse(DDLFinalidades.SelectedItem.Value.ToString()) },
                Fornecedor = new Fornecedor() { Id = int.Parse(DDLFornecedores.SelectedItem.Value.ToString()) },
                Marca = new Marca() { Id = int.Parse(DDLMarcas.SelectedItem.Value.ToString()) },
                Tipo = new Tipo() { Id = int.Parse(DDLTipos.SelectedItem.Value.ToString()) },
                Preco = decimal.Parse(TxtPreco.Text),
                Tamanho = double.Parse(TxtTamanho.Text)
            };

            PresenteDB presenteDB = new PresenteDB();
            bool status = presenteDB.Salvar(presente);

            if (status)
            {
                lblMSG.Text = "Registro Inserido!";
                LimparComponentes();
                CarregarTabela();
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
            TxtCor.Text = String.Empty;
            TxtDescricao.Text = String.Empty;
            TxtPreco.Text = String.Empty;
            TxtTamanho.Text = String.Empty;
        }

        private void CarregarTabela()
        {
            PresenteDB presenteDB = new PresenteDB();
            GVPresente.DataSource = presenteDB.ConsultarTudo();
            GVPresente.DataBind();
        }

        private void CarregarTipo()
        {
            TipoDB tipoDB = new TipoDB();
            DDLTipos.DataSource = tipoDB.ConsultarList();
            DDLTipos.DataValueField = "Id";
            DDLTipos.DataTextField = "Descricao";
            DDLTipos.DataBind();
        }

        private void CarregarMarca()
        {
            MarcaDB marcaDB = new MarcaDB();
            DDLMarcas.DataSource = marcaDB.ConsultarList();
            DDLMarcas.DataValueField = "Id";
            DDLMarcas.DataTextField = "Descricao";
            DDLMarcas.DataBind();
        }

        private void CarregarFinalidade()
        {
            FinalidadeDB finalidadeDB = new FinalidadeDB();
            DDLFinalidades.DataSource = finalidadeDB.ConsultarList();
            DDLFinalidades.DataValueField = "Id";
            DDLFinalidades.DataTextField = "Descricao";
            DDLFinalidades.DataTextField = "Origem";
            DDLFinalidades.DataBind();
        }

        private void CarregarFornecedor()
        {
            FornecedorDB fornecedorDB = new FornecedorDB();
            DDLFornecedores.DataSource = fornecedorDB.ConsultarList();
            DDLFornecedores.DataValueField = "Id";
            DDLFornecedores.DataTextField = "Descricao";
            DDLFornecedores.DataTextField = "Telefone";
            DDLFornecedores.DataTextField = "Cidade";
            DDLFornecedores.DataTextField = "Estado";
            DDLFornecedores.DataTextField = "Logradouro";
            DDLFornecedores.DataTextField = "Numero";
            DDLFornecedores.DataTextField = "CNPJ";
            DDLFornecedores.DataTextField = "Email";
            DDLFornecedores.DataTextField = "ContaCorrente";
            DDLFornecedores.DataTextField = "Agencia";
            DDLFornecedores.DataTextField = "Banco";



            DDLFornecedores.DataBind();
        }

        protected void BtnCadastrarTipo_Click(object sender, EventArgs e)
        {

            Server.Transfer("FTipo.aspx");
        }

        protected void BtnCadastrarMarca_Click(object sender, EventArgs e)
        {

            Server.Transfer("FMarca.aspx");
        }

        protected void BtnCadastrarFinalidade_Click(object sender, EventArgs e)
        {

            Server.Transfer("FFinalidade.aspx");
        }

        protected void BtnCadastrarFornecedor_Click(object sender, EventArgs e)
        {

            Server.Transfer("FFornecedor.aspx");
        }

    }

}
