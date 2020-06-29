using Dados;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace ProjP2
{
    public partial class FTipo : System.Web.UI.Page
    {
     

        protected void BtnSalvar_Click(object sender, EventArgs e)
            {
                Tipo tipo = new Tipo()
                {
                    Id = int.Parse(TxtCodigo.Text),
                    Descricao = TxtDescricao.Text
                  
                };

            TipoDB tipoDB = new TipoDB();
                bool status = tipoDB.Salvar(tipo);

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
