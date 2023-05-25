using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Model
{
    public class Term
    {
        [Range(0, 6, ErrorMessage = "Term Should be 0 to 6")]
        public int id { get; set; }       
        public string TermName { get; set; }
    }
}
