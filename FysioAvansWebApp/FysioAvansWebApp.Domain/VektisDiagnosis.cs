using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class VektisDiagnosis
    {
        public string Id { get; set; }
        public string BodyLocalization { get; set; }
        public string Pathology { get; set; }
        public string CombinedField { get { return $"{this.Id} - {this.BodyLocalization} - {this.Pathology}"; } }

    }
}
