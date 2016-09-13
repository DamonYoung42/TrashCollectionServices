using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Classes
{
    public class Employee
    {
        public int employeeID;
        public string firstName;
        public string lastName;
        public string emailAddress;
        public string role; //employee or customer
        public int passcode; //four digit, combined with empID
        public string password;
        public ICollection<Address> Addresses;

        public Employee()
        {

        }

        //ViewRoute
        //ViewCalendar
        //ViewPickupInformation(address, pickup schedule)
        ////employee does not need to know what the customer name is


    }
}