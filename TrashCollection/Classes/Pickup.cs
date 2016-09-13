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
        public string street1;
        public string street2;
        public string city;
        public string state;
        public string zipcode;
        public bool status; //inactive or active

        public Pickup()
        {

        }


        //DisplayPickup
        //ChangeStatus

    }
}