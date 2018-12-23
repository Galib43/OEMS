using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;

namespace Repository
{
   public class ExamTypeRepository
    {
       ExamManagementDbContext db = new ExamManagementDbContext();

       public bool Add(ExamType examType)
       {
           db.ExamTypes.Add(examType);
           bool isSave = db.SaveChanges() > 0;
           return isSave;
       }

       public bool Update(ExamType examType)
       {
           db.ExamTypes.Attach(examType);
           db.Entry(examType).State=EntityState.Modified;
           bool isUpdate= db.SaveChanges() > 0;
           return isUpdate;
       }

       public bool delete(int id)
       {
           var examType=new ExamType();
           examType= db.ExamTypes.FirstOrDefault(ex => ex.Id == id);
           examType.isDelete = true;
           return Update(examType);

       }

       public ExamType GetById(int id)
       {
          var examtypedata= db.ExamTypes.FirstOrDefault(ex => ex.Id == id);
           return examtypedata;
       }


       public List<ExamType> GetAll()
       {
           var examType = db.ExamTypes.Where(ex => ex.isDelete == false);
           return examType.ToList();
       }

       public List<ExamType> GetExamTypeeBySearch(ExamTypeSearchCriteria model)
       {
           IQueryable<ExamType> examTypes = db.ExamTypes.Where(c => c.isDelete == false).AsQueryable();

           if (!string.IsNullOrEmpty(model.Name))
           {
               examTypes = examTypes.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
           }

           return examTypes.ToList();
       
       }
    }
 
}
