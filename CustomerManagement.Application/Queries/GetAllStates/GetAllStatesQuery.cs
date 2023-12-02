using CustomerManagement.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetAllStates
{
    public class GetAllStatesQuery : IRequest<List<StateViewModel>>
    {
    }
}
