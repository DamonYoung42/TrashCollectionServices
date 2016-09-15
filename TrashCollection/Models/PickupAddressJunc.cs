using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class PickupAddressJunc
    {
        public PickupAddressJunc()
        {

        }

        [Key]
        public int PickupAddressJuncID { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Pickup")]
        public int PickupID { get; set; }
        public Pickup Pickup { get; set; }



    }

    


}