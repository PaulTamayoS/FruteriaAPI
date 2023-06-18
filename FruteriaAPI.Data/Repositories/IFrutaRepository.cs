using FruteriaAPI.Domain.Models;

namespace FruteriaAPI.Data.Repositories
{
    public interface IFrutaRepository
    {
        Task<List<Fruta>> GetAll();

        Task<Fruta> GetById(int id);

        Task<int> Create(Fruta fruta);

        Task Update(Fruta fruta); 
        
        Task Delete(int id);

    }
}
