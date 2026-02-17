using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Entites
{
    public class Department:EntityBase
    {
        public string DepartmentName { get; set; }
        public int DepartmentCode { get; set; }

    }   
}
