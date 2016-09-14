﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace TrashCollection.Models
{
    public class Pickup
    {
        public Pickup()
        {

        }
        [Key]
        public int PickupID { get; set; }
        public DateTime PickupDate { get; set; }

        //this bool is "active"/"inactive"
        public bool Status { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }


        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}