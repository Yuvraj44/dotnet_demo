using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EmployeeCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCompany.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpPost("employees")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee EmployeeDetails)
        {
            try
            {
                await _context.EmployeeList.AddAsync(EmployeeDetails);
                await _context.SaveChangesAsync();
                return Created($"/api/employees/{EmployeeDetails.Id}", EmployeeDetails);
            }

            catch (SqlException ex)
            {
                return StatusCode(500, $"SQL Server issue (Check Connection String): {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("employees")]
        public async Task<IActionResult> ViewAll()
        {
            try
            {
                var emps = await _context.EmployeeList.ToListAsync();
                return Ok(emps);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"SQL Server issue (Check Connection String): {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("employees/{id}")]
        public async Task<IActionResult> View(int id)
        {
            try
            {
                var emp = await _context.EmployeeList.FindAsync(id);
                return emp == null ? NotFound($"Task with ID {id} not found.") : Ok(emp);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"SQL Server issue (Check Connection String): {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpPut("employees/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee updatedEmp)
        {
            try
            {
                var emp = await _context.EmployeeList.FindAsync(id);
                if (emp == null)
                    return NotFound($"Task with ID {id} not found.");

                emp.FirstName = updatedEmp.FirstName;
                emp.LastName = updatedEmp.LastName;
                emp.Email = updatedEmp.Email;
                emp.PhoneNumber = updatedEmp.PhoneNumber;
                emp.HireDate = updatedEmp.HireDate;
                emp.DepartmentId = updatedEmp.DepartmentId;
                emp.Salary = updatedEmp.Salary;

                await _context.SaveChangesAsync();
                return Ok(emp);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"SQL Server issue (Check Connection String): {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("employee/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var emp = await _context.EmployeeList.FindAsync(id);
                if (emp == null)
                    return NotFound($"Task with ID {id} not found.");

                _context.EmployeeList.Remove(emp);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"SQL Server issue (Check Connection String): {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentials user)
        {
            var existingUser = await _context.UserCredentialsList
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
                return Unauthorized(new { success = false, message = "Invalid credentials" });

            return Ok(new { success = true, role = existingUser.IsAdmin ? "admin" : "user" });
        }

    }
}
