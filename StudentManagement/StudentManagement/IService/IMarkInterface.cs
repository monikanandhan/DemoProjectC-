using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.IService
{
    public interface IMarkInterface
    {
        int ToCheckTermId(int TermId, int studentId);
        Mark_Details AddMarkDetails(MarkVM MarkVM);
        List<Mark_Details> GetMark();
        Dictionary<string, Dictionary<string, double>> GetTermWiseStudentMark(int academicyear);
        Dictionary<string, double> GetoverallTermPercentage(int academicyear, int fpercentage);
        Dictionary<string, Dictionary<string, double>> GetSubjectWiseTotal(int academicyear, string subject);
        Dictionary<string, double> GetStudentSubjectWiseTotal(int academicyear, string subject, int fpercentage);


    }
}
