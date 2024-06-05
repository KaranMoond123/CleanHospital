using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Students
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Marks { get; set; }
        public long MobileNo {  get; set; }
        public string Email {  get; set; }
    }
}
