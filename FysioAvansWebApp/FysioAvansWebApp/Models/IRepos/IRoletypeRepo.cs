using FysioAvansWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IRoletypeRepo
    {
        Roletype GetOne(int Id);
        IEnumerable<Roletype> GetAll();
        void Create(Roletype roletype);
        void Update(Roletype roletype);
        void Delete(int Id);
        void Save();
    }
}
