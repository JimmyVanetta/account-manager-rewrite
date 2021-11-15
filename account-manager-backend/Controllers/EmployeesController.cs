using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using account_manager_backend.Data;
using account_manager_backend.Models;

namespace account_manager_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly account_manager_backendContext _context;

        public EmployeesController(account_manager_backendContext context)
        {
            _context = context;
        }
        // ALL EMPLOYEES
        // GET: /GetEmployees
        [HttpGet("/GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByAccount(int accountId)
        {
            var employees = await _context.Employee.Where(e => e.AccountId == accountId && e.IsObsolete != true).ToListAsync();

            return Ok(employees);
        }
        // SINGLE EMPLOYEE
        // GET: /GetEmployee?EmployeeId={ employeeId }&AccountId={ AccountId }
        [HttpGet("/GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployeeByAccountId(int employeeId, int accountId)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employeeId & e.AccountId == accountId && e.IsObsolete != true);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: /EditEmployee?EmployeeId={ employeeId }&AccountId={ accountId } + Employee JSON Object
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/EditEmployee")]
        public async Task<IActionResult> EditEmployee(int employeeId, int accountId, Employee employee)
        {
            if (employeeId != employee.EmployeeId & accountId != employee.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EmployeeExists(employeeId, accountId))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return Ok(employee);
        }

        // POST: /Employees + Employee JSON Object
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeByAccountId", new { employeeId = employee.EmployeeId, accountId = employee.AccountId }, employee);
        }

        //ONLY FOR ADMIN USE!!
        // DELETE: /DeleteEmployees?EmployeeId={ employeeId }&AccountId={ accountId }
        [HttpDelete("/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int employeeId, int accountId)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employeeId & e.AccountId == accountId);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }
        // HELPER METHODS
        private bool EmployeeExists(int employeeId, int accountId)
        {
            return _context.Employee.Any(e => e.EmployeeId == employeeId && e.AccountId == accountId);
        }
    }
}
