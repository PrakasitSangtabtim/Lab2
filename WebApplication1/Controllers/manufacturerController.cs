using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Databases;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    //https://localhost:7203/api/manufacturer
    [Route("api/[controller]")]
    [ApiController]
    public class manufacturerController : ControllerBase
    {
        //Variable
        private readonly DataDbContext _dbContext;

        //Cotructure Method
        public manufacturerController(DataDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        //get push put delete
        //get
        [HttpGet]
        public async Task<ActionResult<List<manufacturers>>> getManufacturers()
        {
            var manufacturers = await _dbContext.manufacturers.ToListAsync();

            if (manufacturers.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(manufacturers);
        }

        //get by id
        [HttpGet("id")]
        public async Task<ActionResult<manufacturers>> getManufacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return Ok(manufacturer);
        }


        //Post
        [HttpPost]
        public async Task<ActionResult<manufacturers>> postManufacturer(manufacturers manufacturers)
        {
            try
            {
                _dbContext.manufacturers.Add(manufacturers);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok(manufacturers);
        }

        //Put
        [HttpPut]
        public async Task<ActionResult<manufacturers>> putManufacture(int id,manufacturers newManufacturers)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            manufacturer.Id = newManufacturers.Id;
            manufacturer.Title = newManufacturers.Title;

            await _dbContext.SaveChangesAsync();
            return Ok(manufacturer);
        }

        //Delete
        [HttpDelete]
        public async Task<ActionResult<manufacturers>> deleteManfacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _dbContext.manufacturers.Remove(manufacturer); 
            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }
    }
}
