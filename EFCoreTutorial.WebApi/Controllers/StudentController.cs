using EFCoreTutorial.Data.Context;
using EFCoreTutorial.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{

		private readonly ApplicationDbContext _context;

		public StudentController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var students = await _context.Students.ToListAsync();

			return Ok(students);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Student student) 
		{
			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var student = await _context.Students.FindAsync(id);

            #pragma warning disable CS8604
				_context.Students.Remove(student);
            #pragma warning restore CS8604

			await _context.SaveChangesAsync();

			return Ok();
		}		
		
		[HttpPut]
		public async Task<IActionResult> Update(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}
