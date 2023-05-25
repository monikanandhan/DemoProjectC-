using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.ViewModel;

namespace StudentManagement.Service
{
    public class TermService:ITermInterface
    {
        public AppDbContext Context { get; set; }
        private readonly ILogger _logger;
       
        public TermService(AppDbContext _context,ILogger<TermService> logger)
        {
            Context = _context;
            _logger = logger;
            
        }

        public Term AddTermDetails(Term Term)
        {
            _logger.LogInformation("Add-New-Term:{@controller}", GetType().Name);
         

            var NewTerm = new Term()
            {
                TermName = Term.TermName

            };
            Context.Term.Add(NewTerm);
            _logger.LogInformation($"Term-Details {JsonConvert.SerializeObject(NewTerm)}");
            Context.SaveChanges();
            return NewTerm;
        }

       
    }
}
