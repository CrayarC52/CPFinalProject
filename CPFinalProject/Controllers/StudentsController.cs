using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CPFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentContextDAO _context;

        public StudentsController(ILogger<StudentsController> logger, IStudentContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllStudents());
        }

        [HttpGet("id")]
        public IActionResult GetById(int? id)
        {
            if (id == null || id == 0)
            {
                var firstFive = _context.GetAllStudents().Take(5);
                return Ok(firstFive);
            }
            
            else
            {
                var student = _context.GetStudentById(id);
                if (student == null)
                    return NotFound(id);

                return Ok(student);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveStudentById(id);

            if (result == null)
                return NotFound(id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            var result = _context.UpdateStudent(student);

            if (result == null)
                return NotFound(student.Id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            var result = _context.AddStudent(student);

            if (result == null)
                return StatusCode(500, "Student already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}