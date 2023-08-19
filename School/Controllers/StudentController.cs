using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentServies)
    {
        _studentService = studentServies;
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAll();
        return Ok(students);
    }
}
