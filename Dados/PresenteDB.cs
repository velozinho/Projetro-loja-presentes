using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class PresenteDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;

        public PresenteDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Salvar(Presente presente)
        {
            try
            {
                string sql = "INSERT INTO presente (id, descricao, tipo, marca, finalidade, cor, tamanho, preco, fornecedor) values (@Id, @Descricao, @Tipo, @Marca, @Finalidade, @Cor, @Tamanho, @Preco, @Fornecedor)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", presente.Id);
                    cmd.Parameters.AddWithValue("@Descricao", presente.Descricao);
                    cmd.Parameters.AddWithValue("@Tipo", presente.Tipo.Id);
                    cmd.Parameters.AddWithValue("@Marca", presente.Marca.Id);
                    cmd.Parameters.AddWithValue("@Finalidade", presente.Finalidade.Id);
                    cmd.Parameters.AddWithValue("@Cor", presente.Cor);
                    cmd.Parameters.AddWithValue("@Tamanho", presente.Tamanho);
                    cmd.Parameters.AddWithValue("@Preco", presente.Preco);
                    cmd.Parameters.AddWithValue("Fornecedor", presente.Fornecedor.Id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable ConsultarTudo()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" select tb_presente.id, ");
            sb.Append(" presente.descricao,   ");
            sb.Append("     tipo.descricao, ");
            sb.Append("       marca.descricao,        ");
            sb.Append("    finalidade.descricao,         ");
            sb.Append("     presente.cor,    ");
            sb.Append("      presente.tamanho,    ");
            sb.Append("      presente.preco,     ");
            sb.Append("      fornecedor.descricao    ");

            sb.Append("  from presente as presente inner join finalidade as finalidade on presente.finalidade = finalidade.id    ");
            sb.Append("inner join tipo as tipo on tipo.id = presente.tipo ");
            sb.Append("inner join marca as marca on marca.id = presente.marca ");
            sb.Append("inner join fornecedor as fornecedor on fornecedor.id = presente.fornecedor");


            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }
        }
    }

