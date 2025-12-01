using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDOperations.Migrations
{
    /// <inheritdoc />
    public partial class All_Sps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql_sp1 = @"Create Proc GetEmployeesByDid(@did as int)
                            as
                            SELECT  Employee.Eid, Employee.EName, Employee.Gender, Department.DName
                            FROM    Employee INNER JOIN
                                    Department ON Employee.Did = Department.Did
                            Where Employee.Did=@did";
            migrationBuilder.Sql(sql_sp1);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql_sp1 = @"drop Proc GetEmployeesByDid";
            migrationBuilder.Sql(sql_sp1);
        }
    }
}
