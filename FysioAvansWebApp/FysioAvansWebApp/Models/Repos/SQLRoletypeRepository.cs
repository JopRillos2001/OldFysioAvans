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
    public class SQLRoletypeRepository : IRoletypeRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;

        public SQLRoletypeRepository(AuthDbFysioAvansWebAppContext db) {
            _db = db;
        }

        public void Create(Roletype roletype)
        {
            _db.Roletypes.Add(roletype);
        }

        public void Delete(int Id)
        {
            Roletype roletype = _db.Roletypes.Find(Id);
            _db.Roletypes.Remove(roletype);
        }

        public IEnumerable<Roletype> GetAll()
        {
            return _db.Roletypes.ToList();
        }

        public Roletype GetOne(int Id)
        {
            return _db.Roletypes.Find(Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Roletype roletype)
        {
            _db.Entry(roletype).State = EntityState.Modified;
        }
    }
}
