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
    public class CidadeDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;
        public CidadeDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,       ");
            sb.Append("        nome      ");
            sb.Append("  FROM  tb_cidade ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public List<Cidade> ConsultarList()
        {
            SQLiteDataReader dr;
            List<Cidade> cidades = new List<Cidade>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,        ");
            sb.Append("        nome      ");
            sb.Append("  FROM  tb_cidade ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                dr = cmd.ExecuteReader();
            }

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade cidade = new Cidade()
                    {
                        Id = (dr[0] == DBNull.Value) ? 0 : int.Parse(dr[0].ToString()),
                        Nome = dr.GetString(1).ToString()
                    };
                    cidades.Add(cidade);
                }
            }
            return cidades;
        }
    }
}
