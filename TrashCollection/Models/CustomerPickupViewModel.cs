using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class CustomerPickupViewModel
    {

        public Customer customer = new Customer();
        public Pickup pickup = new Pickup();
        public Address address = new Address();
        public City city = new City();
        public List<Pickup> customerPickups;

    }
}