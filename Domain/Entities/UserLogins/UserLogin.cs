using Domain.Comman;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserLogins
{
    public class UserLogin:BaseAuditableEntity
    {
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public User User { get; set; }
        public string Password {  get; set; }
        public string Code {  get; set; }
        

    }
}
