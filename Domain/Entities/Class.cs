using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Class:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
