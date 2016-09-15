using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class EmployeePickupViewModel //: IEnumerable
    {
        public Employee employee = new Employee();
        public Pickup pickup = new Pickup();
        public Address address = new Address();
        public PickupAddressJunc pickupAddressJunc = new PickupAddressJunc();
        //public int[] genericArray;
        public List<Pickup> employeePickups;




        //    IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (int i = 0; i < genericArray.Length; i++)
        //    {
        //        yield return genericArray[i];
        //    }

        //}

    }
}
