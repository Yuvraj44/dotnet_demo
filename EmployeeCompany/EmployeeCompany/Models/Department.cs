using System.ComponentModel.DataAnnotations;

namespace EmployeeCompany.Models
{
    public class Department
    {
        [Key]
       public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required.")]
        public string DepartmentName { get; set; }

        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }
    }
}
