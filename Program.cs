#region Crud_Oprs
using CRUDOprs.Data;
using CRUDOprs.DataModel;
using Microsoft.EntityFrameworkCore;

OrganizationDbContext db = new OrganizationDbContext();
#region Non-Generic
//Insert
db.Departments.Add(new Department() { Did = 7000, DName = "SKC", Description = "Sandeep Kumar Chourasia" });
db.SaveChanges();

//Delete
Employee? E = db.Employees.Find(73);
if (E != null)
{
    db.Employees.Remove(E);
    db.SaveChanges();
}
else
{
    Console.WriteLine("Record Not Found!");
}

//Update
Employee? E1 = db.Employees.Find(72);
if (E1 != null)
{
    E1.Salary = 80000;
    E1.Did = 7000;

    db.Employees.Update(E1);
    db.SaveChanges();
}
else
{
    Console.WriteLine("Record Not Found!");
}
#endregion
#region Generic
//Insert
db.Add<Department>(new Department() { Did = 7001, DName = "PT", Description = "Prince Thakur" });
db.SaveChanges();

//Delete
Employee? E2 = db.Find<Employee>(70);
if (E2 != null)
{
    db.Remove<Employee>(E2);
    db.SaveChanges();
}
else
{
    Console.WriteLine("Record Not Found!");
}

//Update
Employee? E3 = db.Find<Employee>(72);
if (E != null)
{
    E3.Salary = 80000;
    E3.Did = 7000;

    db.Update<Employee>(E3);
    db.SaveChanges();
}
else
{
    Console.WriteLine("Record Not Found!");
}
#endregion
#region Select
var emps = db.Employees.ToList();
Console.WriteLine("All Employees");
foreach (var e in emps)
{
    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
}

Employee? e1 = db.Employees.Where(x => x.EName == "Ravi").FirstOrDefault();

if (e1 != null)
{
    Console.WriteLine($"Eid:{e1.Eid} Name:{e1.EName} Salary:{e1.Salary} DeptId:{e1.Did}");
}

Employee? e2 = db.Employees.Where(x => x.EName == "Austin Rush").SingleOrDefault();

if (e2 != null)
{
    Console.WriteLine($"Eid:{e2.Eid} Name:{e2.EName} Salary:{e2.Salary} DeptId:{e2.Did}");
}

List<Employee> emps2 = db.Employees.Take(10).ToList();
Console.WriteLine("Top 10 Employees");
foreach (var e in emps2)
{
    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
}
var emps1 = db.Employees.ToList();

//eager Loading
var emps3 = db.Employees.Include(x => x.Department).ToList();
Console.WriteLine("All Employees");
foreach (var e in emps3)
{
    string d = (e.Department != null) ? e.Department.DName : "Department Has Not Been Allocated Yet";
    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}" +
        $" DName:{d}");
}

var emps4 = db.Employees.ToList();
Console.WriteLine("All Employees");
foreach (var e in emps4)
{
    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
}
#endregion

#endregion
