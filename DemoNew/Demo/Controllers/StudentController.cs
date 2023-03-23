using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {

        IList<Student> Students = new List<Student>()
        {
            new Student(){ID=1,Name="monica",Age=25,Marks=90},
             new Student(){ID=2,Name="monisha",Age=24,Marks=80},
              new Student(){ID=3,Name="kalai",Age=22,Marks=90},
               new Student(){ID=4,Name="deepi",Age=26,Marks=100},
                new Student(){ID=5,Name="san",Age=24,Marks=95},
         };


        [HttpGet]
        public IList<Student> GetAllStudents()
        {
            //Return list of all employees
            return Students;
        }

        [HttpGet("{id}")]
        public Student GetEmployeeById(int id)
        {
            var StudentId = Students.FirstOrDefault(e => e.ID == id);
            return StudentId;
        }

        [HttpDelete("{id}")]
        public IList<Student> DeleteEmployee(int id)
        {
            var StudentId = Students.FirstOrDefault(e => e.ID == id);
                 Students.Remove(StudentId);
                 return Students;
            
        }

        [HttpPost]
        public IList<Student> AddStudents(Student stud)
        {
            Students.Add(stud);
            return Students;
        }

        [HttpPut("{id}")]
        public IList<Student> UpdateStudent(Student stud)
        {

            var StudentId = Students.FirstOrDefault(e => e.ID == stud.ID);
            if(StudentId!=null)
            {
                StudentId.ID = stud.ID;
                StudentId.Name = stud.Name;
                StudentId.Age = stud.Age;
                StudentId.Marks = stud.Marks;

            }
            return Students;

        }

    }
}

    

