using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace table_group.Models
{
    public interface IPersonsRepository
    {
        List<Person> Persons { get; }

        void AddPerson(Person person);
        void EditPerson(Person person);
        void DeletePerson(Person person);
    }

    public class PersonsRepository : IPersonsRepository
    {
        private List<Person> data;

        public PersonsRepository()
        {
            data = new List<Person>()
            {
                new Person() { ID = 1, LoginName = "bono", DateLogin = DateTime.Parse("01.02.2021 16:30"), DateExit = DateTime.Parse("01.02.2021 16:40"), idOffice = 1 },
                new Person() { ID = 2, LoginName = "sasha", DateLogin = DateTime.Parse("02.02.2021 15:30"), DateExit = DateTime.Parse("02.02.2021 15:35"), idOffice = 1 },
                new Person() { ID = 3, LoginName = "masha", DateLogin = DateTime.Parse("05.03.2021 06:30"), DateExit =  DateTime.Parse("05.03.2021 07:20"), idOffice = 2 },
                new Person() { ID = 4, LoginName = "katerina", DateLogin = DateTime.Parse("12.02.2021 12:35"), DateExit = DateTime.Parse("12.02.2021 12:55"), idOffice = 1 },
                new Person() { ID = 5, LoginName = "sveta", DateLogin = DateTime.Parse("01.01.2021 20:00"), DateExit = DateTime.Parse("01.01.2021 20:05"), idOffice = 2  },
                new Person() { ID = 5, LoginName = "adik", DateLogin = DateTime.Parse("22.04.2022 20:00"), DateExit = DateTime.Parse("01.01.2021 20:05"), idOffice = 3  }
            };
        }

        List<Person> IPersonsRepository.Persons => data;

        public void AddPerson(Person person)
        {   
            data.Add(person);
        }

        public void EditPerson(Person person)
        {
            data.Where(p => p.ID == person.ID).ToList().ForEach(x => { x.LoginName = person.LoginName; x.DateLogin = person.DateLogin; x.DateExit = person.DateExit; x.idOffice = person.idOffice; });
        }

        public void DeletePerson(Person person)
        {
            data.RemoveAll(x => x.ID == person.ID);
        }
    }
}
