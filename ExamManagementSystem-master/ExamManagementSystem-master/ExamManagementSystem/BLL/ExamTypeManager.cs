using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;

namespace BLL
{
    public class ExamTypeManager
    {
        ExamTypeRepository _examTypeRepository = new ExamTypeRepository();

        public bool Add(ExamType examType)
        {
            return _examTypeRepository.Add(examType);
        }

        public bool Update(ExamType examType)
        {
            return _examTypeRepository.Update(examType);
        }

        public bool Delete(int id)
        {
            return _examTypeRepository.delete(id);
        }
        public ExamType GetById(int id)
        {
            return _examTypeRepository.GetById(id);
        }

        public List<ExamType> GetAll()
        {
            return _examTypeRepository.GetAll();
        }

        public List<ExamType> GetExamTypeeBySearch(ExamTypeSearchCriteria model)
        {
            return _examTypeRepository.GetExamTypeeBySearch(model);
        }
    }
}
