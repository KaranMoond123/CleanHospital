using Domain.Comman;
using Domain.Entities.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.States
{
    public class State:BaseAuditableEntity
    {
        public string Name {  get; set; }
        [ForeignKey("Country")]
        public int CountryId {  get; set; }
        public Country Country { get; set; }
    }
}
