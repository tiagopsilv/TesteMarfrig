using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Interfaces.Services;
using SistemaCompraGado.Domain.Entities;

namespace SistemaCompraGado.Application
{
    public class PecuaristaAppService : AppServiceBase<Pecuarista>, IPecuaristaAppService
    {
        private readonly IPecuaristaService _PecuaristaService;
        public PecuaristaAppService(IPecuaristaService PecuaristaService)
            : base(PecuaristaService)
        {
            _PecuaristaService = PecuaristaService;
        }

    }
}
