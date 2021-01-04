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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepository categorieRepository;

        public CategoriesController(ICategorieRepository categorieRepository)
        {
            this.categorieRepository = categorieRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                return Ok(await categorieRepository.GetCategories());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
            try
            {
                var result = await categorieRepository.GetCategorie(id);

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
        public async Task<ActionResult<Categorie>> CreateCategorie([FromBody] Categorie categorie)
        {
            try
            {
                if (categorie == null)
                    return BadRequest();

                var createdCategorie = await categorieRepository.AddCategorie(categorie);

                return CreatedAtAction(nameof(GetCategorie),
                    new { id = createdCategorie.CategorieId }, createdCategorie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new categorie record");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Categorie>> UpdateCategorie(Categorie categorie)
        {
            try
            {
                

                var categorieToUpdate = await categorieRepository.GetCategorie(categorie.CategorieId);

                if (categorieToUpdate == null)
                    return NotFound($"Categorie with Id = {categorie.CategorieId} not found");

                return await categorieRepository.UpdateCategorie(categorie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categorie>> DeleteCategorie(int id)
        {
            try
            {
                var categorieToDelete = await categorieRepository.GetCategorie(id);

                if (categorieToDelete == null)
                {
                    return NotFound($"Categorie with Id = {id} not found");
                }

                return await categorieRepository.DeleteCategorie(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    
}
}
