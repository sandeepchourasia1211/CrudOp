//#region Crud_Oprs
//using CRUDOperations.Data;
//using CRUDOperations.DataModel;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//OrganizationDbContext db = new OrganizationDbContext();
//#region Non-Generic
////Insert
////db.Departments.Add(new Department() { Did = 7000, DName = "SKC", Description = "Sandeep Kumar Chourasia" });
////db.SaveChanges();

////Delete
//Employee? E = db.Employees.Find(73);
//if (E != null)
//{
//    db.Employees.Remove(E);
//    db.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Record Not Found!");
//}

////Update
//Employee? E1 = db.Employees.Find(72);
//if (E1 != null)
//{
//    E1.Salary = 80000;
//    E1.Did = 7000;

//    db.Employees.Update(E1);
//    db.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Record Not Found!");
//}
//#endregion
//#region Generic
////Insert
////db.Add<Department>(new Department() { Did = 7001, DName = "PT", Description = "Prince Thakur" });
////db.SaveChanges();

////Delete
//Employee? E2 = db.Find<Employee>(70);
//if (E2 != null)
//{
//    db.Remove<Employee>(E2);
//    db.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Record Not Found!");
//}

////Update
//Employee? E3 = db.Find<Employee>(72);
//if (E != null)
//{
//    E3.Salary = 80000;
//    E3.Did = 7000;

//    db.Update<Employee>(E3);
//    db.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Record Not Found!");
//}
//#endregion
//#region Select
//var emps = db.Employees.ToList();
//Console.WriteLine("All Employees");
//foreach (var e in emps)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}

//Employee? e1 = db.Employees.Where(x => x.EName == "Ravi").FirstOrDefault();

//if (e1 != null)
//{
//    Console.WriteLine($"Eid:{e1.Eid} Name:{e1.EName} Salary:{e1.Salary} DeptId:{e1.Did}");
//}

//Employee? e2 = db.Employees.Where(x => x.EName == "Austin Rush").SingleOrDefault();

//if (e2 != null)
//{
//    Console.WriteLine($"Eid:{e2.Eid} Name:{e2.EName} Salary:{e2.Salary} DeptId:{e2.Did}");
//}

//List<Employee> emps2 = db.Employees.Take(10).ToList();
//Console.WriteLine("Top 10 Employees");
//foreach (var e in emps2)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}
//var emps1 = db.Employees.ToList();

////eager Loading
//var emps3 = db.Employees.Include(x => x.Department).ToList();
//Console.WriteLine("All Employees");
//foreach (var e in emps3)
//{
//    string d = (e.Department != null) ? e.Department.DName : "Department Has Not Been Allocated Yet";
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}" +
//        $" DName:{d}");
//}

//var emps4 = db.Employees.ToList();
//Console.WriteLine("All Employees");
//foreach (var e in emps4)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}
//#endregion

//#endregion

#region  Iterator Design Pattern And Loading


//#region Immediate Mode Vs Deferred Mode - IList Vs IEnumerable Vs IQueryable - Iterator Design Pattern


//OrganizationDbContext db = new OrganizationDbContext();

////IQueryable<Employee> employees = db.Employees; // iterator design Pattern and differd Mode of query execution
//IEnumerable<Employee> employees = db.Employees.ToList(); // iterator design Pattern and Immediate Mode of query execution

////employees.Add(new Employee() { EName = "Test", Gender = "M" });
////employees.RemoveAt(1);

//Console.WriteLine("All Employees");
//foreach (var e in employees)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}

//Console.WriteLine("All Male Employees");
//foreach (var e in employees.Where(x => x.Gender == "M"))
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}

////Immediate Mode
//var E = db.Employees.Where(x => x.Eid == 45).FirstOrDefault();
//Console.WriteLine(E.EName);

////Deferred Mode
//var E1 = db.Employees.Where(x => x.Eid == 45);
//Console.WriteLine(E1.FirstOrDefault().EName); 
//#endregion

//#region Eager Loading (Include(),ThenInclude()) - Explicit Loading for multiple directly and indirectly related entities - LazyLoading - Disable Lazyloading At Query Level

////OrganizationDbContext db = new OrganizationDbContext();
////db.ChangeTracker.LazyLoadingEnabled = false;
//List<Employee> employees1 = db.Employees.Include(x => x.Department).ToList();//Eager Loading
//Console.WriteLine("All Employees");
//foreach (var e in employees1)
//{
//    //Explicit Loading
//    //db.Entry(e).Reference(x => x.Department).Load();
//    string d = (e.Department != null) ? e.Department.DName : "Department Has Not Been Allocated Yet";
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did} DName:{d}");
//}


////Eager Loading for multiple directly related entities
//IEnumerable<StudentCourse> studentCourses = db.StudentCourses.Include(x => x.Student)
//                                                             .Include(x => x.Course);


////Eager Loading for multiple indirectly related entities
//IEnumerable<Task> tasks = db.Tasks.Include(x => x.Module)
//                                        .ThenInclude(x => x.Project).ToList();


////Explicit Loading for multiple directly related entities
//IEnumerable<StudentCourse> studentCourses1 = db.StudentCourses.ToList();
//foreach (var sc in studentCourses1)
//{
//    db.Entry(sc).Reference(x => x.Course).Load();
//    db.Entry(sc).Reference(x => x.Student).Load();
//    Console.WriteLine($"Sid:{sc.Sid} SName:{sc.Student.Name} CourseName:{sc.Course.CName}");
//}

////Explicit Loading for multiple indirectly related entities
//IEnumerable<Task> tasks2 = db.Tasks;
//foreach (var t in tasks2)
//{
//    db.Entry(t).Reference(x => x.Module).Load();
//    db.Entry(t).Reference(x => x.Module.Project).Load();
//}

//IEnumerable<Department> departments = db.Departments.Include(x => x.Employees).ToList();
//foreach (var d in departments)
//{
//    Console.WriteLine($"Did:{d.Did} DName:{d.DName}");
//    foreach (var e in d.Employees)
//    {
//        Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did} DName:{d}");
//    }
//}

//IEnumerable<Department> departments1 = db.Departments.ToList();
//foreach (var d in departments1)
//{
//    Console.WriteLine("---------------------------------------------------------");
//    Console.WriteLine($"Did:{d.Did} DName:{d.DName}");

//    db.Entry(d).Collection(x => x.Employees).Load();
//    foreach (var e in d.Employees)
//    {
//        string deptName = (e.Department != null) ? e.Department.DName : "Department Has Not Been Allocated Yet";
//        Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did} DName:{deptName}");
//    }
//}

//IEnumerable<Department> departments2 = db.Departments.ToList();
//foreach (var d in departments2)
//{
//    Console.WriteLine("---------------------------------------------------------");
//    Console.WriteLine($"Did:{d.Did} DName:{d.DName}");
//    foreach (var e in d.Employees)
//    {
//        string deptName = (e.Department != null) ? e.Department.DName : "Department Has Not Been Allocated Yet";
//        Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did} DName:{deptName}");
//    }
//}


//[Table("Student")]
//public class Student
//{
//    [Key]
//    public int Sid { get; set; }
//    public string? Name { get; set; }
//    IEnumerable<StudentCourse> StudentCourses { get; set; }
//}

//[Table("Course")]
//public class Course
//{
//    [Key]
//    public int Cid { get; set; }
//    public string? CName { get; set; }
//    IEnumerable<StudentCourse> StudentCourses { get; set; }
//}

//[Table("StudentCourse")]
//public class StudentCourse
//{
//    [Key]
//    public int SCId { get; set; }

//    public int Sid { get; set; }
//    public Student? Student { get; set; }

//    public int Cid { get; set; }
//    public Course? Course { get; set; }
//}



//[Table("Project")]
//public class Project
//{
//    [Key]
//    public int Pid { get; set; }
//    public string ProjectName { get; set; }

//    public virtual IEnumerable<Module> Modules { get; set; }
//}

//[Table("Module")]
//public class Module
//{
//    [Key]
//    public int Mid { get; set; }
//    public string ModuleName { get; set; }

//    [ForeignKey("Project")]
//    public int Pid { get; set; }
//    public virtual Project Project { get; set; }

//    public virtual IEnumerable<Task> Tasks { get; set; }
//}

//[Table("Task")]
//public class Task
//{
//    [Key]
//    public int Tid { get; set; }
//    public string TaskName { get; set; }

//    [ForeignKey("Module")]
//    public int Mid { get; set; }
//    public virtual Module Module { get; set; }

//}




////#endregion
#endregion



using CRUDOperations.Data;
using CRUDOperations.Data;
using CRUDOperations.DataModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//OrganizationDbContext db = new OrganizationDbContext();

#region Manual Transactions
//var trans = db.Database.BeginTransaction();
//try
//{
//    db.Departments.Add(new Department() { Did = 5006, DName = "Test", Description = "Testing" });
//    db.SaveChanges();
//    db.Departments.Add(new Department() { Did = 5007, DName = "Test", Description = "Testing" });
//    db.SaveChanges();
//    db.Departments.Add(new Department() { Did = 5008, DName = "Test testTestTest", Description = "Testing" });
//    db.SaveChanges();

//    trans.Commit();
//}
//catch (Exception E)
//{
//    string? Msg = (E.InnerException != null) ? (E.InnerException.Message) : E.Message;
//    Console.WriteLine(Msg);
//    trans.Rollback();
//}
#endregion
#region Manual Transactions 2 with Scope_Identity() Concept
//var trans = db.Database.BeginTransaction();
//try
//{
//    Employee Emp = new Employee()
//    {
//        EName = "MTT",
//        Gender = "Male",
//        Email = "mtt@gmail.com",
//        DOB = new DateTime(1984, 8, 11),
//        DOJ = DateTime.Today,
//        Salary = 89000,
//        IsActive = true,
//        Did = 5000
//    };
//    db.Employees.Add(Emp);
//    db.SaveChanges();
//    Console.WriteLine(Emp.Eid);

//    trans.Commit();
//}
//catch (Exception E)
//{
//    string? Msg = (E.InnerException != null) ? (E.InnerException.Message) : E.Message;
//    Console.WriteLine(Msg);
//    trans.Rollback();
//}
#endregion
#region Raw SQL
//IEnumerable<Employee> emps = db.Employees.FromSql($"Select * from Employee").ToList();
//foreach (var e in emps)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}

//Get all employees from Dept 1004
//int did = 1004;
//IEnumerable<Employee> emps = db.Employees.FromSql($"Select * from Employee Where Did={did}").ToList();
//foreach (var e in emps)
//{
//    Console.WriteLine($"Eid:{e.Eid} Name:{e.EName} Salary:{e.Salary} DeptId:{e.Did}");
//}


//Delete Employee with ID = 74

//int numOfRecords = db.Database.ExecuteSql($"Delete from Employee Where Eid=72");
//Console.WriteLine(  $"{numOfRecords}(s) Deleted");


//var EmpDetails = db.EmpDetails.FromSql($"SELECT Employee.Eid, Employee.EName, Department.DName FROM Department INNER JOIN Employee ON Department.Did = Employee.Did").ToList();
//Console.WriteLine();


//[NotMapped]
//Add this Attribute while generating Migration for Custom Entities
//public class EmpDetail
//{
//    [Key]
//    public int Eid { get; set; }
//    public string EName { get; set; }
//    public string DName { get; set; }
//}

#endregion

//Console.WriteLine();
#region Exec Stored Procedures
//OrganizationDbContext db = new OrganizationDbContext();
//Console.WriteLine();
//var EmpDetails = db.EmpDetailsForSp.FromSql($"exec GetEmployeesByDid 1004").ToList();
//Console.WriteLine();


//[NotMapped] Add this Attribute while generating Migration for Custom Entities
//public class EmpDetailForSp
//{
//    [Key]
//    public int Eid { get; set; }
//    public string EName { get; set; }
//    public string Gender { get; set; }
//    public string DName { get; set; }
//}

#endregion
