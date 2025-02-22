namespace EmployeeCompany.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int departmentId, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            HireDate = hireDate;
            DepartmentId = departmentId;
            Salary = salary;
        }
    }
}

