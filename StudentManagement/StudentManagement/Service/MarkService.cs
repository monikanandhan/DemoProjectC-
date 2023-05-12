using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using StudentManagement.Model;
using StudentManagement.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagement.Service
{
    public class MarkService
    {
        public AppDbContext Context { get; set; }
        public MarkService(AppDbContext _context)
        {
            Context = _context;
        }

        public Mark_Details AddMarkDetails(MarkVM MarkVM)
        {
            var NewMark = new Mark_Details()
            {
                studentId = MarkVM.studentId,
                TermId = MarkVM.TermId,
                English = MarkVM.English,
                Tamil = MarkVM.Tamil,
                Maths = MarkVM.Maths,
                physics = MarkVM.physics,
                Chemistry = MarkVM.Chemistry,
                ComputerScience = MarkVM.ComputerScience

            };
            Context.Marks.Add(NewMark);
            Context.SaveChanges();
            return NewMark;
        }

        public List<Mark_Details> GetMark() => Context.Marks.ToList();


        /***Get Term Wise student total percentage***/
        public Dictionary<string, Dictionary<string, int>> GetTermWiseStudentMark(int? academicyear)
        {

            var result = Context.Marks.Where(m => m.Student.Academic_Year == academicyear).Select(x => new
            {
                StudentName = x.Student.Name,
                TermName = x.Term.TermName,
                Percentage = (x.English + x.Tamil + x.Maths + x.physics + x.Chemistry + x.ComputerScience) / 6

            }).Where(p => p.Percentage > 80).ToList();

            //using Dictionary//
            Dictionary<string, Dictionary<string, int>> Marks = new Dictionary<string, Dictionary<string, int>>();

            foreach (var mark in result)
            {
               
                var demo = Marks.Where(x => x.Key == mark.StudentName).FirstOrDefault();
                
                if (demo.Value == null)
                {
                    
                    Marks.Add(mark.StudentName, new Dictionary<string, int>()
                {
                    {mark.TermName, mark.Percentage},
                });
                }
                else
                {
                    demo.Value.Add(mark.TermName, mark.Percentage);
                    
                }
               
            }

            //Using Separate Class//

            //List<StudentMarksPojo> studentList = new List<StudentMarksPojo>();


            //foreach (var x in result)
            //{
            //    var demo = studentList.Where(m => m.studentName == x.StudentName).FirstOrDefault();
            //    marksPOJO mark_Details = new marksPOJO();
            //    mark_Details.Termname = x.TermName;
            //    mark_Details.Percentage = x.Percentage;

            //    if (demo == null)
            //    {
            //        StudentMarksPojo studentMarksPojo = new StudentMarksPojo();
            //        studentMarksPojo.studentName = x.StudentName;
            //        List<marksPOJO> marksdemo = new List<marksPOJO>();
            //        marksdemo.Add(mark_Details);
            //        studentMarksPojo.marks = marksdemo;
            //        studentList.Add(studentMarksPojo);
            //    }
            //    else
            //    {
            //        demo.marks.Add(mark_Details);
            //    }
            //}           
            return Marks;

        }

        /***Get student Total Term percentage***/
        public Dictionary<string, double> GetoverallTermPercentage(int academicyear)
        {
           
            var result = Context.Marks.Where(s=>s.Student.Academic_Year==academicyear).Select(x => new
            {
                StudentName = x.Student.Name,              
                Percentage = (x.English + x.Tamil + x.Maths + x.physics + x.Chemistry + x.ComputerScience) / 6,

            });
            //To get percentage sum//
            //Dictionary<string, Dictionary<string, double>> TotalPercentage = new Dictionary<string, Dictionary<string, double>>();

            //foreach (var Students in result)
            //{                
            //    var demo = TotalPercentage.Where(x => x.Key == Students.StudentName).FirstOrDefault();

            //    if (demo.Value == null)
            //    {
            //        TotalPercentage.Add(Students.StudentName, new Dictionary<string, double>()
            //    {
            //        {"overallTotalPercentage", Students.Percentage},
            //    });
            //    }
            //    else
            //    {
            //        var overallpercentage=0.0;                   
            //        var overallpercentageresult=demo.Value.TryGetValue("overallTotalPercentage", out overallpercentage);
            //        overallpercentage = overallpercentage + Students.Percentage;
            //        demo.Value.Remove("overallTotalPercentage");
            //        demo.Value.Add("overallTotalPercentage", overallpercentage);

            //    }
            //}
            ////to get overall percentage >75//
            //Dictionary<string, Dictionary<string, double>> FinaloverallTermPercentage = new Dictionary<string, Dictionary<string, double>>();
            //foreach (KeyValuePair<string, Dictionary<string, double>>  res in TotalPercentage)
            //{

            //    var overallTermpercentage = 0.0;             
            //    var overallTermpercantageresult = res.Value.TryGetValue("overallTotalPercentage", out  overallTermpercentage);
            //    overallTermpercentage = Math.Round(overallTermpercentage/6,2);

            //    /*********To print Total percentage****/

            //    //res.Value.Remove("overallTotalPercentage");
            //    //res.Value.Add("overallTotalPercentage", overallTermpercentage);


            //    /*********To print Total percentage > 75****/
            //    if (overallTermpercentage > 75)
            //    {
            //        FinaloverallTermPercentage.Add(res.Key, new Dictionary<string, double>()
            //        {
            //            {"overallTermpercentage",  overallTermpercentage}

            //     });
            //    }

            //}


            //Without using if-else condition
            Dictionary<string, double> TotalMarks = new Dictionary<string, double>();

            foreach (var item in result)
            {
                var overall = 0.0;
                TotalMarks.TryGetValue(item.StudentName, out overall);
                TotalMarks.Remove(item.StudentName);
                TotalMarks.Add(item.StudentName, overall = overall + item.Percentage);
            }
            Dictionary<string, double> TotalTermMarkspercentage = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> results in TotalMarks)
            {
                var overall = 0.0;
                TotalMarks.TryGetValue(results.Key, out overall);
                TotalTermMarkspercentage.Remove(results.Key);
                var TotalTermpercentage = Math.Round(overall / 6, 2);
                if (TotalTermpercentage >= 70)
                {
                    TotalTermMarkspercentage.Add(results.Key, TotalTermpercentage);
                }
            }
            return TotalTermMarkspercentage;
        }



        /***Get Subject wise Term total percentage***/
        public Dictionary<string, Dictionary<string, int>> GetSubjectWiseTotal(int AcademicYear,string subject)
        {
            var MarksGreaterthanEighty = Context.Marks.Where(m => m.Student.Academic_Year == AcademicYear).Select(m => new
            {
                StudentName = m.Student.Name,
                TermName = m.Term.TermName,
                marks = subject.Equals("physics") ? m.physics : subject.Equals("chemistry") ? m.Chemistry : subject.Equals("English") ?
                m.English : subject.Equals("Tamil") ? m.Tamil : subject.Equals("ComputerScience") ? m.ComputerScience : m.Maths
            }).Where(p=>p.marks>=80 ).ToList();



            Dictionary<string, Dictionary<string, int>> TotalMarks = new Dictionary<string, Dictionary<string, int>>();
            foreach (var item in MarksGreaterthanEighty)
            {
                var StudentNameResult = TotalMarks.Where(x => x.Key == item.StudentName).FirstOrDefault();
                if (StudentNameResult.Value == null)
                {
                    TotalMarks.Add(item.StudentName, new Dictionary<string, int>()
                    {
                        {item.TermName,item.marks }
                    });
                }
                else
                {
                    StudentNameResult.Value.Add(item.TermName, item.marks);
                }

            }

            return TotalMarks;
        }

        /***Get Student wise subject total percentage***/
        public Dictionary<string, double> GetStudentSubjectWiseTotal(int academicYear, string subject)
        {
            var StudentWithMarks = Context.Marks.Where(m => m.Student.Academic_Year == academicYear).Select(m => new
            {
                StudentName = m.Student.Name,
                marks = subject.Equals("physics") ? m.physics : subject.Equals("chemistry") ? m.Chemistry : subject.Equals("English") ?
                m.English : subject.Equals("Tamil") ? m.Tamil : subject.Equals("ComputerScience") ? m.ComputerScience : m.Maths
            }).ToList();

            //studentwise subject sum//

            //Dictionary<string, Dictionary<string, double>> TotalSubjectMarks = new Dictionary<string, Dictionary<string, double>>();
            //foreach (var item in StudentWithMarks)
            //{
            //    var SubjectMark=TotalSubjectMarks.Where(x=>x.Key==item.StudentName).FirstOrDefault(); 
            //    if(SubjectMark.Value==null) 
            //    {
            //        TotalSubjectMarks.Add(item.StudentName, new Dictionary<string, double>()
            //        {

            //            {"TotalMarks",item.marks}

            //        });
            //    }
            //    else
            //    {
            //        var TotalSubjectWiseMark = 0.0;
            //        SubjectMark.Value.TryGetValue("TotalMarks", out TotalSubjectWiseMark);
            //        TotalSubjectWiseMark = TotalSubjectWiseMark + item.marks;
            //        SubjectMark.Value.Remove("TotalMarks");
            //        SubjectMark.Value.Add("TotalMarks", TotalSubjectWiseMark);
            //    }

            //}
            ////studentwise subject percentage >=75//
            //Dictionary<string, Dictionary<string, double>> TotalStudentSubjectMarks = new Dictionary<string, Dictionary<string, double>>();
            //foreach (KeyValuePair<string, Dictionary<string, double>> res in TotalSubjectMarks)
            //{
            //    var overallSubjectpercentage = 0.0;             
            //    var overallTermpercantageresult = res.Value.TryGetValue("TotalMarks", out overallSubjectpercentage);
            //    overallSubjectpercentage = Math.Round(overallSubjectpercentage/6,2);

               
            //    if (overallSubjectpercentage >= 75)
            //    {
            //        TotalStudentSubjectMarks.Add(res.Key, new Dictionary<string, double>()
            //        {
            //            {"TotalMarks", overallSubjectpercentage}

            //     });
            //    }
            //}

            //WIthout using if-else condition
            Dictionary<string, double> TotalMarks = new Dictionary<string, double>();
            
            foreach (var item in StudentWithMarks)
            {
                var overall = 0.0;
                TotalMarks.TryGetValue(item.StudentName, out overall);
                TotalMarks.Remove(item.StudentName);
                TotalMarks.Add(item.StudentName, overall=overall+item.marks);
            }
            Dictionary<string, double> TotalMarksDemo = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> result in TotalMarks)
            {
                var overall = 0.0;
                TotalMarks.TryGetValue(result.Key, out overall);
                TotalMarksDemo.Remove(result.Key);
                var TotalSubjectpercentage = Math.Round(overall / 6, 2);
                if(TotalSubjectpercentage>=75)
                {
                    TotalMarksDemo.Add(result.Key, TotalSubjectpercentage);
                }                               
            }      
            return TotalMarksDemo;
        }



    }
}
