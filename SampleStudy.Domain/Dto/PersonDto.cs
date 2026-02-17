using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SampleStudy.Domain.Enums;

namespace SampleStudy.Domain.Dto
{
    public class PersonDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        
        public long DepartmentId { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkFinishDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentCode { get; set;}
        public bool IsActive { get; set; }   
        public DepartmentDto Department { get; set; }
        public List<ComminicationDto> Comminications { get; set; }


    }
}
