using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.Service
{
    public class TermService
    {
        public AppDbContext Context { get; set; }
        public TermService(AppDbContext _context)
        {
            Context = _context;
        }

        public Term AddTermDetails(Term Term)
        {
            var NewTerm = new Term()
            {
                TermName = Term.TermName

            };
            Context.Term.Add(NewTerm);
            Context.SaveChanges();
            return NewTerm;
        }

       
    }
}
