using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class Country
    {
        public Country()
        {

        }
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}