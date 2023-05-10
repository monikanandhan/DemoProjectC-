namespace StudentManagement.Model
{
    public class Mark_Details
    {
        public int Id { get; set; } 
        public int studentId { get; set; }
        public int TermId { get;set; }
        public int English { get;set; }
        public int Tamil { get;set; }
        public int Maths { get;set; }
        public int physics { get;set; }
        public int Chemistry { get;set; }
        public int ComputerScience { get;set; }

        //Navigation Properties

        public Student Student { get;set; } 
        public Term Term { get;set; }

    }
}
