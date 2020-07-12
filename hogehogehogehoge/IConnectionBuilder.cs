using System.Data.Common;

namespace hogehogehogehoge
{
    public interface IConnectionBuilder
    {
        DbConnection CreateDbConnection();
    }
}