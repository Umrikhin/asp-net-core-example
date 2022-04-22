using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace timer_ajax.Models
{
    public class Alert
    {
        public string Msg { get; set; }

        public DateTime TimeRun { get; set; }
    }
    
}
