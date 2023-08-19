
using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;
using System.ComponentModel.DataAnnotations;

namespace Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public IEnumerable<StudentDto> GetAll()
    {
        var students = _studentRepository.GetAll().ToList();
        List<StudentDto> studentsDto = new();
        foreach (var student in students)
        {
            studentsDto.Add(new StudentDto()
            {
                Id = student.Id,
                Name = student.Name,
                Family = student.Family,
                FatherName = student.FatherName,
                Average = student.Average
            });

        }
        return studentsDto;
    }
}
