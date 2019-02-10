using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class Action
    {
        public int ActionID { get; set; }
        public string Name { get; set; }
        public int ServiceID { get; set; }
        public double DiscountPrice {get;set;}
        public Service service { get; set; }
    }
}
