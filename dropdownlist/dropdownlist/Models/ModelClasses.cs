using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dropdownlist.Models
{
    //Land class
    public class Land
    {
        public int id { get; set; } //identifier land
        public string nm { get; set; } //name
    }

    //City class
    public class City
    {
        public int id { get; set; } //identifier city
        public string nm { get; set; } //name
        public int idLand { get; set; } //identifier land
        public int PopulationSize { get; set; } //Population Size
    }

    public class ViewLand
    {
        public int idLand { get; set; } //identifier land
        public List<City> citys { get; set; } //citys
    }
}
