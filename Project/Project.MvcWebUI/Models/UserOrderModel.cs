﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.MvcWebUI.Entity;

namespace Project.MvcWebUI.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}