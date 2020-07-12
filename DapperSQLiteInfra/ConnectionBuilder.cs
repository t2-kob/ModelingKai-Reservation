using System.Data.Common;
using System.Data.SQLite;
using hogehogehogehoge;

namespace DapperSQLiteInfra
{
    public class ConnectionBuilder : IConnectionBuilder
    {
        private readonly string _dbFileName;
        
        public ConnectionBuilder(string dbFileName)
        {
            _dbFileName = dbFileName;
        }

        public DbConnection CreateDbConnection()
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = _dbFileName };
            return new SQLiteConnection(sqlConnectionSb.ToString());
        }
        
    }
}