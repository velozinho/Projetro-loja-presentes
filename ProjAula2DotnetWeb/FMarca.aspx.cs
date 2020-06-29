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
    public partial class FMarca : System.Web.UI.Page
    {

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca()
            {
                Id = int.Parse(TxtCodigo.Text),
                Descricao = TxtDescricao.Text

            };

            MarcaDB marcaDB = new MarcaDB();
            bool status = marcaDB.Salvar(marca);

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
        }
    }
}
