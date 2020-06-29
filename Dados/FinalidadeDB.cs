using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dados
{
    public class FinalidadeDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;
        public FinalidadeDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }
        public bool Salvar(Finalidade finalidade)
        {
            try
            {
                string sql = "INSERT INTO finalidade (id, descricao, origem) values (@Id, @Descricao, @Origem)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", finalidade.Id);
                    cmd.Parameters.AddWithValue("@Descricao", finalidade.Descricao);
                    cmd.Parameters.AddWithValue("@Origem", finalidade.Descricao);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,       ");
            sb.Append("        descricao      ");
            sb.Append("        origem      ");
            sb.Append("  FROM  finalidade ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public List<Finalidade> ConsultarList()
        {
            SQLiteDataReader dr;
            List<Finalidade> finalidades = new List<Finalidade>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,       ");
            sb.Append("        descricao      ");
            sb.Append("        origem      ");
            sb.Append("  FROM  finalidade ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                dr = cmd.ExecuteReader();
            }

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Finalidade finalidade = new Finalidade()
                    {
                        Id = (dr[0] == DBNull.Value) ? 0 : int.Parse(dr[0].ToString()),
                        Descricao = dr.GetString(1).ToString(),
                        Origem = dr.GetString(1).ToString(),
                    };
                    finalidades.Add(finalidade);
                }
            }
            return finalidades;
        }
    }
}
