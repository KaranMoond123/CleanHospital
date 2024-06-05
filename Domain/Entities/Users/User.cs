using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class User:BaseAuditableEntity
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public long MobileNo {  get; set; }
    }
}
