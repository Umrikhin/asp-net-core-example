using crud_blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_blazor.Infractructure
{
    public interface IPerson
    {
        void Add(Person person);
        void Edit(Person person);
        void Del(Person person);
        List<Person> Get(string exist);
    }
}
