using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Model
{
    public class Mark_Details
    {
        public int Id { get; set; } 
        public int studentId { get; set; }
        [Range(1, 6, ErrorMessage = "Term Must be between 1 to 6")]
        public int TermId { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int English { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int Tamil { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int Maths { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int physics { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int Chemistry { get;set; }
        [Range(0, 100, ErrorMessage = "Marks Must be between 0 to 100")]
        public int ComputerScience { get;set; }

        //Navigation Properties

        public Student Student { get;set; } 
        public Term Term { get;set; }

    }
}
