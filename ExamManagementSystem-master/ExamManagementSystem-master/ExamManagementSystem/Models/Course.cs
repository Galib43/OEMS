﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class Course
    {
        public int Id { get; set; }
        public virtual Organization Organization { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
        public int Credit { get; set; }
        public string Outline { get; set; }
        public string Tag { get; set; }
        public bool IsDeleted { get; set; }

        public List<Exam> Exams { get; set; }

        public List<Batch> Batches { get; set; }
        public virtual List<Trainer> Trainers { get; set; }
        public virtual List<Participant> Participants { get; set; }


    }
}
