using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IAvailabilityDetailRepo
    {
        AvailabilityDetailsViewModel GetOne(int Id);
        IEnumerable<AvailabilityDetailsViewModel> GetAll();
        IEnumerable<AvailabilityDetailsViewModel> GetAllPlus();
        void Create(AvailabilityDetailsViewModel AvailabilityDetailsViewModel);
        void Update(AvailabilityDetailsViewModel AvailabilityDetailsViewModel);
        void Delete(int id);
    }
}
