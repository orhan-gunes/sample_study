using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStudy.Domain.Entites
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
        public int IsActive { get; set; }
    }
}
