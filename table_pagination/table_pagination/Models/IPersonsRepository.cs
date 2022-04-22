using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace table_pagination.Models
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
                new Person() { ID = 1, FirstName = "Alex", LastName = "Mishustin", DateOfBirth = DateTime.Parse("01.02.1978"), Country="Russia", DrivingExperience = 10 },
                new Person() { ID = 2, FirstName = "Irina", LastName = "Nabiulina", DateOfBirth = DateTime.Parse("02.02.1987"), Country="Ukraine", DrivingExperience = 6 },
                new Person() { ID = 3, FirstName = "Ivan", LastName = "Chub", DateOfBirth =  DateTime.Parse("05.03.1986"), Country="Latvia", DrivingExperience = 15 },
                new Person() { ID = 4, FirstName = "Vlad", LastName = "Petrov", DateOfBirth = DateTime.Parse("12.02.1995"), Country="Russia", DrivingExperience = 5 },
                new Person() { ID = 5, FirstName = "Maxim", LastName ="Smirnoff", DateOfBirth = DateTime.Parse("01.01.2001"), Country="Germany", DrivingExperience = 3  },
                new Person() { ID = 6, FirstName = "Basil", LastName ="Petrov", DateOfBirth = DateTime.Parse("07.12.1976"), Country="Russia", DrivingExperience = 13  },
                new Person() { ID = 7, FirstName = "Peter", LastName ="Ivanov", DateOfBirth = DateTime.Parse("15.11.1980"), Country="Germany", DrivingExperience = 6  },
                new Person() { ID = 8, FirstName = "Boris", LastName ="Eremin", DateOfBirth = DateTime.Parse("06.07.1956"), Country="Ukraine", DrivingExperience = 8  },
                new Person() { ID = 9, FirstName = "Elena", LastName ="Novikova", DateOfBirth = DateTime.Parse("12.08.1967"), Country="France", DrivingExperience = 12  },
                new Person() { ID = 10, FirstName = "Tatiana", LastName ="Korotkova", DateOfBirth = DateTime.Parse("03.08.1986"), Country="Greece", DrivingExperience = 11  },
                new Person() { ID = 11, FirstName = "Vladimir", LastName ="Kozlov", DateOfBirth = DateTime.Parse("14.09.1978"), Country="Germany", DrivingExperience = 20  },
                new Person() { ID = 11, FirstName = "Andrey", LastName ="Shurai", DateOfBirth = DateTime.Parse("15.05.1989"), Country="Ukraine", DrivingExperience = 1  }
            };
        }

        List<Person> IPersonsRepository.Persons => data;

        public void AddPerson(Person person)
        {   
            data.Add(person);
        }

        public void EditPerson(Person person)
        {
            data.Where(p => p.ID == person.ID).ToList().ForEach(x => { x.FirstName = person.FirstName; x.LastName = person.LastName; x.DateOfBirth = person.DateOfBirth; x.Country = person.Country; x.DrivingExperience = person.DrivingExperience; });
        }

        public void DeletePerson(Person person)
        {
            data.RemoveAll(x => x.ID == person.ID);
        }
    }
}
