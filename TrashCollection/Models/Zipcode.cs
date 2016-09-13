using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class Zipcode
    {
        public Zipcode()
        {

        }
        [Key]
        public int ZipID {get; set;}
        public string ZipcodeName { get; set; }


    }
}