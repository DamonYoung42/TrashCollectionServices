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
        public PickupAddressJunc pAJ = new PickupAddressJunc();
        //public int[] genericArray;
        public List<Pickup> employeePickups;


        //public PickupAddressJunc pAddrJunc = db.PickupAddressJunc.Where(g => g.PickupID == g.pickup.PickupID);
        //public Address address = PickupAddressJunc.pAJ.AddressID.Select(pAJ.PickupID = Pickup.PickupID); 


        //public int GetAddressIDForPickup(int PickupID)
        //{
        //    foreach (Pickup pickupItem in employeePickups)
        //    {
        //        if (pickupItem.PickupID == pAJ.PickupID)
        //        {
        //            address.AddressID = pAJ.AddressID;
        //            break;
        //        }
        //    }
        //    return address.AddressID;
        //}




        //    IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (int i = 0; i < genericArray.Length; i++)
        //    {
        //        yield return genericArray[i];
        //    }

        //}

    }
}
