using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.Service
{
    public class StudentService:IStudentInterface
    {
        public AppDbContext Context { get; set; }
        private readonly ILogger logger;
       
        public StudentService(AppDbContext _context,ILogger<StudentService> _logger) 
        {
            Context = _context; 
            logger = _logger;
           
        } 

        public int AddStudentDetails(StudentVM studentVM)
        {
            logger.LogInformation("Add-New-Student:{@controller}", GetType().Name);
           
            var NewStudent = new Student()
            {
                
               
                Name = studentVM.Name,
                standard = studentVM.standard,
                Academic_Year = studentVM.Academic_Year,
                Gender = studentVM.Gender
            };
            Context.Students.Add(NewStudent);
            logger.LogInformation($"New-student-Details {JsonConvert.SerializeObject(NewStudent)}");
            Context.SaveChanges();
            return NewStudent.Id;
        }

        public List<Student> GetStudents()
        {
            logger.LogInformation("Get-all-Student:{@controller}", GetType().Name);

            var GetAll = Context.Students.ToList();
            logger.LogInformation($"all-Student-Details {JsonConvert.SerializeObject(GetAll)}");

            return GetAll;
        }
    }
}
