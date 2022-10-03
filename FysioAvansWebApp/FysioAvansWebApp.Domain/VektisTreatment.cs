using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class VektisTreatment
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string NotesMandatory { get; set; }
        public string CombinedField { get { return $"{this.Id} - {this.Description}"; } }
    }
}
