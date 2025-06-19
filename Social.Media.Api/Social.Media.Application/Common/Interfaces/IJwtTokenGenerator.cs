using Social.Media.Model.Entities;

namespace Social.Media.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
