using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchCriteria
{
   public class ExamTypeSearchCriteria
    {
        public int Id { get; set; }
        [Display(Name = "Exam Type")]
        public string Name { get; set; }
        public bool isDelete { get; set; }
        public List<Exam> Exams { get; set; }
        public List<ExamType> ExamTypes { get; set;} 
        
    }
}
