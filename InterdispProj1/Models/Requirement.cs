using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterdispProj1.Models
{
    public class Requirement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Unit> Units { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
