using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_blazor.Models
{
    public class Person
    {
        public int Id { set; get; }
        public string Famip { set; get; }
        public string Namep { set; get; }
        public string Otchp { set; get; }
        public DateTime Dr { set; get; }
    }
}
