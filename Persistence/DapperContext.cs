

using Dapper;
using System.Data.SqlClient;

namespace Persistence;

public class DapperContext : IDbContext
{
    private string _connectionString;

    public DapperContext()
    {
        _connectionString = "Data Source=M-A7; Initial Catalog=SchoolDb; Integrated Security=SSPI";

    }
    public void ExecuteCommand(string sql)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Execute(sql);
    }

    public IEnumerable<T> ExecuteQuery<T>(string sql)
    {
        using var conn = new SqlConnection(_connectionString);
        return conn.Query<T>(sql);
    }
}
