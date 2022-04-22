using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace table_group.Models
{
    public interface IOfficesRepository
    {
        List<Office> Offices { get; }
    }

    public class OfficesRepository : IOfficesRepository
    {
        private List<Office> data;

        public OfficesRepository()
        {
            data = new List<Office>()
            {
                new Office() { ID = 1, Country = "USA", OfficeName = "USA Office Boston" },
                new Office() { ID = 2, Country = "RF", OfficeName = "RF Office Krasnodar" },
                new Office() { ID = 3, Country = "Canada", OfficeName = "Canada Office Toronto" }
            };
        }

        List<Office> IOfficesRepository.Offices => data;
    }
}
