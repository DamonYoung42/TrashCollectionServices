using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrashCollection.Models
{
    public class Address
    {
        public Address()
        {

        }

        [Key]
        public int AddressID { get; set; }
        public string Street1 { get; set;}
        public string Street2 { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }
        public City City { get; set; }



        [ForeignKey("Zipcode")]
        public int ZipID { get; set; }
        public Zipcode Zipcode { get; set; }
    }
}