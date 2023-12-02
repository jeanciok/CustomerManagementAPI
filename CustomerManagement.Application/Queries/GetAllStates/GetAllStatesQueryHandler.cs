using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllStates
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, List<StateViewModel>>
    {
        private readonly IStateRepository _stateRepository;

        public GetAllStatesQueryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<StateViewModel>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            List<State> states = await _stateRepository.GetAll();

            List<StateViewModel> result = states
                .Select(s => new StateViewModel(s.Id, s.Name, s.Uf, s.Cities))
                .ToList();
                

            return result;
        }
    }
}
