using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auto_complete.Models
{
    //class medical institution
    public class Lpu
    {
        public string CDLPU { get; set; } //regional code
        public string CDREESTR { get; set; } //federal code
        public string Name { get; set; } //name of the medical institution
    }
}
