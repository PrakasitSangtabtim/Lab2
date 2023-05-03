using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Databases;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        public devicesController(DataDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<devices>>> getDevices()
        {
            var devices = await _dbContext.devices.ToListAsync();

            if (devices.Count == 0)
            {
                return NotFound();
            }

            return Ok(devices);
        }

        [HttpGet("id")]
        public async Task<ActionResult<devices>> getDevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        [HttpPost]
        public async Task<ActionResult<devices>> postDevices(devices devices)
        {
            try
            {
                _dbContext.devices.Add(devices);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok(devices);
        }

        //Put
        [HttpPut]
        public async Task<ActionResult<devices>> putDevices(int id, devices newDevices)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            devices.Id = newDevices.Id;
            devices.Title = newDevices.Title;
            devices.Processor = newDevices.Processor;
            devices.Price = newDevices.Price;
            devices.Manufacturer_id = newDevices.Manufacturer_id;

            await _dbContext.SaveChangesAsync();
            return Ok(devices);
        }

        //Delete
        [HttpDelete]
        public async Task<ActionResult<devices>> deleteDevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            _dbContext.devices.Remove(devices);
            await _dbContext.SaveChangesAsync();

            return Ok(devices);
        }


        [HttpGet("manufacturerId")]
        public async Task<ActionResult<List<devices>>> getDevicesmanufacturerId(int id)
        {

            var device = await _dbContext.devices.Where(e => e.Manufacturer_id == id).ToListAsync();
          
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }


    }
}
