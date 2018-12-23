using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Models.SearchCriteria;

namespace ExamManagementSystem.Controllers
{
    public class ExamTypeController : Controller
    {
        ExamTypeManager _examTypeManager=new ExamTypeManager();
        //
        // GET: /ExamType/
        public ActionResult Index(ExamTypeSearchCriteria model)
        {
            var examtypes = _examTypeManager.GetExamTypeeBySearch(model);

            if (examtypes == null)
            {
                examtypes = new List<ExamType>();
            }


            model.ExamTypes = examtypes;
            return View(model);

        }

        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entry(ExamType examType)
        {
            if (ModelState.IsValid)
            {
                bool examtype = _examTypeManager.Add(examType);
                if (examtype)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var examType = new ExamType();
                examType = _examTypeManager.GetById(id);
                if (examType != null)
                {
                    return View(examType);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ExamType examType)
        {
            bool isUpdate = _examTypeManager.Update(examType);

            if (isUpdate)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            bool isDelete = _examTypeManager.Delete(id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
	}
}