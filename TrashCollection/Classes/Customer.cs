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
        public Address address;
        public string telephoneNumber;
        public string emailAddress;
        public string role;
        public ICollection<DateTime> Calendar;//a collection of dates, not a calendar

        public Customer()
        {

        }
        //ViewCalendar
            //view a list of days and pickups ("On 9/13/2016 at this address your garbage will be picked up"
        //ViewPickups
            //view a list of addresses and dates

        //AddAdditionalPickup //adds a pickup to the schedule
        //RemovePickup //renders a pickup inactive
        //AddPickup //renders a pickup active
        //EnterDateRange to render several pickups inactive

        //ViewAddresses that customer has service
        //AddAddress
        //RemoveAddress
        //EditAddress
        //ViewAddressAccountDetails(address, pickups, subscription)
    }
}