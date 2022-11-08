using BethanyShopAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BethanyShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        { };

        private readonly AppDbContext appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await appDbContext.Employees.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int cemployeeId)
        {
            var employee = await appDbContext.Employees.FindAsync(cemployeeId);
            if (employee == null) return BadRequest("Employee with that id was not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee( Employee employee)
        {
           appDbContext.Add(employee);
            await appDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee, int id)
        {
            var foundEmployee = await appDbContext.Employees.FindAsync(id);
            if (foundEmployee == null) return BadRequest("Employee not found");

          
                foundEmployee.CountryId = employee.CountryId;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.BirthDate = employee.BirthDate;
                foundEmployee.City = employee.City;
                foundEmployee.Email = employee.Email;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Gender = employee.Gender;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.Smoker = employee.Smoker;
                foundEmployee.Street = employee.Street;
                foundEmployee.Zip = employee.Zip;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.Comment = employee.Comment;
                foundEmployee.ExitDate = employee.ExitDate;
                foundEmployee.JoinedDate = employee.JoinedDate;


            await this.appDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int cemployeeId)
        {
            var employee = await appDbContext.Employees.FindAsync(cemployeeId);
            if (employee == null) return BadRequest("Employee with that id was not found");
            return Ok("Employee deleted successfully");
        }


    }
}
