using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Services
{
    public class PecuaristaService : ServiceBase<Pecuarista>, IPecuaristaService
    {
        private readonly IPecuaristaRepository _PecuaristaRepository;

        public PecuaristaService(IPecuaristaRepository PecuaristaRepository)
            : base(PecuaristaRepository)
        {
            _PecuaristaRepository = PecuaristaRepository;
        }
    }
}
