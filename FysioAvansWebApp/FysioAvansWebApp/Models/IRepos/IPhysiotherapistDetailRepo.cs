using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IPhysiotherapistDetailRepo
    {
        IEnumerable<PhysiotherapistDetailsViewModel> GetAll();
        PhysiotherapistDetailsViewModel GetOne(int id);
    }
}
