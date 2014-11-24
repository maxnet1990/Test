using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seekers.Models
{
    public class Catogery
    {
        [Key]
        public int id {get;set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<JopDate> Jopdate { get; set; }


    }

    public class JopDate
    {
        [Key]
        public int id { get; set; }
        public DateTime displayJopDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime deadline { get; set; }

        [ForeignKey("jopId")]
        public Jop jop { get; set; }
        [ForeignKey("categoryId")]
        public Catogery category { get; set; }


        public int jopId { get; set; }
        public int categoryId { get; set; }
    }

    public class Jop {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description {get;set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set;}
        public List<JopDate> Jopdate { get; set; }
        [ForeignKey("cityId")]
        public City city { get; set; }
        public int cityId { get; set; }


    
    }

}