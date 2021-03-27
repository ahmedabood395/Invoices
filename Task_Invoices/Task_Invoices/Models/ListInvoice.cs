using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_Invoices.Models
{
    public class ListInvoice
    {
        public string Product { get; set; }

        public string Quantity { get; set; }

        public int? Price { get; set; }
    }
}