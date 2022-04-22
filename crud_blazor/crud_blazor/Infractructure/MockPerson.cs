using crud_blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_blazor.Infractructure
{
    public class MockPerson : IPerson
    {
        private List<Person> _people;

        public MockPerson(List<Person> person)
        {
            _people = person;
        }

        public MockPerson()
        {
            _people = new List<Person>()
            {
                new Person() { Id = 1, Famip = "Иванов", Namep="Андрей", Otchp="Алексеевич", Dr = DateTime.Parse("01.10.1978") },
                new Person() { Id = 2, Famip = "Петров", Namep="Олег", Otchp="Игоревич", Dr = DateTime.Parse("06.11.1967") },
                new Person() { Id = 3, Famip = "Смирнов", Namep="Сергей", Otchp="Константинович", Dr = DateTime.Parse("12.03.1987") },
                new Person() { Id = 4, Famip = "Филиппова", Namep="Анна", Otchp="Михайловна", Dr = DateTime.Parse("12.04.1992") },
            };
        }

        public void Add(Person person)
        {
            var new_id = _people.Count == 0 ? 1 : _people.Max(x => x.Id) + 1;
            person.Id = new_id;
            _people.Add(person);
        }

        public void Del(Person person)
        {
            _people.Remove(person);
        }

        public void Edit(Person person)
        {
            _people.Where(x => x.Id == person.Id).ToList().ForEach(s => { s.Famip = person.Famip; s.Namep = person.Namep; s.Otchp = person.Otchp; s.Dr = person.Dr; });
        }

        public List<Person> Get(string exist)
        {
            return _people;
        }
    }
}
