using CustomerManagement.Core.Services;
using MediatR;

public class VerifyTokenQueryHandler : IRequestHandler<VerifyTokenQuery, bool>
{
    private readonly IAuthService _authService;

    public VerifyTokenQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<bool> Handle(VerifyTokenQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_authService.IsTokenValid(request.Token));
    }
}
