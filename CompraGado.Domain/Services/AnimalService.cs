using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Services
{
    public class AnimalService : ServiceBase<Animal>, IAnimalService
    {
        private readonly IAnimalRepository _AnimalRepository;

        public AnimalService(IAnimalRepository AnimalRepository)
            : base(AnimalRepository)
        {
            _AnimalRepository = AnimalRepository;
        }

    }
}
