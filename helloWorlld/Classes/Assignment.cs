using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloWorlld.Classes
{
    public class Assignment
    {
        public string Person { get; set; }
        public string Job { get; set; }

        public Assignment(string p, string j)
        {
            Person = p;
            Job = j;
        }
    }
}
