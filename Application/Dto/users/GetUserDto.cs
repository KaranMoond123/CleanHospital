using Application.Comman.Mappings;
using AutoMapper;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.users
{
    public class GetUserDto:IMapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long MobileNo { get; set; }
    }
}
