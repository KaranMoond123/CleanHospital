using Application.Comman.Mappings;
using Domain.Entities.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Loopup
{
    public class LookupDto:IMapFrom<Country>
    {
        public int Id { get; set; }
        public string Name {  get; set; }
    }
}
