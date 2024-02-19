using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		// Apiler de Httpget - post vs söylenmek zorunda


		[HttpGet]
		public IActionResult EmployeeList()
		{
			using var c = new Context();
			var employees = c.Employees.ToList();
			return Ok(employees);
		}

		[HttpPost]
		public IActionResult AddEmployee(Employee e)
		{
			using var c = new Context();
			c.Add(e);
			c.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetEmployeById(int id)
		{
			using var c = new Context();	
			var value = c.Employees.Find(id);
			if (value == null)
			{
				return NotFound();

			}
			return Ok(value);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteEmploye(int id)
		{
			var c = new Context();
			var value = c.Employees.Find(id);
			if (value == null)
			{
				return NotFound("Kullanıcı Yok");
			}
			c.Employees.Remove(value);
			c.SaveChanges();
			return Ok("Employee Başarılı şekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateEmplotee(Employee employee)
		{
			var c = new Context();
			var value = c.Employees.Find(employee.ID);
			if (value == null)
			{
				return NotFound();
			}
			value.Name= employee.Name;
			c.Employees.Update(value);
			c.SaveChanges();
			return Ok("Employee başarılı şekilde güncellendi");
		}
	}
}
