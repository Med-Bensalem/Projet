using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private readonly ILivreRepository livreRepository;

        public LivresController(ILivreRepository livreRepository)
        {
            this.livreRepository = livreRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLivres()
        {
            try
            {
                return Ok(await livreRepository.GetLivres());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Livre>> GetLivre(int id)
        {
            try
            {
                var result = await livreRepository.GetLivre(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public async Task<ActionResult<Livre>> CreateLivre([FromBody] Livre livre)
        {
            try
            {
                if (livre == null)
                    return BadRequest();

                var createdLivre = await livreRepository.AddLivre(livre);

                return CreatedAtAction(nameof(GetLivre),
                    new { id = createdLivre.EditeurId }, createdLivre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new editeur record");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Livre>> UpdateLivre(Livre livre)
        {
            try
            {
               

                var livreToUpdate = await livreRepository.GetLivre(livre.LivreId);

                if (livreToUpdate == null)
                    return NotFound($"Livre with Id = {livre.LivreId} not found");

                return await livreRepository.UpdateLivre(livre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Livre>> DeleteLivre(int id)
        {
            try
            {
                var livreToDelete = await livreRepository.GetLivre(id);

                if (livreToDelete == null)
                {
                    return NotFound($"Livre with Id = {id} not found");
                }

                return await livreRepository.DeleteLivre(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    
}
}
