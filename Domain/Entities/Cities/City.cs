using Domain.Comman;
using Domain.Entities.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cities
{
    public class City:BaseAuditableEntity
    {
        public string Name {  get; set; }
        [ForeignKey("State")]
        public int StateID {  get; set; }
        public State State { get; set; }
    }
}
