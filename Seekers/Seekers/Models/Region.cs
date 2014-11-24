using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seekers.Models
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<City> cities { get; set; }
    }
    public class City
    {

        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("countryId")]
        public Country country { get; set; }
        public int countryId { get; set; }
    }
}