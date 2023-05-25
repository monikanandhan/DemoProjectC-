using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.IService
{
    public interface IStudentInterface
    {
        int AddStudentDetails(StudentVM studentVM);
        List<Student> GetStudents();
    }
}
