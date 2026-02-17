using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Dto
{
    public class ComminicationDto
    {
        public long Id { get; set; }
        public string Mail { get; set; }
        public string MobilPhone { get; set; }
        public string LocalPhone { get; set; }
        public int IsActive { get; set; }   
    }
}
