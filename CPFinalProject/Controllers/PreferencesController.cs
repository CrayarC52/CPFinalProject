using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CPFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreferencesController : ControllerBase
    {
        private readonly ILogger<PreferencesController> _logger;
        private readonly IPreferenceContextDAO _context;

        public PreferencesController(ILogger<PreferencesController> logger, IPreferenceContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllPreferences());
        }

        [HttpGet("id")]
        public IActionResult GetById(int? id)
        {
            if (id == null || id == 0)
            {
                var firstFive = _context.GetAllPreferences().Take(5);
                return Ok(firstFive);
            }
            
            else
            {
                var preference = _context.GetPreferenceById(id);
                if (preference == null)
                    return NotFound(id);

                return Ok(preference);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemovePreferenceById(id);

            if (result == null)
                return NotFound(id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Preference preference)
        {
            var result = _context.UpdatePreference(preference);

            if (result == null)
                return NotFound(preference.PreferenceId);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Preference preference)
        {
            var result = _context.AddPreference(preference);

            if (result == null)
                return StatusCode(500, "Preference already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}