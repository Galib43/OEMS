using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;

namespace Repository
{

    public class CityRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();

        public bool Add(City city)
        {
            db.Cities.Add(city);
            return db.SaveChanges() > 0;
        }

        public List<City> GetAll()
        {
            List<City> cities = db.Cities.Where(c => c.isDelete == false).ToList();
            return cities;
        }

        public City GetById(int id)
        {         
            var city = db.Cities.FirstOrDefault(c => c.Id == id);
            return city;
        }


        public bool Update(City city)
        {
            db.Cities.Attach(city);
            db.Entry(city).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Deleted(int id)
        {
            City city = new City();
            city = db.Cities.FirstOrDefault(c => c.Id == id);
            city.isDelete = true;

            return Update(city);
        }

        public List<Country> GetAllCountryInfo()
        {
           List<Country>countries = db.Countries.Where(c => c.isDelete == false).ToList();
            return countries;
        }

        public List<City> GetCityeBySearch(CitySearchCriteria criteria)
        {
            IQueryable<City> cities = db.Cities.Where(c => c.isDelete == false).AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                cities = cities.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            }
           
            return cities.ToList();
        }

       
    }


}
