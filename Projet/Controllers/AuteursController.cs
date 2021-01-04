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
    public class AuteursController : ControllerBase
    {
        private readonly IAuteurRepository auteurRepository;

        public AuteursController(IAuteurRepository auteurRepository)
        {
            this.auteurRepository = auteurRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAuteurs()
        {
            try
            {
                return Ok(await auteurRepository.GetAuteurs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Auteur>> GetAuteur(int id)
        {
            try
            {
                var result = await auteurRepository.GetAuteur(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Auteur>> CreateAuteur([FromBody]Auteur auteur)
        {
            try
            {
                if (auteur == null)
                    return BadRequest();

                var createdAuteur = await auteurRepository.AddAuteur(auteur);

                return CreatedAtAction(nameof(GetAuteur),
                    new { id = createdAuteur.AuteurId }, createdAuteur);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new auteur record");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Auteur>> UpdateAuteur( Auteur auteur)
        {
            try
            {
              

                var auteurToUpdate = await auteurRepository.GetAuteur(auteur.AuteurId);

                if (auteurToUpdate == null)
                    return NotFound($"Auteur with Id = {auteur.AuteurId} not found");

                return await auteurRepository.UpdateAuteur(auteur);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Auteur>> DeleteAuteur(int id)
        {
            try
            {
                var auteurToDelete = await auteurRepository.GetAuteur(id);

                if (auteurToDelete == null)
                {
                    return NotFound($"Auteur with Id = {id} not found");
                }

                return await auteurRepository.DeleteAuteur(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
