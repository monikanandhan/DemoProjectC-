using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.Service
{
    public class StudentService
    {
        public AppDbContext Context { get; set; }   
        public StudentService(AppDbContext _context) 
        {
            Context = _context; 
        } 

        public int AddStudentDetails(StudentVM studentVM)
        {
            var NewStudent = new Student()
            {
                
               
                Name = studentVM.Name,
                standard = studentVM.standard,
                Academic_Year = studentVM.Academic_Year,
                Gender = studentVM.Gender
            };
            Context.Students.Add(NewStudent);
            Context.SaveChanges();
            return NewStudent.Id;
        }

        public List<Student> GetStudents() => Context.Students.ToList();   
        
    }
}
