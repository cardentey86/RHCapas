using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;
using Infrastructure.DataContext;
using Services.DTO;
using Services.ServicesP.ServicesM;
using Services.Services.Interfaces;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Personas")]
    public class PersonasController : Controller
    {

        private IPersonaService _personaServices;

        public PersonasController(IPersonaService personaServices)
        {
            _personaServices = personaServices;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<IEnumerable<PersonaDTO>> GetPersona()
        {
            return await _personaServices.GetAllPersons();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          //  var persona = await _personaServices.Persona.SingleOrDefaultAsync(m => m.Id == id);

            //if (persona == null)
            //{
            //    return NotFound();
            //}

            return Ok("");
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona([FromRoute] int id, [FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

          //  _context.Entry(persona).State = EntityState.Modified;

            try
            {
              //  await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> PostPersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          //  _context.Persona.Add(persona);
          //  await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          //  var persona = await _context.Persona.SingleOrDefaultAsync(m => m.Id == id);
            //if (persona == null)
            //{
            //    return NotFound();
            //}

         //   _context.Persona.Remove(persona);
         //   await _context.SaveChangesAsync();

            return Ok("");
        }

        private bool PersonaExists(int id)
        {
            return true;
        }
    }
}