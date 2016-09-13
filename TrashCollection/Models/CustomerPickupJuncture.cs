using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class CustomerPickupJuncture
    {
        public CustomerPickupJuncture()
        {

        }
        [Key]
        public int CustomerPickupJunctureID {get; set;}

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("Pickup")]
        public int PickupID { get; set; }
        public Pickup Pickup { get; set; }


    }
}