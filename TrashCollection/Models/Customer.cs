using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class Customer
    {
        public Customer()
        {

        }

        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }

        public string EmailAddress { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }

    }
}