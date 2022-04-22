using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace table_sort.Infrastructure
{
    public class Utils
    {
        public static string GetSimbolSort(string field, string sort)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(field))
                {
                    if (sort.Contains("_desc"))
                    {
                        result = "&darr;";
                    }
                    if (sort.Contains("_asc"))
                    {
                        result = "&uarr;";
                    }
                }
            }
            return result;
        }
    }
}
