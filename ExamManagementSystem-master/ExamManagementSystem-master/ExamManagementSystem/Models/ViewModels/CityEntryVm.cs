using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModels
{
   public class CityEntryVm
    {
        public int Id { get; set; }
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public int CountryId { get; set; }

        public bool isDelete { get; set; }

        public List<SelectListItem>CountryListItem { get; set; }
    }
}
