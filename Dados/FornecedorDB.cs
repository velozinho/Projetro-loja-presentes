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
    public class FornecedorDB
    {
        //Conexao: 
        private static SQLiteConnection sqliteConnection;
        public FornecedorDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }


        public bool Salvar(Fornecedor fornecedor)
        {
            try
            {
                string sql = "INSERT INTO fornecedor (id, descricao, telefone, cidade, estado, logradouro, numero, cnpj, email, contacorrente, agencia, banco) values (@Id, @Descricao, @Telefone, @Cidade, @Estado, @Logradouro, @Numero, @Cnpj, @Email, @Contacorrente, @Agencia, @Banco)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", fornecedor.Id);
                    cmd.Parameters.AddWithValue("@Descricao", fornecedor.Descricao);
                    cmd.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                    cmd.Parameters.AddWithValue("@Cidade", fornecedor.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", fornecedor.Estado);
                    cmd.Parameters.AddWithValue("@Logradouro", fornecedor.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", fornecedor.Numero);
                    cmd.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                    cmd.Parameters.AddWithValue("@Email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@ContaCorrente", fornecedor.ContaCorrente);
                    cmd.Parameters.AddWithValue("@Agencia", fornecedor.Agencia);
                    cmd.Parameters.AddWithValue("@Banco", fornecedor.Banco);



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
            sb.Append("        descricao,      ");
            sb.Append("        telefone,      ");
            sb.Append("        cidade ,     ");
            sb.Append("        estado ,     ");
            sb.Append("        logradouro  ,    ");
            sb.Append("        numero,      ");
            sb.Append("        CNPJ   ,   ");
            sb.Append("        email  ,    ");
            sb.Append("        contaCorrente,     ");
            sb.Append("        agencia ,     ");
            sb.Append("        banco      ");
            sb.Append("  FROM  fornecedor ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public List<Fornecedor> ConsultarList()
        {
            SQLiteDataReader dr;
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id,       ");
            sb.Append("        descricao,      ");
            sb.Append("        telefone,      ");
            sb.Append("        cidade,      ");
            sb.Append("        estado,      ");
            sb.Append("        logradouro ,     ");
            sb.Append("        numero,      ");
            sb.Append("        CNPJ ,     ");
            sb.Append("        email  ,    ");
            sb.Append("        contacorrente ,     ");
            sb.Append("        agencia  ,    ");
            sb.Append("        banco      ");
            sb.Append("  FROM  fornecedor ");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                dr = cmd.ExecuteReader();
            }

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Fornecedor fornecedor = new Fornecedor()
                    {
                        Id = (dr[0] == DBNull.Value) ? 0 : int.Parse(dr[0].ToString()),
                        Descricao = dr.GetString(1).ToString(),
                        Telefone = dr.GetString(1).ToString(),
                        Cidade = dr.GetString(1).ToString(),
                        Estado = dr.GetString(1).ToString(),
                        Logradouro = dr.GetString(1).ToString(),
                        Numero = dr.GetString(1).ToString(),
                        CNPJ = dr.GetString(1).ToString(),
                        Email = dr.GetString(1).ToString(),
                        ContaCorrente = dr.GetString(1).ToString(),
                        Agencia = dr.GetString(1).ToString(),
                        Banco = dr.GetString(1).ToString()


                    };
                    fornecedores.Add(fornecedor);
                }
            }
            return fornecedores;
        }
    }
}

