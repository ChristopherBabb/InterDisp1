using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterdispProj1.Models
{
    public class DataEntry
    {
        public string Id { get; set; }
        public Requirement Requirement { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Value { get; set; }
        public Unit Unit { get; set; }
    }
}
