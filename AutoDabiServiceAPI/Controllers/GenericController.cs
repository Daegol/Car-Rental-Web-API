using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDabiServiceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoDabiServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create([FromBody] T request)
        {
            await _repository.CreateAsync(request);
            return Ok("Pomyślnie utworzono");
        }

        [HttpPut]
        public async Task<ActionResult<T>> Update([FromBody] T request)
        {
            try
            {
                await _repository.UpdateAsync(request);
                return Ok("Pomyślnie zaktualizowano");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Nie udało się zaktualizować. Spróbuj ponownie");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(Guid id)
        {
            var request = await _repository.GetById(id);
            await _repository.DeleteAsync(request);
            return Ok("Pomyślnie usunięto");
        }

    }
}