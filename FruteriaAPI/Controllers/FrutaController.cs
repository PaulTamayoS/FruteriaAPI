using FruteriaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using FruteriaAPI.Extensions;

namespace FruteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrutaController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _connectionString_Prod;

        public FrutaController(IConfiguration config) 
        {
            _connectionString = config.GetConnectionString("Fruteria");
            _connectionString_Prod = config.GetConnectionString("Fruterias_Prod");
        }

        [HttpGet]
        public IEnumerable<Fruta> GetAll(bool isProd = false)
        {
            string query = "Select * from Frutas";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            var frutas = myConne.Query<Fruta>(query);                       

            return frutas;
        }

        [HttpGet("{id}")]
        public Fruta Get(int id, bool isProd = false) 
        {
            string query = "Select * FROM Frutas WHERE id=@id";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            var fruta = myConne.QueryFirstOrDefault<Fruta>(query, new { id = id });

            return fruta;
        }

        [HttpPost]
        public IActionResult Post(Fruta myFruta)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Fruta myFruta) 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
