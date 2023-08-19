using Domain.Entities;
using Domain.IRepositories;
using Persistence;

namespace Infrastructure;

public class StudentRepository : IStudentRepository
{
    private readonly IDbContext _context;

    public StudentRepository(IDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Student> GetAll()
    {
        var rawSql = SqlQureies.GetAll;
        var sql = string.Format(rawSql, nameof(Student));
        return  _context.ExecuteQuery<Student>(sql);
    }
}



public static class SqlQureies
{
    public static string GetAll { get; set; } = "SELECT * FROM {0}";
}
