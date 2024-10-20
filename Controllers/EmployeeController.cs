using CRUD_Opertions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Opertions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var allEmployees = employeeContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetEmployee(int id) 
        {
            var getEmployeeById=employeeContext.Employees.Find(id);
            return Ok(getEmployeeById);

        }

        [HttpPost]
        public IActionResult saveEmployees(Employee employee)
        {
            var employeeEntity = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
            };
            employeeContext.Employees.Add(employeeEntity);
            employeeContext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpPut]
        [Route("/{id}")]
        public IActionResult UpdateEmployee(int id,  Employee employee) 
        {
            var updateEmployeeEntity = employeeContext.Employees.Find(id);

            updateEmployeeEntity.Name = employee.Name;
            updateEmployeeEntity.Email = employee.Email;
            updateEmployeeEntity.Phone = employee.Phone;
            employeeContext.SaveChanges();
            return Ok(updateEmployeeEntity);
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var deleteEmployee=employeeContext.Employees.Find(id);
            if (deleteEmployee == null)
            {
                return BadRequest("Id Not Found");
            }
            employeeContext.Remove(deleteEmployee);
            employeeContext.SaveChanges();
            return Ok("Data Deleted Successfully");
        }
    }
}
