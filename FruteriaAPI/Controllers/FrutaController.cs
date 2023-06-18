using FruteriaAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using FruteriaAPI.Business.Services;

namespace FruteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrutaController : ControllerBase
    {
        private readonly IFrutaService _service;        

        public FrutaController(IFrutaService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Fruta>> GetAll()
        {
            return await _service.GetAll();          
        }

        [HttpGet("{id}")]
        public async Task<Fruta> Get(int id) 
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<int> Post(Fruta myFruta)
        {
            return await _service.Create(myFruta);          
        }

        [HttpPut]
        public async Task Put(Fruta myFruta) 
        {
            await _service.Update(myFruta);            
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _service.Delete(id);           
        }
    }
}
