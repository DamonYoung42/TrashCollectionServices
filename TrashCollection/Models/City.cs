using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class City
    {
        public City()
        {

        }
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        [ForeignKey("State")]
        public string StateID { get; set; }
        public State State { get; set; }
    }   
}