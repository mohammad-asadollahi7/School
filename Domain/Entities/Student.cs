using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Family { get; set; } = null!;
    public string FatherName { get; set; } = null!;
    public float Average { get; set; }
    //public List<Course> Courses { get; set; }
}
