using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Entites
{
    public class Comminication:EntityBase
    {
        public string PersonId {get; set; }
        public string Mail { get; set; }
        public string MobilPhone { get; set; }
        public string LocalPhone { get; set; }
    }
}
