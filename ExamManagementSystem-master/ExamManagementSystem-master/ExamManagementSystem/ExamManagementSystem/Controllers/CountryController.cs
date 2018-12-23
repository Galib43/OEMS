using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Models.SearchCriteria;

namespace ExamManagementSystem.Controllers
{
    public class CountryController : Controller
    {
        CountryManager _countryManager=new CountryManager();
        // GET: /Country/
        public ActionResult Index(CountrySearchCriteria model)
        {
            var countries = _countryManager.GetCountryeBySearch(model);

            if (countries == null)
            {
                countries = new List<Country>();
            }


            model.Countries = countries;
            return View(model);

        }
        //GetEntry
        public ActionResult Entry()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Entry(Country country)
        {
            if (ModelState.IsValid)
            {
                bool isSave = _countryManager.Add(country);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var country=new Country();
            if (id > 0)
            {
                country = _countryManager.GetById(id);
                return View(country);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _countryManager.Update(country);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            bool isDelete = _countryManager.Delete(id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
	}
}