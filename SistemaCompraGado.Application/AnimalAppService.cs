using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Interfaces.Services;
using SistemaCompraGado.Domain.Entities;

namespace SistemaCompraGado.Application
{
    public class AnimalAppService : AppServiceBase<Animal>, IAnimalAppService
    {
        private readonly IAnimalService _AnimalService;
        public AnimalAppService(IAnimalService AnimalService)
            : base(AnimalService)
        {
            _AnimalService = AnimalService;
        }

    }
}
