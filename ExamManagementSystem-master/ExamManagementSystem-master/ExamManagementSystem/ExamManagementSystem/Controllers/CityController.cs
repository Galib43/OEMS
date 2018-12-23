using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class CityController : Controller
    {
        CityManager _cityManager=new CityManager();
        //
        // GET: /City/
       
         public ActionResult Index(CitySearchCriteria model)
          {
            var cities = _cityManager.GetCityeBySearch(model);

            if (cities == null)
            {
                cities = new List<City>();
            }

            model.CountryListItem = GetAllCountryList();

            model.City = cities;
            return View(model);

        }

        public ActionResult Entry()
        {
            var model=new CityEntryVm();
            model.CountryListItem = GetAllCountryList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Entry(CityEntryVm model)
        {
            var cities = Mapper.Map<City>(model);
            bool isSave = _cityManager.Add(cities);
            if (isSave)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var cities = _cityManager.GetById(id);
                var model = Mapper.Map<CityEntryVm>(cities);
                model.CountryListItem = GetAllCountryList();
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(CityEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var cities = Mapper.Map<City>(model);
                bool isUpdate = _cityManager.Update(cities);
                if (isUpdate)
                {
                    model.CountryListItem = GetAllCountryList();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                bool isDelete = _cityManager.Deleted(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public List<SelectListItem> GetAllCountryList()
        {
            return
                _cityManager.GetAllCountryInfo()
                    .Select(c => new SelectListItem() {Value = c.Id.ToString(), Text = c.Name})
                    .ToList();
        } 
	}
}