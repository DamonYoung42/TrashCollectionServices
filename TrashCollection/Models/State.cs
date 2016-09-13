using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class State
    {
        public State()
        {

        }
        [Key]
        public string StateID {get; set;}
        public string StateName {get; set;}

        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public Country Country { get; set; }
         



    }
}