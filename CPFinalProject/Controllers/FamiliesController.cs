using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CPFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private readonly ILogger<FamiliesController> _logger;
        private readonly IFamilyContextDAO _context;

        public FamiliesController(ILogger<FamiliesController> logger, IFamilyContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllFamilies());
        }

        [HttpGet("id")]
        public IActionResult GetById(int? id)
        {
            if (id == null || id == 0)
            {
                var firstFive = _context.GetAllFamilies().Take(5);
                return Ok(firstFive);
            }
            
            else
            {
                var family = _context.GetFamilyById(id);
                if (family == null)
                    return NotFound(id);

                return Ok(family);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveFamilyById(id);

            if (result == null)
                return NotFound(id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Family family)
        {
            var result = _context.UpdateFamily(family);

            if (result == null)
                return NotFound(family.FamilyId);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Family family)
        {
            var result = _context.AddFamily(family);

            if (result == null)
                return StatusCode(500, "Family already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}