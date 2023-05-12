using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModel
{
    public class StudentVM
    {
       
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "only alphabets are allowed")]
        public string Name { get; set; }
        [Range(12, 12, ErrorMessage = "Standard Must be 12th")]
        public int standard { get; set; }
        [RegularExpression(@"^[2][0][2][3]$", ErrorMessage = "only Academic year 2023 is allowed")]
        public int Academic_Year { get; set; }
        [RegularExpression(@"^[F-fM-m]+$", ErrorMessage = "only 'F','M' are allowed")]
        public char Gender { get; set; }
    }
}
