using FruteriaAPI.Domain.Models;

namespace FruteriaAPI.Business.Services
{
    public interface IFrutaService
    {
        Task<List<Fruta>> GetAll();

        Task<Fruta> GetById(int id);

        Task<int> Create(Fruta fruta);

        Task Update(Fruta fruta);

        Task Delete(int id);

        Task<FrutaFormattedPriceResponse> GetFormatedPriceById(int id);
    }
}
