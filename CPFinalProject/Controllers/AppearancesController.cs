using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CPFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppearancesController : ControllerBase
    {
        private readonly ILogger<AppearancesController> _logger;
        private readonly IAppearanceContextDAO _context;

        public AppearancesController(ILogger<AppearancesController> logger, IAppearanceContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllAppearances());
        }

        [HttpGet("id")]
        public IActionResult GetById(int? id)
        {
            if (id == null || id == 0)
            {
                var firstFive = _context.GetAllAppearances().Take(5);
                return Ok(firstFive);
            }
            
            else
            {
                var appearance = _context.GetAppearanceById(id);
                if (appearance == null)
                    return NotFound(id);

                return Ok(appearance);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveAppearanceById(id);

            if (result == null)
                return NotFound(id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Appearance appearance)
        {
            var result = _context.UpdateAppearance(appearance);

            if (result == null)
                return NotFound(appearance.AppearanceId);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Appearance appearance)
        {
            var result = _context.AddAppearance(appearance);

            if (result == null)
                return StatusCode(500, "Appearance already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}