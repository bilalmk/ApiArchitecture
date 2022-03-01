using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIArchitecture.Entities
{
    public class Category
    {
        public int ID { get; init; }
        public int TypeID { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }
        public DateTimeOffset UpdateDateTime { get; set; }
        public int Status { get; set; }
    }
}
