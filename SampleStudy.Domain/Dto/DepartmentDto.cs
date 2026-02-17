using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Dto
{
    public class DepartmentDto
    {
        public long Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentCode { get; set; }
        public int IsActive { get; set; }
    }
}
