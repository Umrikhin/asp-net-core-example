using crud_single.Models;
using System.Collections.Generic;

namespace crud_single.Services
{
    public interface ILands
    {
        List<Country> lands { get; }
        void EditCountry(Country country);
        void DeleteCountry(Country country);
        int AddCountry(Country country);
    }
}
