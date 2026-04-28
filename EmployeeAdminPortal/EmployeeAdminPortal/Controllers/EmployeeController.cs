using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Reposotiry;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var ListOfEmp = await _employeeService.GetAll();
            return Ok(ListOfEmp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                var emp = await _employeeService.GetById(id);
                return Ok(emp);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> AddNewEmployee([FromBody]Employee employee)
        {
            var NewEmp = await _employeeService.AddEmployee(employee);
            return Ok($"EmpName: {NewEmp.Name}\n Salary: {NewEmp.Salary}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee emp)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeData(id, emp);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                await _employeeService.DeleteEmployeeData(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
