using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Countries
{
    public class Country:BaseAuditableEntity
    {
        public string Name {  get; set; }
    }
}
