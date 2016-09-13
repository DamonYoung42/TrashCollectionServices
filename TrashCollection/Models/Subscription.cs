using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollection.Models
{
    public class Subscription
    {
        public Subscription()
        {

        }
        [Key]
        public int SubscriptionID { get; set; }

        [ForeignKey("Pickup")]
        public int PickupID { get; set; }
        public Pickup Pickup { get; set; }


        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public decimal Fee { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceDue { get; set; }
        public bool AutomaticPayments { get; set; }
        public bool PaperlessBilling { get; set; }
        public string PaymentMethod { get; set; }

    }
}