using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class CustomerService
    {
        public int CustomerServiceID { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public DateTime Date { get; set; }
        public Service Service { get; set; }
        public Customer Customer { get; set; }
    }
}
