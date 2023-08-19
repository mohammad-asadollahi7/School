
using Domain.Entities;

namespace Domain.IRepositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();

}
