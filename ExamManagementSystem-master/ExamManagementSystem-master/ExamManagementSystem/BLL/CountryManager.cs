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
   public class CountryManager
    {
       CountryRepository _countryRepository=new CountryRepository();
       public bool Add(Country country)
       {
           return _countryRepository.Add(country);
       }

       public bool Update(Country country)
       {
           return _countryRepository.Update(country);
       }

       public bool Delete(int id)
       {
           return _countryRepository.Delete(id);
       }

       public Country GetById(int id)
       {
           return _countryRepository.GetById(id);
       }

       public List<Country> GetAllCountry()
       {
           return _countryRepository.GetAllCountry();
       }

       public List<Country> GetCountryeBySearch(CountrySearchCriteria model)
       {
           List<Country> countries = _countryRepository.GetCountryeBySearch(model);
           return countries;
       }
    }
}
