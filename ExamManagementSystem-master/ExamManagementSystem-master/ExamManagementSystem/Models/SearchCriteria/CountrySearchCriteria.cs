﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchCriteria
{
   public class CountrySearchCriteria
    {
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        public string Name { get; set; }

        public bool isDelete { get; set; }
        public List<City> Cities { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Country> Countries { get; set; } 
    }
}
