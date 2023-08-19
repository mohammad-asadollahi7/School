
namespace Persistence;

public interface IDbContext
{
    void ExecuteCommand(string sql);
    IEnumerable<T> ExecuteQuery<T>(string sql);
}
