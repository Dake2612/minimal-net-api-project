using AutoMapper;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.http.Helpers.LinksBuilders;
using Dario.Robles.Store.Service.Infraestructure.Persistence.UnitOfWork;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders;

namespace Dario.Robles.Store.Service.Application.Services
{
    public partial class StoreApplicationService : IStoreApplicationService
    {
        private readonly StoreUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IStoreLinksBuilder _storeLinksBuilder;
        private readonly IItemLinksBuilder _itemLinksBuilder;

        public StoreApplicationService(
            StoreUnitOfWork unitOfWork,
            IMapper mapper,
            IValidationService validationService,
            IStoreLinksBuilder storeLinksBuilder,
            IItemLinksBuilder itemLinksBuilder
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
            _storeLinksBuilder = storeLinksBuilder;
            _itemLinksBuilder = itemLinksBuilder;
        }
    }
}
