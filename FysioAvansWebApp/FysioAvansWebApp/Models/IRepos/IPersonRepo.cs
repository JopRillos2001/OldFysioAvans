using FysioAvansWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IPersonRepo
    {
        Person GetOne(int Id);
        IEnumerable<Person> GetAll();
        void Create(Person person);
        void Update(Person person);
        void Delete(int Id);
        void Save();
    }
}
