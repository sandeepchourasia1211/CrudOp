using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations.DataModel;

[Table("Department")]
public class Department
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Did { get; set; }
    public string? DName { get; set; }
    public string? Description { get; set; }
    public virtual IEnumerable<Employee>? Employees { get; set; } //iterator design pattern
}
