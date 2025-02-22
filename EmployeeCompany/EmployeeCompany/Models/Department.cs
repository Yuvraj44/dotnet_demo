namespace EmployeeCompany.Models
{
    public class Department
    {
       public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }

        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }
    }
}
