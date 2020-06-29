using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;

namespace Dados
{
    public class ConnectionSQLite
    {
        private static SQLiteConnection sqliteConnection;
        public static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"Data Source =  c:\tmp\p2db.db");
            sqliteConnection.Open();
            return sqliteConnection;
        }

    }
}
