using BlogAppiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employe = c.Employees.Find(id);
            if (employe == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employe);
            }
        }

        [HttpDelete("id")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employe = c.Employees.Find(id);
            if (employe == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employe);
                c.SaveChanges();
                return Ok();
            }

        }
        [HttpPut]
        public IActionResult EmployeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
