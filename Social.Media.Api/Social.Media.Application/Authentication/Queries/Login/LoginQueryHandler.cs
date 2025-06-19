using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Media.Application.Common.Interfaces;

namespace Social.Media.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, string?>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IApplicationDbContext dbContext,
        IPasswordService passwordService,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _passwordService = passwordService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower(), cancellationToken);

        if (user == null)
        {
            return null; 
        }

        var isPasswordCorrect = _passwordService.VerifyPassword(request.Password, user.Salt, user.Password);

        if (!isPasswordCorrect)
        {
            return null; 
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}
