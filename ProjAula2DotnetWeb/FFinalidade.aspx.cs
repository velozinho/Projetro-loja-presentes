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
    public partial class FFinalidade : System.Web.UI.Page
    {

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Finalidade finalidade = new Finalidade()
            {
                Id = int.Parse(TxtCodigo.Text),
                Descricao = TxtDescricao.Text,
                Origem = TxtOrigem.Text

            };

            FinalidadeDB finalidadeDB = new FinalidadeDB();
            bool status = finalidadeDB.Salvar(finalidade);

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
        }
    }
}
