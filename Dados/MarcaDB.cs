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
    public class MarcaDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;
        public MarcaDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Salvar(Marca marca)
        {
            try
            {
                string sql = "INSERT INTO marca (id, descricao) values (@Id, @Descricao)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", marca.Id);
                    cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);

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
            sb.Append("  FROM  marca ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public List<Marca> ConsultarList()
        {
            SQLiteDataReader dr;
            List<Marca> marcas = new List<Marca>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,        ");
            sb.Append("        descricao      ");
            sb.Append("  FROM  marca ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                dr = cmd.ExecuteReader();
            }

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Marca marca = new Marca()
                    {
                        Id = (dr[0] == DBNull.Value) ? 0 : int.Parse(dr[0].ToString()),
                        Descricao = dr.GetString(1).ToString()
                    };
                    marcas.Add(marca);
                }
            }
            return marcas;
        }
    }
}

