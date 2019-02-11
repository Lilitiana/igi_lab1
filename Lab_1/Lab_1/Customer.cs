using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public double TotalCost { get; set; }
        public List <CustomerService> CustomerServices { get; set; }
    }
}
