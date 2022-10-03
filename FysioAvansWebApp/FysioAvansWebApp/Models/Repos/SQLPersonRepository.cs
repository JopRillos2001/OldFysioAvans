using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models.Repo
{
    public class SQLPersonRepository : IPersonRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;

        public SQLPersonRepository(AuthDbFysioAvansWebAppContext db) {
            _db = db;
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
        }

        public void Delete(int Id)
        {
            Person person = _db.Persons.Find(Id);
            _db.Persons.Remove(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public Person GetOne(int Id)
        {
            return _db.Persons.Find(Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
        }
    }
}
