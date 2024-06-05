using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.staffs
{
    public class Staff
    {
        public int Id { get; set; }
        public string FastName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string City {  get; set; }
        public string State {  get; set; }
        public string Country { get; set; }

    }
}
