using FruteriaAPI.Data.Repositories.Core;
using FruteriaAPI.Domain.Models;
using Dapper;
using System.Data.SqlClient;

namespace FruteriaAPI.Data.Repositories
{
    public class FrutaRepository : IFrutaRepository
    {
        protected readonly DbConnectionFactory ConnectionFactory;

        public FrutaRepository(DbConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public async Task<int> Create(Fruta fruta)
        {
            string query = @"INSERT INTO[dbo].[Frutas] ( [Nombre], [Precio], [Comentarios])
                VALUES( @Nombre, @Precio, @Comentarios);
                SELECT @@IDENTITY";

            using var myConne = ConnectionFactory.Connection;

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Nombre", fruta.Nombre, System.Data.DbType.String);
            parametros.Add("Precio", fruta.Precio, System.Data.DbType.Currency);
            parametros.Add("Comentarios", fruta.Comentarios, System.Data.DbType.String);

            return await myConne.QueryFirstOrDefaultAsync<int>(query, parametros);
        }

        public async Task Delete(int id)
        {
            string query = @"DELETE [dbo].[Frutas]               
                WHERE id = @Id";

            using var myConne = ConnectionFactory.Connection;

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Id", id, System.Data.DbType.Int32);

            await myConne.ExecuteAsync(query, parametros);
        }

        public async Task<List<Fruta>> GetAll()
        {
            string query = "Select * from Frutas";
            using var myConne = ConnectionFactory.Connection;   
            var frutas = await myConne.QueryAsync<Fruta>(query);

            return frutas.ToList();
        }

        public async Task<Fruta> GetById(int id)
        {
            string query = "Select * FROM Frutas WHERE id=@id";
            using var myConne = ConnectionFactory.Connection;

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("id", id, System.Data.DbType.Int32);

            var fruta = await myConne.QueryFirstOrDefaultAsync<Fruta>(query, parametros);

            return fruta;
        }

        public async Task Update(Fruta fruta)
        {
            string query = @"UPDATE [dbo].[Frutas]
                SET [Nombre]=@Nombre, 
                    [Precio]=@Precio, 
                    [Comentarios]=@Comentarios 
                WHERE id = @Id";

            using var myConne = ConnectionFactory.Connection;

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Id", fruta.Id, System.Data.DbType.Int32);
            parametros.Add("Nombre", fruta.Nombre, System.Data.DbType.String);
            parametros.Add("Precio", fruta.Precio, System.Data.DbType.Currency);
            parametros.Add("Comentarios", fruta.Comentarios, System.Data.DbType.String);

            await myConne.ExecuteAsync(query, parametros);
        }
    }
}
