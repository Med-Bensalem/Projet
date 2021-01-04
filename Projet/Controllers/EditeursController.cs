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
    public class EditeursController : ControllerBase
    {
        private readonly IEditeurRepository editeurRepository;

        public EditeursController(IEditeurRepository editeurRepository)
        {
            this.editeurRepository = editeurRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEditeurs()
        {
            try
            {
                return Ok(await editeurRepository.GetEditeurs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Editeur>> GetEditeur(int id)
        {
            try
            {
                var result = await editeurRepository.GetEditeur(id);

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
        public async Task<ActionResult<Editeur>> CreateEditeur([FromBody] Editeur editeur)
        {
            try
            {
                if (editeur == null)
                    return BadRequest();

                var createdEditeur = await editeurRepository.AddEditeur(editeur);

                return CreatedAtAction(nameof(GetEditeur),
                    new { id = createdEditeur.EditeurId }, createdEditeur);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new editeur record");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Editeur>> UpdateEditeur(Editeur editeur)
        {
            try
            {
                var editeurToUpdate = await editeurRepository.GetEditeur(editeur.EditeurId);

                if (editeurToUpdate == null)
                    return NotFound($"Editeur with Id = {editeur.EditeurId} not found");

                return await editeurRepository.UpdateEditeur(editeur);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Editeur>> DeleteEditeur(int id)
        {
            try
            {
                var editeurToDelete =  await editeurRepository.GetEditeur(id);

                if (editeurToDelete == null)
                {
                    return NotFound($"Editeur with Id = {id} not found");
                }

                return await editeurRepository.DeleteEditeur(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


    
}
}
