using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class EmployeePickupViewModel:IEnumerable
    {
        public Employee employee = new Employee();
        public Pickup pickup = new Pickup();
        public int[] genericArray;


        public List<Pickup> employeePickups = new List<Pickup>
            {
                new Pickup { PickupID = 1, PickupDate = DateTime.Parse("9/15/2016"), Status = true, EmployeeID = 1},
                new Pickup { PickupID = 2, PickupDate = DateTime.Parse("9/15/2016"), Status = true, EmployeeID = 1},
                new Pickup { PickupID = 3, PickupDate = DateTime.Parse("9/15/2016"), Status = false, EmployeeID = 1}
            };

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < genericArray.Length; i++)
            {
                yield return genericArray[i];
            }

        }

    }
}
}