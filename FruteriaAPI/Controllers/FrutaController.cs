using FruteriaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using FruteriaAPI.Extensions;
using System.Collections.Generic;

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
        public async Task<IEnumerable<Fruta>> GetAll(bool isProd = false)
        {
            string query = "Select * from Frutas";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            var frutas = await myConne.QueryAsync<Fruta>(query); 

            return frutas;
        }

        [HttpGet("{id}")]
        public async Task<Fruta> Get(int id, bool isProd = false) 
        {
            string query = "Select * FROM Frutas WHERE id=@id";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("id", id, System.Data.DbType.Int32);

            var fruta = await myConne.QueryFirstOrDefaultAsync<Fruta>(query, parametros);

            return fruta;
        }

        [HttpPost]
        public async Task<int> Post(Fruta myFruta, bool isProd = false)
        {

            string query = @"INSERT INTO[dbo].[Frutas] ( [Nombre], [Precio], [Comentarios])
                VALUES( @Nombre, @Precio, @Comentarios);
                SELECT @@IDENTITY";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Nombre", myFruta.Nombre, System.Data.DbType.String);
            parametros.Add("Precio", myFruta.Precio, System.Data.DbType.Currency);
            parametros.Add("Comentarios", myFruta.Comentarios, System.Data.DbType.String);

            return await myConne.QueryFirstOrDefaultAsync<int>(query, parametros);
        }

        [HttpPut]
        public async Task Put(Fruta myFruta, bool isProd = false) 
        {
            string query = @"UPDATE [dbo].[Frutas]
                SET [Nombre]=@Nombre, 
                    [Precio]=@Precio, 
                    [Comentarios]=@Comentarios 
                WHERE id = @Id";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Id", myFruta.Id, System.Data.DbType.Int32);
            parametros.Add("Nombre", myFruta.Nombre, System.Data.DbType.String);
            parametros.Add("Precio", myFruta.Precio, System.Data.DbType.Currency);
            parametros.Add("Comentarios", myFruta.Comentarios, System.Data.DbType.String);

            await myConne.ExecuteAsync(query, parametros);
        }

        [HttpDelete]
        public async Task Delete(int id, bool isProd = false)
        {
            string query = @"DELETE [dbo].[Frutas]               
                WHERE id = @Id";

            using SqlConnection myConne = new SqlConnection(isProd ? _connectionString_Prod : _connectionString);

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Id", id, System.Data.DbType.Int32);          

            await myConne.ExecuteAsync(query, parametros);
        }
    }
}
