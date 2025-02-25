using MediatR;

public class VerifyTokenQuery : IRequest<bool>
{
    public string Token { get; set; }

    public VerifyTokenQuery(string token)
    {
        Token = token;
    }
}
