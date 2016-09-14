using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Classes
{
    public class Pickup
    {

        public int pickupID;
        public Customer customer;
        public Employee employee;
        public Address address;
        public DateTime pickupDate;
        //These are the address variables we will need for the pickups.
        //public string address.street1;
        //public string address.street2;
        //public string address.city;
        //public string address.state;
        //public string address.zipcode;
        public bool status; //inactive or active

        public Pickup(int pickupID, Customer customer, DateTime pickupDate)
        {
            pickupID = 0;
            Customer newCustomer = this.customer;
            pickupDate = DateTime.Parse("9/13/2016");
        }





        //DisplayPickup
        //ChangeStatus

    }
}