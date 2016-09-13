using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Classes
{
    public class Customer
    {
        public int customerID;
        public string firstName;
        public string lastName;
        public string street1;
        public string street2;
        public string city;
        public string state;
        public string zipcode;
        public string telephoneNumber;
        public string emailAddress;
        public string role;
        public ICollection<DateTime> Calendar;//a collection of dates, not a calendar


    }
}