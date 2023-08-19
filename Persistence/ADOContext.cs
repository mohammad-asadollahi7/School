using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Persistence;

public class ADOContext : IDbContext
{
    string _connectionString;
    public ADOContext()
    {
        _connectionString = "Data Source=M-A7; Initial Catalog=SchoolDb; Integrated Security=SSPI";
    }
    public void ExecuteCommand(string sql)
    {
        using var conn = new SqlConnection(_connectionString);
        var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        var rowNumber = cmd.ExecuteNonQuery();
    }

    public IEnumerable<T>? ExecuteQuery<T>(string sql)
    {
        var conn = new SqlConnection(_connectionString);
        var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        var stringJson = Serialize(reader);
        conn.Close();
        return JsonConvert.DeserializeObject<IEnumerable<T>>(stringJson);
    }


    private string Serialize(SqlDataReader reader)
    {
        var results = new List<Dictionary<string, object>>();
        var cols = new List<string>();
        for (var i = 0; i < reader.FieldCount; i++)
            cols.Add(reader.GetName(i));

        while (reader.Read())
            results.Add(SerializeRow(cols, reader));

        return JsonConvert.SerializeObject(results, Formatting.Indented);
    }
    private Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                    SqlDataReader reader)
    {
        var result = new Dictionary<string, object>();
        foreach (var col in cols)
            result.Add(col, reader[col]);
        return result;
    }
}
