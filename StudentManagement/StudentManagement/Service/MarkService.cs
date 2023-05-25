using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mysqlx;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.ViewModel;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace StudentManagement.Service
{
    public class MarkService:IMarkInterface
    {
        
        public AppDbContext Context { get; set; }
        private readonly ILogger _logger;
        
        public MarkService(AppDbContext _context,ILogger<MarkService> logger)
        {
           
            Context = _context;
            _logger = logger;
          
           
        }

        public int ToCheckTermId(int TermId, int studentId)
        {
            var TermIdvalidation = Context.Marks.Where(x => x.TermId == TermId && x.studentId==studentId).ToList();
            return TermIdvalidation.Count();            
        }

        public Mark_Details AddMarkDetails(MarkVM MarkVM)
        {
            _logger.LogInformation(" Add-New-Mark-Details:{@controller}", GetType().Name);    
            
            try
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
                //if (Context.Marks.Select(x => x.TermId).Count() <= 1)
                //{
                Context.Marks.Add(NewMark);              
                Context.SaveChanges();
                _logger.LogInformation($"New-Mark-Details {JsonConvert.SerializeObject(NewMark)}");
                return NewMark;               
                //}
                //else
                //{
                //    Console.WriteLine("Term Id should not be repeated");
                //}
            
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<Mark_Details> GetMark()
        {
            _logger.LogInformation("Get-All-Mark-Details:{@controller}", GetType().Name);
            var GetAll= Context.Marks.ToList();
            _logger.LogInformation($"New-Mark-Details {JsonConvert.SerializeObject(GetAll)}");
            return GetAll.ToList(); 
        }

        /***Get Term Wise student total percentage***/

        public Dictionary<string, Dictionary<string, double>> GetTermWiseStudentMark(int academicyear)
        {
            _logger.LogInformation("Get-Term-wise-student-Mark-Details-greater-than-eighty:{@controller}", GetType().Name);
            _logger.LogInformation($"User Input {(academicyear)}");
            try
            {

                var result = Context.Marks.Where(m => m.Student.Academic_Year == academicyear).Select(x => new
                {
                    StudentName = x.Student.Name,
                    TermName = x.Term.TermName,
                    Percentage = (x.English + x.Tamil + x.Maths + x.physics + x.Chemistry + x.ComputerScience) / 6

                }).Where(p => p.Percentage > 80).ToList();
                _logger.LogInformation($"Term-wise-Mark-Details {JsonConvert.SerializeObject(result)}");
                //using Dictionary//
                Dictionary<string, Dictionary<string, double>> Marks = new Dictionary<string, Dictionary<string, double>>();

                foreach (var mark in result)
                {

                    var demo = Marks.Where(x => x.Key == mark.StudentName).FirstOrDefault();

                    if (demo.Value == null)
                    {

                        Marks.Add(mark.StudentName, new Dictionary<string, double>()
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
                _logger.LogInformation($"Term-Wise-percentage-greater-than-eighty {JsonConvert.SerializeObject(Marks)}");
                return Marks;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        /***Get student Total Term percentage***/
        public Dictionary<string, double> GetoverallTermPercentage(int academicyear,int fpercentage)
        {
            _logger.LogInformation("Get-Term-wise-student-overall-percentage-greater-than-eighty:{@controller}", GetType().Name);
            _logger.LogInformation($"User Input {(academicyear,fpercentage)}");
            try
            {
                var result = Context.Marks.Where(s => s.Student.Academic_Year == academicyear).Select(x => new
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
                _logger.LogInformation($"Term-wise-Mark-Details {JsonConvert.SerializeObject(result)}");

               
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
                    if (TotalTermpercentage >= fpercentage)
                    {
                        TotalTermMarkspercentage.Add(results.Key, TotalTermpercentage);
                    }
                }
                _logger.LogInformation($"student-wise-Term-overall-percentage {JsonConvert.SerializeObject(TotalTermMarkspercentage)}");
                return TotalTermMarkspercentage;
            }catch(Exception ex)
            {
                throw;
            }
        }




        /***Get Subject wise Term total percentage***/
        public Dictionary<string, Dictionary<string, double>> GetSubjectWiseTotal(int academicyear, string subject)
        {
            _logger.LogInformation("Get-subject-wise-student--percentage-greater-than-eighty:{@controller}",  GetType().Name);
            _logger.LogInformation($"User Input {(academicyear,subject)}");
            try
            {
                var MarksGreaterthanEighty = Context.Marks.Where(m => m.Student.Academic_Year == academicyear).Select(m => new
                {
                    StudentName = m.Student.Name,
                    TermName = m.Term.TermName,
                    marks = subject.Equals("physics") ? m.physics : subject.Equals("chemistry") ? m.Chemistry : subject.Equals("English") ?
                    m.English : subject.Equals("Tamil") ? m.Tamil : subject.Equals("ComputerScience") ? m.ComputerScience : m.Maths
                }).Where(p => p.marks >= 80).ToList();

                _logger.LogInformation($"subject-wise-percentage-Details {JsonConvert.SerializeObject(MarksGreaterthanEighty)}");

                Dictionary<string, Dictionary<string, double>> TotalMarks = new Dictionary<string, Dictionary<string, double>>();
                foreach (var item in MarksGreaterthanEighty)
                {
                    var StudentNameResult = TotalMarks.Where(x => x.Key == item.StudentName).FirstOrDefault();
                    if (StudentNameResult.Value == null)
                    {
                        TotalMarks.Add(item.StudentName, new Dictionary<string, double>()
                    {
                        {item.TermName,item.marks }
                    });
                    }
                    else
                    {
                        StudentNameResult.Value.Add(item.TermName, item.marks);
                    }

                }
                _logger.LogInformation($"student-wise-subject-percentage {JsonConvert.SerializeObject(TotalMarks)}");

                return TotalMarks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /***Get Student wise subject total percentage***/
        public Dictionary<string, double> GetStudentSubjectWiseTotal(int academicyear, string subject, int fpercentage)
        {
            _logger.LogInformation("Get-subject-wise-student-overall-percentage-greater-than-eighty:{@controller}" ,GetType().Name);
            _logger.LogInformation($"User Input {(academicyear,subject,fpercentage)}");
            try
            {
                var StudentWithMarks = Context.Marks.Where(m => m.Student.Academic_Year == academicyear).Select(m => new
                {
                    StudentName = m.Student.Name,
                    marks = subject.Equals("physics") ? m.physics : subject.Equals("chemistry") ? m.Chemistry : subject.Equals("English") ?
                    m.English : subject.Equals("Tamil") ? m.Tamil : subject.Equals("ComputerScience") ? m.ComputerScience : m.Maths
                }).ToList();
                _logger.LogInformation($"subject-wise-percentage-Details {JsonConvert.SerializeObject(StudentWithMarks)}");

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
                    TotalMarks.Add(item.StudentName, overall = overall + item.marks);
                }
                Dictionary<string, double> TotalMarksDemo = new Dictionary<string, double>();
                foreach (KeyValuePair<string, double> result in TotalMarks)
                {
                    var overall = 0.0;
                    TotalMarks.TryGetValue(result.Key, out overall);
                    TotalMarksDemo.Remove(result.Key);
                    var TotalSubjectpercentage = Math.Round(overall / 6, 2);
                    if (TotalSubjectpercentage >= fpercentage)
                    {
                        TotalMarksDemo.Add(result.Key, TotalSubjectpercentage);
                    }
                }
                _logger.LogInformation($"student-wise-subject-overall-percentage {JsonConvert.SerializeObject(TotalMarksDemo)}");
                return TotalMarksDemo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
