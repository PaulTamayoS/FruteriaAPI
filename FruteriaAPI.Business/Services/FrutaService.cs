using FruteriaAPI.Data.Repositories;
using FruteriaAPI.Domain.Models;
using FruteriaAPI.Business.Extensions;

namespace FruteriaAPI.Business.Services
{
    public class FrutaService : IFrutaService
    {
        private readonly IFrutaRepository _repository;
        public FrutaService(IFrutaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Fruta fruta)
        {
            return await _repository.Create(fruta);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Fruta>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Fruta> GetById(int id)
        {            
            return await _repository.GetById(id);
        }

        public async Task<FrutaFormattedPriceResponse> GetFormatedPriceById(int id)
        {
            var fruta =  await _repository.GetById(id);

            //TODO exchange rate

            return new FrutaFormattedPriceResponse { Nombre = fruta.Nombre, Precio = fruta.Precio.ToCustomPrecio() };
        }

        public async Task Update(Fruta fruta)
        {
            await _repository.Update(fruta);
        }
    }
}
