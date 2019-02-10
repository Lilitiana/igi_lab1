using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public int TypeOfServiceID { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public Action action { get; set; }
    }
}
