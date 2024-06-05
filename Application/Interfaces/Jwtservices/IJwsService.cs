using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Jwtservices
{
    public interface IJwsService
    {
        Task<string> GenrateJwt(int userId);
    }
}
