using System.Data.Common;
using System.Data.SQLite;

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

    public interface IConnectionBuilder
    {
        DbConnection CreateDbConnection();
    }
}