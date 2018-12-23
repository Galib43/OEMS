using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Repository;

namespace BLL
{

    public class CityManager
    {
        CityRepository _cityRepository = new CityRepository();
        public bool Add(City city)
        {
            //Logic Here
            return _cityRepository.Add(city);
        }

        public List<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public bool Update(City city)
        {
            return _cityRepository.Update(city);
        }

        public List<Country> GetAllCountryInfo()
        {
            return _cityRepository.GetAllCountryInfo();
        }

        public bool Deleted(int id)
        {
            return _cityRepository.Deleted(id);
        }

        public List<City> GetCityeBySearch(CitySearchCriteria criteria)
        {
            List<City> cities = _cityRepository.GetCityeBySearch(criteria);
            return cities;
        }



        
    }
}
