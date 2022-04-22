using dropdownlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dropdownlist.Infrastructure
{
    public class Utils
    {
        public static List<Land> GetLands()
        {
            List<Land> result = new List<Land>();
            result.Add(new Land() { id = 1, nm = "Russia" });
            result.Add(new Land() { id = 2, nm = "Ukraine" });
            result.Add(new Land() { id = 3, nm = "France" });
            return result;
        }

        public static List<City> GetCitys()
        {
            List<City> result = new List<City>();
            result.Add(new City() { id = 1, nm = "Moscow", idLand = 1, PopulationSize = 11920000 });
            result.Add(new City() { id = 2, nm = "Rostov-on-Don", idLand = 1, PopulationSize = 1100000 });
            result.Add(new City() { id = 3, nm = "Stavropol", idLand = 1, PopulationSize = 408000 });
            result.Add(new City() { id = 4, nm = "Krasnodar", idLand = 1, PopulationSize = 773000 });
            result.Add(new City() { id = 5, nm = "Kiev", idLand = 2, PopulationSize = 2800000 });
            result.Add(new City() { id = 6, nm = "Paris", idLand = 3, PopulationSize = 2160000 });
            result.Add(new City() { id = 7, nm = "Marseille", idLand = 3, PopulationSize = 861635 });
            return result;
        }
    }
}
