using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Entites
{
    public class Person:EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkFinishDate { get; set; }
        public int Gender { get; set; }
        public string Employeecode { get; set; }
        public long DepartmentId { get; set; }
    }
}
