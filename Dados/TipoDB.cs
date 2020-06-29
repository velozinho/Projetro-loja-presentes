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
    public class TipoDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;
        public TipoDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Salvar(Tipo tipo)
        {
            try
            {
                string sql = "INSERT INTO tipo (id, descricao) values (@Id, @Descricao)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", tipo.Id);
                    cmd.Parameters.AddWithValue("@Descricao", tipo.Descricao);

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
            sb.Append("  FROM  tipo ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public List<Tipo> ConsultarList()
        {
            SQLiteDataReader dr;
            List<Tipo> tipos = new List<Tipo>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,        ");
            sb.Append("        descricao      ");
            sb.Append("  FROM  tipo ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                dr = cmd.ExecuteReader();
            }

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Tipo tipo = new Tipo()
                    {
                        Id = (dr[0] == DBNull.Value) ? 0 : int.Parse(dr[0].ToString()),
                        Descricao = dr.GetString(1).ToString()
                    };
                    tipos.Add(tipo);
                }
            }
            return tipos;
        }

    }
}
