using Application.Dtos;
using Domain.Entities;

namespace Application.IServices;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAll();
}
