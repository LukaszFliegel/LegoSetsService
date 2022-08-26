using System.Data.Common;

namespace LegoSetsService.Dal.Providers
{
    public interface IDbConnectionProvider
    {
        DbConnection GetConnection();
    }
}