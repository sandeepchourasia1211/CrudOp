using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOprs.DataModel
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string? EName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int? Did { get; set; }
        public Department? Department { get; set; }

        public int? ProjectId { get; set; }
        public int? ManagerId { get; set; }
    }
}
