using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorization.Models
{
    public interface IApartmentsRepository
    {
        List<Apartment> Apartments { get; }

        void AddApartment(Apartment apartment);
        void EditApartment(Apartment apartment);
        void DeleteApartment(Apartment apartment);
    }

    public class ApartmentsRepository : IApartmentsRepository
    {
        private List<Apartment> data;

        public ApartmentsRepository()
        {
            data = new List<Apartment>()
            {
                new Apartment() { ID = Guid.NewGuid().ToString(), NumberOfRooms = 1, Level=3, NumberOfStoreys=9, Adres="Pogodin St. 7", Space=33.4f, Price=2300000  },
                new Apartment() { ID = Guid.NewGuid().ToString(), NumberOfRooms = 1, Level=6, NumberOfStoreys=23, Adres="Sivers Avenue 12", Space=40.5f, Price=5300000  },
                new Apartment() { ID = Guid.NewGuid().ToString(), NumberOfRooms = 1, Level=7, NumberOfStoreys=14, Adres="Profsoyuznaya St. 17", Space=37.0f, Price=4100000  },
                new Apartment() { ID = Guid.NewGuid().ToString(), NumberOfRooms = 2, Level=1, NumberOfStoreys=3, Adres="North St. 178", Space=42.0f, Price=3250000  },
                new Apartment() { ID = Guid.NewGuid().ToString(), NumberOfRooms = 2, Level=5, NumberOfStoreys=9, Adres="Stepnaya St. 178", Space=60.0f, Price=3500000  }
            };
        }

        List<Apartment> IApartmentsRepository.Apartments => data;

        public void AddApartment(Apartment apartment)
        {   
            data.Add(apartment);
        }

        public void EditApartment(Apartment apartment)
        {
            data.Where(p => p.ID == apartment.ID).ToList().ForEach(x => { x.NumberOfRooms = apartment.NumberOfRooms; x.Level = apartment.Level; x.NumberOfStoreys = apartment.NumberOfStoreys; x.Adres = apartment.Adres; x.Space = apartment.Space; x.Price = apartment.Price; });
        }

        public void DeleteApartment(Apartment apartment)
        {
            data.RemoveAll(x => x.ID == apartment.ID);
        }
    }
}
