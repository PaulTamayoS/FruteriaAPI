using FruteriaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using FruteriaAPI.Extensions;
using System.Collections.Generic;
using FruteriaAPI.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;

namespace FruteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrutaController : ControllerBase
    { 
        private readonly FruteriaContext _context;

        public FrutaController(FruteriaContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Fruta>> GetAll()
        {
            return await _context.Frutas.ToListAsync();          
        }

        [HttpGet("{id}")]
        public async Task<Fruta> Get(int id)
        {
            return await _context.Frutas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<int> Post(Fruta myFruta)
        {
            try
            {
                myFruta.Id = 0;
                _context.Frutas.Add(myFruta);
                await _context.SaveChangesAsync();   
            }
            catch (Exception ex)
            {
                int x = 0;
            }

            return myFruta.Id;         
        }

        [HttpPut]
        public async Task Put(Fruta myFruta)
        {

            var query = _context.Frutas.Where(x => x.Id == myFruta.Id);

            if (await query.AnyAsync())
            {
                var myFrutaDB = await query.FirstOrDefaultAsync();

                myFrutaDB.Nombre = myFruta.Nombre;
                myFrutaDB.Precio = myFruta.Precio;
                myFrutaDB.Comentarios = myFruta.Comentarios;

                await _context.SaveChangesAsync();
            }                        
        }

        [HttpDelete]
        public async Task Delete(int id)
        {

            var query = _context.Frutas.Where(x => x.Id == id);

            if (await query.AnyAsync())
            {
                var myFrutaDB = await query.FirstOrDefaultAsync();
                _context.Frutas.Remove(myFrutaDB);           

                await _context.SaveChangesAsync();
            }          
        }
    }
}
