using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dcouments
{
    public class Dcoument:BaseAuditableEntity
    {
        public string Name {  get; set; }
        public string Url {  get; set; }
    }
}
